using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXBeauty.Enums
{
    public enum AppointmentStatusType
    {
        None = 0, // Randevu oluşturulmadı (None): Randevu oluşturulmadı.
        Planned = 1, //Onaylandı (Planned): Randevu plalanmış.
        Completed = 2, //Tamamlandı (Completed): Randevu başarılı bir şekilde tamamlanmış.
        Cancelled = 3, //İptal Edildi (Canceled): Randevu müşteri veya salon tarafından iptal edilmiş.
        NoShow = 4 // Gelmeme (No-Show): Müşteri randevuya gelmemiş ve önceden haber vermemiş.
    }
}
