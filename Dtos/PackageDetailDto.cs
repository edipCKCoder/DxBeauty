using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXBeauty.Dtos
{
    public class PackageDetailDto
    {
        public string PackageName { get; set; }      // service_packages.name
        public DateTime StartDate { get; set; }      // start_date (Paketin başlatıldığı tarih)
        public string Status { get; set; }           // status (Aktif, Tamamlandı, İptal Edildi)

        // Seans Bilgileri
        public int TotalSessions { get; set; }       // service_packages.session_count (Toplam Hak)
        public int RemainingSessions { get; set; }   // remaining_sessions (Kalan Hak)

        // Finansal Bilanço (Adisyon / Ledger Mantığı)
        public decimal TotalPrice { get; set; }      // total_price (Paketin Toplam Tutarı)
        public decimal PaidAmount { get; set; }      // paid_amount (Şu ana kadar ödediği toplam para)
        public decimal RemainingDebt { get; set; }   // remaining_debt (Kalan Borç)
    }
}

