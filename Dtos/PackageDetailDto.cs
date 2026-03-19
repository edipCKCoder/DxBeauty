using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXBeauty.Dtos
{
    public class PackageDetailDto
    {
        [DisplayName("Paket Adı")]
        public string PackageName { get; set; }      // service_packages.name
        [DisplayName("Başlanğıç Tarihi")]
        public DateTime StartDate { get; set; }      // start_date (Paketin başlatıldığı tarih)
        [DisplayName("Durumu")]
        public string Status { get; set; }           // status (Aktif, Tamamlandı, İptal Edildi)

        // Seans Bilgileri
        [DisplayName("Seans Sayısı")]
        public int TotalSessions { get; set; }       // service_packages.session_count (Toplam Hak)
        [DisplayName("Kalan Seans Sayısı")]
        public int RemainingSessions { get; set; }   // remaining_sessions (Kalan Hak)

        // Finansal Bilanço (Adisyon / Ledger Mantığı)
        [DisplayName("Toplam Tutar")]
        public decimal TotalPrice { get; set; }      // total_price (Paketin Toplam Tutarı)
        [DisplayName("Ödenen Tutar")]
        public decimal PaidAmount { get; set; }      // paid_amount (Şu ana kadar ödediği toplam para)
        [DisplayName("Kalan Borç")]
        public decimal RemainingDebt { get; set; }   // remaining_debt (Kalan Borç)
    }
}

