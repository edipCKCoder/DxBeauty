using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXBeauty.Dtos
{
    public class PaymentDetailDto
    {
        [DisplayName("Ödeme Yapılma Tarihi")]
        public DateTime PaymentDate { get; set; }    // payment_date (Ödemenin yapıldığı an)
        [DisplayName("Ödeme Miktarı")]
        public decimal Amount { get; set; }          // amount (Kasaya giren para)
        [DisplayName("Ödeme Yöntemi")]
        public string PaymentMethod { get; set; }    // payment_method (Nakit, Kredi Kartı, Havale vb.)

        // Ödeme Neyin Ödemesiydi? (Bağlantılar)
        [DisplayName("Ödeme Planı Tipi")]
        public string PaymentPlanInfo { get; set; }  // payment_plans.plan_type ve sequence_number birleşimi (Örn: "2. Taksit", "Peşinat", "Açık Hesap Tahsilatı")
        [DisplayName("İlişkili Paket")]
        public string RelatedPackage { get; set; }   // Eğer pakete aitse paket adı
        [DisplayName("İlişkili Randevu")]
        public string RelatedAppointment { get; set; } // Eğer tek seans randevusuna aitse randevu tarihi/hizmeti
    }
}
