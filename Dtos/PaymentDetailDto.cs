using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXBeauty.Dtos
{
    public class PaymentDetailDto
    {
        public DateTime PaymentDate { get; set; }    // payment_date (Ödemenin yapıldığı an)
        public decimal Amount { get; set; }          // amount (Kasaya giren para)
        public string PaymentMethod { get; set; }    // payment_method (Nakit, Kredi Kartı, Havale vb.)

        // Ödeme Neyin Ödemesiydi? (Bağlantılar)
        public string PaymentPlanInfo { get; set; }  // payment_plans.plan_type ve sequence_number birleşimi (Örn: "2. Taksit", "Peşinat", "Açık Hesap Tahsilatı")
        public string RelatedPackage { get; set; }   // Eğer pakete aitse paket adı
        public string RelatedAppointment { get; set; } // Eğer tek seans randevusuna aitse randevu tarihi/hizmeti
    }
}
