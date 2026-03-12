using Dapper;
using DXBeauty.Dtos;
using DXBeauty.Entities;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DXBeauty.Data
{
    public class DashboardRepository : DapperRepository
    {
        private readonly string _connectionString;
        public DashboardRepository(string connectionString) : base(connectionString) 
        {
            _connectionString = connectionString;
        }

        // ====================================================================
        // MODÜL 1: GÜNLÜK KASA ÖZETİ (Metin Tabanlı Ödeme Yöntemi Düzeltmesiyle)
        // ====================================================================
        public async Task<DailySummaryDto> GetDailySummaryAsync()
        {
            string sql = @"
                SELECT 
                    -- 1. Bugünün Toplam Tahsilatı
                    COALESCE((SELECT SUM(amount) FROM payments WHERE payment_date::date = CURRENT_DATE), 0) AS TotalRevenue,
                    
                    -- 2. Ödeme Yöntemine Göre Dağılım (TEXT KONTROLÜ EKLENDİ)
                    COALESCE((SELECT SUM(amount) FROM payments WHERE payment_date::date = CURRENT_DATE AND payment_method = 'Nakit'), 0) AS CashTotal,
                    COALESCE((SELECT SUM(amount) FROM payments WHERE payment_date::date = CURRENT_DATE AND payment_method = 'Kredi Kartı'), 0) AS CreditCardTotal,
                    COALESCE((SELECT SUM(amount) FROM payments WHERE payment_date::date = CURRENT_DATE AND (payment_method = 'Havale/EFT' OR payment_method = 'EFT' OR payment_method = 'Havale/EFT')), 0) AS EftTotal,
                    
                    -- 3. Bugün Ödenmesi Beklenen Taksitler
                    COALESCE((SELECT SUM(amount - COALESCE(paid_amount, 0)) FROM payment_plans WHERE due_date = CURRENT_DATE AND is_paid = false), 0) AS ExpectedInstallments,
                    
                    -- 4. Bugünün Aktif Randevu Sayısı
                    (SELECT COUNT(*) FROM appointments WHERE appointment_start_date::date = CURRENT_DATE AND status != 3) AS TodayAppointmentCount;";

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                return await connection.QuerySingleAsync<DailySummaryDto>(sql);
            }
        }

        // ====================================================================
        // MODÜL 2: BUGÜNÜN RANDEVULARI (Değişmedi, Kusursuz Çalışıyor)
        // ====================================================================
        public async Task<IEnumerable<TodayAppointmentDto>> GetTodaysAppointmentsAsync()
        {
            string sql = @"
                SELECT 
                    a.appointment_id AS AppointmentId,
                    c.first_name || ' ' || c.last_name AS CustomerName,
                    COALESCE(s.name, sp.name, 'Genel İşlem') AS ServiceName,
                    a.appointment_start_date AS StartTime,
                    a.status AS Status
                FROM appointments a
                INNER JOIN customers c ON a.customer_id = c.customer_id
                LEFT JOIN services s ON a.service_id = s.service_id
                LEFT JOIN customer_services cs ON a.customer_service_id = cs.customer_service_id
                LEFT JOIN service_packages sp ON cs.service_package_id = sp.service_package_id
                WHERE a.appointment_start_date::date = CURRENT_DATE AND a.status != 3
                ORDER BY a.appointment_start_date ASC;";

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                return await connection.QueryAsync<TodayAppointmentDto>(sql);
            }
        }

        // ====================================================================
        // MODÜL 3: GRAFİKLER (Son 30 Günün Cirosu ve En Çok Satan 5 Paket)
        // ====================================================================

        public async Task<IEnumerable<MonthlyRevenueDto>> GetMonthlyRevenueTrendAsync()
        {
            // Son 30 günün gün gün toplam hasılatını getirir (ChartControl için harika)
            string sql = @"
                SELECT 
                    payment_date::date AS Date, 
                    SUM(amount) AS DailyTotal
                FROM payments
                WHERE payment_date >= CURRENT_DATE - INTERVAL '30 days'
                GROUP BY payment_date::date
                ORDER BY payment_date::date ASC;";

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                return await connection.QueryAsync<MonthlyRevenueDto>(sql);
            }
        }

        public async Task<IEnumerable<TopSellingPackageDto>> GetTopSellingPackagesAsync()
        {
            // Bugüne kadar en çok satılan ilk 5 paketi getirir (Pie Chart / Pasta Grafik için)
            string sql = @"
                SELECT 
                    sp.name AS PackageName, 
                    COUNT(cs.customer_service_id) AS SalesCount
                FROM customer_services cs
                INNER JOIN service_packages sp ON cs.service_package_id = sp.service_package_id
                GROUP BY sp.name
                ORDER BY SalesCount DESC
                LIMIT 5;";

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                return await connection.QueryAsync<TopSellingPackageDto>(sql);
            }
        }

        // ====================================================================
        // MODÜL 4: KRİTİK UYARILAR LİSTESİ (Vadesi Geçmiş Borçlar vb.)
        // ====================================================================
        public async Task<IEnumerable<CriticalAlertDto>> GetCriticalAlertsAsync()
        {
            // Vadesi DÜNDEN önceki günlerde kalmış (geçikmiş) en yüksek 5 borcu kırmızı alarm olarak getirir.
            // Eğer istersen buraya UNION ALL ile "Bugün Doğum Günü Olanlar" sorgusunu da ekleyebiliriz.
            string sql = @"
                SELECT 
                    'GECİKMİŞ BORÇ' AS AlertType,
                    c.first_name || ' ' || c.last_name AS CustomerName,
                    COALESCE(pp.sequence_number::text || '. Taksit', 'Açık Hesap') AS Description,
                    pp.due_date AS AlertDate,
                    (pp.amount - COALESCE(pp.paid_amount, 0)) AS Amount
                FROM payment_plans pp
                INNER JOIN customer_services cs ON pp.customer_service_id = cs.customer_service_id
                INNER JOIN customers c ON cs.customer_id = c.customer_id
                WHERE pp.is_paid = false AND pp.due_date < CURRENT_DATE
                ORDER BY pp.due_date ASC, Amount DESC
                LIMIT 5;";

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                return await connection.QueryAsync<CriticalAlertDto>(sql);
            }
        }
    }
}