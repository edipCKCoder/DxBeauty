using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXBeauty.Dtos
{
    // Modül 1: Günlük Kasa Özeti (KPI Kartları)
    public class DailySummaryDto
    {
        public decimal TotalRevenue { get; set; }       // Toplam Ciro (Bugün)
        public decimal CashTotal { get; set; }          // Nakit Toplamı
        public decimal CreditCardTotal { get; set; }    // Kredi Kartı Toplamı
        public decimal EftTotal { get; set; }           // Havale/EFT Toplamı
        public decimal ExpectedInstallments { get; set; } // Bugün vadesi gelip ödenmemiş taksit toplamı
        public int TodayAppointmentCount { get; set; }  // Bugünün aktif randevu sayısı
    }

    // Modül 2: Bugünün Randevuları
    public class TodayAppointmentDto
    {
        public int AppointmentId { get; set; }
        public string CustomerName { get; set; }
        public string ServiceName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        // public DateTime SelectedTime { get; set; }
        public int Status { get; set; } // 0: Bekliyor, 1: Tamamlandı vb.
    }

    // Modül 3: Grafikler İçin DTO'lar
    public class MonthlyRevenueDto
    {
        public DateTime Date { get; set; }
        public decimal DailyTotal { get; set; }
    }

    public class TopSellingPackageDto
    {
        public string PackageName { get; set; }
        public int SalesCount { get; set; }
    }

    // Modül 4: Kritik Uyarılar (Borçlar vs.)
    public class CriticalAlertDto
    {
        public string AlertType { get; set; } // "BORÇ" veya "DOĞUM GÜNÜ"
        public string CustomerName { get; set; }
        public string Description { get; set; }
        public DateTime? AlertDate { get; set; }
        public decimal? Amount { get; set; }
    }
}
