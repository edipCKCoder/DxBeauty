using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXBeauty.Dtos
{
    public class AppointmentDetailDto
    {
        public DateTime StartDate { get; set; }      // appointment_start_date
        public DateTime? EndDate { get; set; }        // appointment_end_date
        public string ServiceName { get; set; }       // services.name (Örn: Lazer Epilasyon)
        public string PersonnelName { get; set; }     // personnels.full_name (Randevuya bakan uzman)
        public string Status { get; set; }            // status (Enum'dan çevrilmiş: Planlandı, Tamamlandı, İptal, Gelmedi)

        // Ekstra Bilgiler
        public string Subject { get; set; }           // subject (Kullanıcının girdiği başlık)
        public string Description { get; set; }       // description (Özel notlar)
        public string Location { get; set; }          // location (Hangi oda/kabin?)
        public bool IsAllDay { get; set; }            // all_day (Tüm gün mü?)

        // Eğer bu randevu bir paketten düşüldüyse paketin adını da gösterebiliriz
        public string RelatedPackageName { get; set; } // customer_services -> service_packages.name
    }
}

