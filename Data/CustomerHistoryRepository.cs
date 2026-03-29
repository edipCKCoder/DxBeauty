using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DXBeauty.Dtos;
using Dapper;
namespace DXBeauty.Data
{
    public class CustomerHistoryRepository : DapperRepository
    {
        private readonly string _connectionString;
        public CustomerHistoryRepository(string connectionString) : base(connectionString) 
        { 
            _connectionString = connectionString;
        }

        public async Task<List<CustomerHistoryMasterDto>> GetCustomerHistoryAsync(int customerId)
        {
            var historyList = new List<CustomerHistoryMasterDto>();

            // 1. Dapper QueryMultiple ile tek bağlantıda 3 sorgu birden atıyoruz (Efsane performans!)
            string sql = @"
                -- SORGGU 1: RANDEVULAR
                SELECT 
                    a.appointment_start_date as EventDate,
                    'Randevu' as EventType,
                    COALESCE(s.service_name, 'Genel İşlem') || ' Randevusu' as Summary,
                    a.appointment_start_date as StartDate,
                    a.appointment_end_date as EndDate,
                    s.service_name as ServiceName,
                    p.full_name as PersonnelName,
                    a.status as Status,
                    a.subject as Subject,
                    a.description as Description,
                    a.location as Location,
                    a.all_day as IsAllDay,
                    sp.name as RelatedPackageName
                FROM appointments a
                LEFT JOIN services s ON a.service_id = s.service_id
                LEFT JOIN personnels p ON a.resource_id = p.personnel_id
                LEFT JOIN customer_services cs ON a.customer_service_id = cs.customer_service_id
                LEFT JOIN service_packages sp ON cs.service_package_id = sp.service_package_id
                WHERE a.customer_id = @CustomerId;

                -- SORGU 2: TAHSİLATLAR (ÖDEMELER)
                SELECT 
                    p.payment_date as EventDate,
                    'Tahsilat' as EventType,
                    p.amount || ' TL Tahsilat Alındı' as Summary,
                    p.payment_date as PaymentDate,
                    p.amount as Amount,
                    p.payment_method as PaymentMethod,
                    CASE 
                        WHEN pp.plan_type = 1 THEN 'Peşinat'
                        WHEN pp.plan_type = 3 THEN 'Açık Hesap Tahsilatı'
                        ELSE pp.sequence_number || '. Taksit' 
                    END as PaymentPlanInfo,
                    sp.name as RelatedPackage,
                    s.service_name as RelatedAppointment
                FROM payments p
                LEFT JOIN payment_plans pp ON p.payment_plan_id = pp.payment_plan_id
                LEFT JOIN customer_services cs ON p.customer_service_id = cs.customer_service_id
                LEFT JOIN service_packages sp ON cs.service_package_id = sp.service_package_id
                LEFT JOIN appointments a ON p.appointment_id = a.appointment_id
                LEFT JOIN services s ON a.service_id = s.service_id
                WHERE p.customer_id = @CustomerId;

                -- SORGU 3: PAKET SATIŞLARI (Müşteri Servisleri)
                SELECT 
                    cs.start_date as EventDate,
                    'Paket Satışı' as EventType,
                    sp.name || ' Satışı' as Summary,
                    sp.name as PackageName,
                    cs.start_date as StartDate,
                    cs.status as Status,
                    sp.session_count as TotalSessions,
                    cs.remaining_sessions as RemainingSessions,
                    cs.total_price as TotalPrice,
                    cs.paid_amount as PaidAmount,
                    cs.remaining_debt as RemainingDebt
                FROM customer_services cs
                INNER JOIN service_packages sp ON cs.service_package_id = sp.service_package_id
                WHERE cs.customer_id = @CustomerId;
            ";

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                // GridReader kullanarak dönen 3 tabloyu sırayla okuyoruz
                using (var multi = await connection.QueryMultipleAsync(sql, new { CustomerId = customerId }))
                {
                    // 1. Randevuları Oku ve Master Listeye Ekle
                    var appointments = await multi.ReadAsync<dynamic>();
                    foreach (var a in appointments)
                    {
                        var master = new CustomerHistoryMasterDto
                        {
                            EventDate = a.eventdate,
                            EventType = a.eventtype,
                            Summary = a.summary,
                            AppointmentDetails = new List<AppointmentDetailDto>
                            {
                                new AppointmentDetailDto
                                {
                                    StartDate = a.startdate,
                                    EndDate = a.enddate,
                                    ServiceName = a.servicename,
                                    PersonnelName = a.personnelname,
                                    Status = GetAppointmentStatusName((int?)a.status), // Özel Enum Çevirici
                                    Subject = a.subject,
                                    Description = a.description,
                                    Location = a.location,
                                    IsAllDay = a.isallday,
                                    RelatedPackageName = a.relatedpackagename
                                }
                            }
                        };
                        historyList.Add(master);
                    }

                    // 2. Tahsilatları Oku ve Master Listeye Ekle
                    var payments = await multi.ReadAsync<dynamic>();
                    foreach (var p in payments)
                    {
                        var master = new CustomerHistoryMasterDto
                        {
                            EventDate = p.eventdate, // Tarih
                            EventType = p.eventtype, // Tür
                            Summary = p.summary,     // Özet
                            PaymentDetails = new List<PaymentDetailDto>
                            {
                                new PaymentDetailDto
                                {
                                    PaymentDate = p.paymentdate,
                                    Amount = p.amount,
                                    PaymentMethod = p.paymentmethod,
                                    PaymentPlanInfo = p.paymentplaninfo,
                                    RelatedPackage = p.relatedpackage,
                                    RelatedAppointment = p.relatedappointment
                                }
                            }
                        };
                        historyList.Add(master);
                    }

                    // 3. Paket Satışlarını Oku ve Master Listeye Ekle
                    var packages = await multi.ReadAsync<dynamic>();
                    foreach (var pkg in packages)
                    {
                        var master = new CustomerHistoryMasterDto
                        {
                            EventDate = pkg.eventdate,
                            EventType = pkg.eventtype,
                            Summary = pkg.summary,
                            PackageDetails = new List<PackageDetailDto>
                            {
                                new PackageDetailDto
                                {
                                    PackageName = pkg.packagename,
                                    StartDate = pkg.startdate,
                                    Status = GetPackageStatusName((int?)pkg.status),
                                    TotalSessions = pkg.totalsessions,
                                    RemainingSessions = pkg.remainingsessions,
                                    TotalPrice = pkg.totalprice,
                                    PaidAmount = pkg.paidamount,
                                    RemainingDebt = pkg.remainingdebt
                                }
                            }
                        };
                        historyList.Add(master);
                    }
                }
            }

            // Tüm geçmişi Tarihe göre yeniden eskiye (Azalan) sırala ve UI'a gönder!
            return historyList.OrderByDescending(x => x.EventDate).ToList();
        }

        // --- YARDIMCI METOTLAR (Enum'ları okunaklı metne çevirmek için) ---
        private string GetAppointmentStatusName(int? statusId)
        {
            if (!statusId.HasValue) return "Belirsiz";
            switch (statusId.Value)
            {
                case 1: return "Planlandı";
                case 2: return "Tamamlandı";
                case 3: return "İptal Edildi";
                case 4: return "Gelmedi (No-Show)";
                default: return "Atanmadı";
            }
        }

        private string GetPackageStatusName(int? statusId)
        {
            if (!statusId.HasValue) return "Belirsiz";
            switch (statusId.Value)
            {
                case 1: return "Ödeme Bekliyor";
                case 2: return "Kısmi Ödendi";
                case 3: return "Tamamı Ödendi";
                default: return "Bilinmiyor";
            }
        }
    }
}
