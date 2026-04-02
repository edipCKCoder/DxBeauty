using Dapper;
using DXBeauty.Dtos;
using DXBeauty.Entities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXBeauty.Data
{
    public class PaymentRepository : DapperRepository
    {
        private readonly string _connectionString;
        public PaymentRepository(string connectionString) : base(connectionString) 
        {
            _connectionString = connectionString;
        }

        /*              
         Müşterinin Ödeme Planlarını (Peşinat, Taksit, Açık Hesap) getiriyoruz ve ona gore borçlarını getiriyoruz
         */
        public async Task<IEnumerable<CustomerDebtDto>> GetUnpaidDebtsAsync(int customerId)
        {
            string sql = @"
        -- 1. BÖLÜM: PAKET ÖDEME PLANLARI (Peşinat, Taksit, Açık Hesap)
        SELECT 

            'Paket Ödemesi' AS DebtType,
            -- İŞTE SİHİRLİ VİTRİN KODU:
            CASE 
                WHEN pp.plan_type = 1 THEN 'Peşinat - ' || sp.name
                WHEN pp.plan_type = 3 THEN 'Açık Hesap Bakiyesi - ' || sp.name
                ELSE COALESCE(pp.sequence_number::text, '') || '. Taksit - ' || sp.name
            END AS Description,
            
            pp.due_date AS DueDate,
            (pp.amount - COALESCE(pp.paid_amount, 0)) AS Amount, -- Kalan Tutarı Göster
            pp.payment_plan_id AS PaymentPlanId,
            cs.customer_service_id AS CustomerServiceId,
            NULL::int AS AppointmentId
        FROM payment_plans pp
        INNER JOIN customer_services cs ON pp.customer_service_id = cs.customer_service_id
        INNER JOIN service_packages sp ON cs.service_package_id = sp.service_package_id
        WHERE cs.customer_id = @CustomerId AND pp.is_paid = false
                                           AND (pp.amount - COALESCE(pp.paid_amount, 0)) > 0 -- EMNİYET KEMERİ: Kalan tutar 0 ise ekrana getirme!
        ORDER BY DueDate ASC;";

            using (var connection = new NpgsqlConnection(_connectionString)) // Kendi bağlantı nesneni kullan
            {
                return await connection.QueryAsync<CustomerDebtDto>(sql, new { CustomerId = customerId });
            }
        }


        // Bu metot, formdan seçilen satırları (debts) liste olarak alır ve tek bir işlemde eritir.
        public async Task<bool> ProcessPaymentsAsync(int customerId, List<CustomerDebtDto> selectedDebts, decimal totalPaidAmount, string paymentMethod, DateTime paymentDate)
        {
            using (var connection = new NpgsqlConnection(_connectionString)) // Kendi bağlantı dizesini yaz
            {
                await connection.OpenAsync();

                // SİHİR BURADA BAŞLIYOR: İşlem bütünlüğünü (Transaction) başlatıyoruz!
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {

                        decimal remainingMoneyToDistribute = totalPaidAmount;

                        foreach (var debt in selectedDebts)
                        {

                            // Eğer elimizdeki para bittiyse, diğer seçili satırlara işlem yapma, döngüden çık
                            if (remainingMoneyToDistribute <= 0) break;

                            // Bu satır için ne kadar ödeme düşeceğiz? 
                            // (Borç tutarı ile elimizdeki paranın hangisi küçükse onu al)
                            decimal currentPaymentAmount = Math.Min(debt.Amount, remainingMoneyToDistribute);
                           

                            // 1. KASAYA PARA GİRİŞİ (payments tablosuna ekle)
                            string insertPaymentSql = @"
                        INSERT INTO payments (customer_id, customer_service_id, appointment_id, payment_plan_id, amount, payment_method, payment_date)
                        VALUES (@CustomerId, @CustomerServiceId, @AppointmentId, @PaymentPlanId, @Amount, @PaymentMethod, @PaymentDate);";

                            await connection.ExecuteAsync(insertPaymentSql, new
                            {
                                CustomerId = customerId,
                                CustomerServiceId = debt.CustomerServiceId,
                                AppointmentId = debt.AppointmentId,
                                PaymentPlanId  = debt.PaymentPlanId,
                                Amount = currentPaymentAmount, // Her satırın kendi tutarı
                                PaymentMethod = paymentMethod,
                                PaymentDate = paymentDate
                            }, transaction); // Transaction parametresini unutma!

                            // 2. EĞER BU BİR PAKET TAKSİDİYSE (payment_plans ve Customer_Services Güncelle)
                            if (debt.PaymentPlanId.HasValue && debt.CustomerServiceId.HasValue)
                            {
                                // Taksitin "ödenen miktarını" artırıyoruz. 
                                // Eğer ödenen miktar, taksitin toplam tutarına eşit veya büyükse is_paid = true yapıyoruz!
                                string updatePaymentPlanSql = @"
                            UPDATE payment_plans 
                            SET paid_amount = COALESCE(paid_amount, 0) + @PaidAmount,
                                paid_at = @PaymentDate,
                                is_paid = CASE WHEN (COALESCE(paid_amount, 0) + @PaidAmount) >= amount THEN true ELSE false END
                            WHERE payment_plan_id = @PaymentPlanId;";
                                await connection.ExecuteAsync(updatePaymentPlanSql, new { PaidAmount = currentPaymentAmount, PaymentDate = paymentDate, PaymentPlanId = debt.PaymentPlanId }, transaction);

                                // Müşterinin paket (Cari) genel toplamını güncelle
                                string updateServiceSql = @"
                            UPDATE customer_services 
                            SET paid_amount = COALESCE(paid_amount, 0) + @PaidAmount, 
                                remaining_debt = remaining_debt - @PaidAmount, 

                                                status = CASE 
                                    -- 1. DURUM: Kalan borç 0 veya altına düştüyse -> Tüm borçlar ödendi (NoDebt = 3)
                                    WHEN (remaining_debt - @PaidAmount) <= 0 THEN 3 
                    
                                    -- 2. DURUM: Kasaya para girdiyse ama borç bitmediyse -> Kısmi Ödeme (PartialPayment = 2)
                                    WHEN (COALESCE(paid_amount, 0) + @PaidAmount) > 0 AND (remaining_debt - @PaidAmount) > 0 THEN 2 
                    
                                    -- 3. DURUM: (Çok nadir) Hiç ödeme alınmadıysa -> NoPayment = 1
                                    ELSE 1 
                                 END
                            WHERE customer_service_id = @CustomerServiceId;";
                                await connection.ExecuteAsync(updateServiceSql, new { PaidAmount = currentPaymentAmount, CustomerServiceId = debt.CustomerServiceId }, transaction);
                            }

                            // 3. EĞER BU TEK SEANS RANDEVUYSA (Appointments Status Güncelle)
                            if (debt.AppointmentId.HasValue)
                            {
                                // Randevunun durumunu "Ödendi" (Örn: 5) yap kısmi ödendi status'u oluştur daha sonra
                                string updateAppointmentSql = "UPDATE appointments SET status = 5 WHERE appointment_id = @AppointmentId;";
                                await connection.ExecuteAsync(updateAppointmentSql, new { AppointmentId = debt.AppointmentId }, transaction);
                            }

                            // Bu satırın borcunu ödedik, elimizdeki paradan bu tutarı düşüyoruz
                            remainingMoneyToDistribute -= currentPaymentAmount;
                        }

                        // HER ŞEY BAŞARILIYSA: Veritabanına "Kalıcı Olarak Yaz" emri ver
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        // EN UFAK BİR HATA OLURSA: Hiçbir şeyi kaydetme, her şeyi geri al (Rollback)
                        transaction.Rollback();
                        throw new Exception("Tahsilat işlemi sırasında bir hata oluştu ve işlem iptal edildi: " + ex.Message);
                    }
                }
            }
        }

    }
}
