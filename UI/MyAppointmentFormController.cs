using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXBeauty.UI
{
    public class MyAppointmentFormController : AppointmentFormController
    {
        public MyAppointmentFormController(SchedulerControl control, Appointment apt) : base(control, apt) { }

        // Custom Field'ı property olarak tanımlıyoruz
        public int? CustomerServiceId
        {
            get { return (int?)EditedAppointmentCopy.CustomFields["CS_ID"];}
            set { EditedAppointmentCopy.CustomFields["CS_ID"] = value; }
        }

        public int? ServiceId
        {
            get { return (int?)EditedAppointmentCopy.CustomFields["ServiceId"]; }
            set { EditedAppointmentCopy.CustomFields["ServiceId"] = value; }
        }
        
        public int? CustomerId
        {
            get { return (int?)EditedAppointmentCopy.CustomFields["CustomerId"]; }
            set { EditedAppointmentCopy.CustomFields["CustomerId"] = value; }
        }
    }
}
