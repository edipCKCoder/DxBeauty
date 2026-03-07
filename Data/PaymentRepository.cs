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

        /*müşterinin paketlerini ve o paketlere ait ödenmemiş taksitleri birleştirip getirir:
         * 
         *
         *--AND NOT EXISTS (SELECT 1 FROM payments p WHERE p.appointment_id = a.appointment_id) -- Henüz ödemesi alınmamış--
         *
         *
         *Aynı müşterinin Farklı hizmetleri olan Birden fazla tek seans randevusu olabilir.  
         *veya Aynı müşterinin Birden fazla tek seans randevusu olabilir ve hepsi aynı hizmete sahiptir 
         *Bu randevuları nasıl ele alacağız ve ödeme işlemi sırasında nasıl seçeceğiz?
         */
        public async Task<IEnumerable<CustomerDebtDto>> GetUnpaidDebtsAsync(int customerId)
        {
            string sql = @"
        -- 1. BÖLÜM: ÖDENMEMİŞ PAKET TAKSİTLERİ
        SELECT 
            'Paket Taksidi' AS DebtType,
            sp.name || ' - ' || i.installment_number || '. Taksit' AS Description,
            i.due_date AS DueDate,
            (i.amount - COALESCE(i.paid_amount, 0)) AS Amount, -- Sadece Kalan Tutarı Göster! AS Amount,
            i.installment_id AS InstallmentId,
            cs.customer_service_id AS CustomerServiceId,
            NULL::int AS AppointmentId
        FROM installments i
        INNER JOIN customer_services cs ON i.customer_service_id = cs.customer_service_id
        INNER JOIN service_packages sp ON cs.service_package_id = sp.service_package_id
        WHERE cs.customer_id = @CustomerId AND i.is_paid = false

        UNION ALL

        -- 2. BÖLÜM: ÖDENMEMİŞ TEK SEANS RANDEVULARI
        SELECT 
            'Tek Seans' AS DebtType,
            COALESCE(s.name, 'Genel İşlem') || ' Randevusu' AS Description,
            CAST(a.appointment_start_date AS DATE) AS DueDate,
            0 AS Amount, -- NOT: Fiyat tablosunda olmadığı için şimdilik 0 geliyor, vezne elle girecek
            NULL::int AS InstallmentId,
            NULL::int AS CustomerServiceId,
            a.appointment_id AS AppointmentId
        FROM appointments a
        LEFT JOIN services s ON a.service_id = s.service_id
        WHERE a.customer_id = @CustomerId 
          AND a.customer_service_id IS NULL -- Pakete bağlı OLMAYAN randevular
         -- AND a.status != 3  (Opsiyonel) İptal edilen randevuları getirme (Eğer status 3 iptalse)
          AND NOT EXISTS (SELECT 1 FROM payments p WHERE p.appointment_id = a.appointment_id) -- Henüz ödemesi alınmamış
        
        -- Her iki tablo birleştikten sonra tarihe göre eskiden yeniye sırala
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
                        INSERT INTO payments (customer_id, customer_service_id, appointment_id, installment_id, amount, payment_method, payment_date)
                        VALUES (@CustomerId, @CustomerServiceId, @AppointmentId, @InstallmentId, @Amount, @PaymentMethod, @PaymentDate);";

                            await connection.ExecuteAsync(insertPaymentSql, new
                            {
                                CustomerId = customerId,
                                CustomerServiceId = debt.CustomerServiceId,
                                AppointmentId = debt.AppointmentId,
                                InstallmentId = debt.InstallmentId,
                                Amount = currentPaymentAmount, // Her satırın kendi tutarı
                                PaymentMethod = paymentMethod,
                                PaymentDate = paymentDate
                            }, transaction); // Transaction parametresini unutma!

                            // 2. EĞER BU BİR PAKET TAKSİDİYSE (Installments ve Customer_Services Güncelle)
                            if (debt.InstallmentId.HasValue && debt.CustomerServiceId.HasValue)
                            {
                                // Taksitin "ödenen miktarını" artırıyoruz. 
                                // Eğer ödenen miktar, taksitin toplam tutarına eşit veya büyükse is_paid = true yapıyoruz!
                                string updateInstallmentSql = @"
                            UPDATE installments 
                            SET paid_amount = COALESCE(paid_amount, 0) + @PaidAmount,
                                paid_at = @PaymentDate,
                                is_paid = CASE WHEN (COALESCE(paid_amount, 0) + @PaidAmount) >= amount THEN true ELSE false END
                            WHERE installment_id = @InstallmentId;";
                                await connection.ExecuteAsync(updateInstallmentSql, new { PaidAmount = currentPaymentAmount, PaymentDate = paymentDate, InstallmentId = debt.InstallmentId }, transaction);

                                // Müşterinin paket (Cari) genel toplamını güncelle
                                string updateServiceSql = @"
                            UPDATE customer_services 
                            SET paid_amount = COALESCE(paid_amount, 0) + @PaidAmount, 
                                remaining_debt = remaining_debt - @PaidAmount 
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

        public List<Payment> GetAll()
        {
            var sql = "SELECT * FROM payments ORDER BY payment_date DESC";
            return Query<Payment>(sql).ToList();
        }

        public void Insert(Payment p)
        {
            var sql = @"INSERT INTO payments 
                        (customer_id, appointment_id, amount, payment_date, payment_method)
                        VALUES (@CustomerId, @AppointmentId, @Amount, @PaymentDate, @PaymentMethod)";
            Execute(sql, p);
        }

        public void Delete(int id)
        {
            var sql = "DELETE FROM payments WHERE payment_id = @Id";
            Execute(sql, new { Id = id });
        }

    }
}
