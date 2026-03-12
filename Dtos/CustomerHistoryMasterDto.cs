using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXBeauty.Dtos
{
    public class CustomerHistoryMasterDto
    {
        public DateTime EventDate { get; set; }      // İşlem Tarihi (Randevu tarihi, Satış tarihi veya Tahsilat tarihi)
        public string EventType { get; set; }        // İşlem Türü: "Randevu", "Paket Satışı", "Tahsilat"
        public string Summary { get; set; }          // Özet: "Lazer Epilasyon (Tamamlandı)", "2. Taksit Ödemesi", "Cilt Bakım Paketi"

        // --- DEVEXPRESS MASTER-DETAIL LİSTELERİ ---
        // DevExpress bu listeleri otomatik olarak alt tablo (Detail View) yapar!
        // Hangi liste doluysa (null değilse), satırın altında o tablo açılır.
        public List<AppointmentDetailDto> AppointmentDetails { get; set; }
        public List<PaymentDetailDto> PaymentDetails { get; set; }
        public List<PackageDetailDto> PackageDetails { get; set; }
    }
}
