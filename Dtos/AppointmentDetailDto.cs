using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXBeauty.Dtos
{
    public class AppointmentDetailDto
    {

        [DisplayName("Başlangıç Tarihi")]
        public DateTime StartDate { get; set; }      // appointment_start_date

        [DisplayName("Bitiş Tarihi")]
        public DateTime? EndDate { get; set; }        // appointment_end_date,
        [DisplayName("Hizmet Adı")]
        public string ServiceName { get; set; }       // services.name (Örn: Lazer Epilasyon)

        [DisplayName("Personel Adı")]
        public string PersonnelName { get; set; }     // personnels.full_name (Randevuya bakan uzman)

        [DisplayName("Randevu Durumu")]
        public string Status { get; set; }            // status (Enum'dan çevrilmiş: Planlandı, Tamamlandı, İptal, Gelmedi)

        // Ekstra Bilgiler
        [DisplayName("Randevu Başlığı")]
        public string Subject { get; set; }           // subject (Kullanıcının girdiği başlık)
        [DisplayName("Açıklama")]
        public string Description { get; set; }       // description (Özel notlar)
        [DisplayName("Yer")]
        public string Location { get; set; }          // location (Hangi oda/kabin?)
        [DisplayName("Tüm Gun Mü?")]
        public bool IsAllDay { get; set; }            // all_day (Tüm gün mü?)
        [DisplayName("İlişkili Satış Paketi")]
        // Eğer bu randevu bir paketten düşüldüyse paketin adını da gösterebiliriz
        public string RelatedPackageName { get; set; } // customer_services -> service_packages.name
    }
}

