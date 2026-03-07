using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXBeauty.Entities
{
    public class Appointment
    {
        // --- PRIVATE BACKING FIELDS ---
        private int _appointmentId;
        private int? _customerId;
        private int? _customerServiceId;
        private DateTime _appointmentStartDate;
        private DateTime? _createdAt;
        private DateTime? _appointmentEndDate;
        private int _type;
        private string _subject;
        private string _location;
        private string _description;
        private int? _status;
        private string _reminderInfo;
        private string _recurrenceInfo;
        private int? _label;
        private int? _resourceId;
        private bool? _allDay;
        private int? _serviceId;
        // --- DAPPER İÇİN PARAMETRESİZ CONSTRUCTOR ---
        // Dapper'ın veritabanından okurken nesneyi oluşturabilmesi için gereklidir.
        public Appointment() 
        {

        }

        
        public Appointment(int appointmentId, int? customerId, int? customerServiceId, DateTime appointmentStartDate, DateTime? createdAt, DateTime? appointmentEndDate, int type, string subject, string location, string description, int? status, string reminderInfo, string recurrenceInfo, int? label, int? resourceId, bool? allDay, int? serviceId)
        {
            AppointmentId = appointmentId;
            CustomerId = customerId;
            CustomerServiceId = customerServiceId;
            AppointmentStartDate = appointmentStartDate;
            CreatedAt = createdAt;
            AppointmentEndDate = appointmentEndDate;
            Type = type;
            Subject = subject;
            Location = location;
            Description = description;
            Status = status;
            ReminderInfo = reminderInfo;
            RecurrenceInfo = recurrenceInfo;
            Label = label;
            ResourceId = resourceId;
            AllDay = allDay;
            ServiceId = serviceId;
        }




        // --- PROPERTIES (ÖZELLİKLER) ---

        public int AppointmentId
        {
            get => _appointmentId;
            private set => _appointmentId = value;
        }
        public int? CustomerId
        {
            get => _customerId;
            init => _customerId = value;
        }

        public int? CustomerServiceId
        {
            get => _customerServiceId;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Müşteri Hizmet ID'si sıfır veya negatif olamaz.");
                _customerServiceId = value;
            }
        }

        public DateTime AppointmentStartDate
        {
            get => _appointmentStartDate;
            private set => _appointmentStartDate = value;
        }

        public DateTime? CreatedAt
        {
            get => _createdAt;
            private set => _createdAt = value;
        }

        // Bitiş tarihi başlangıç tarihinden önce olamaz doğrulamasını ekledik
        public DateTime? AppointmentEndDate
        {
            get => _appointmentEndDate;
            private set
            {
                if (value.HasValue && value.Value < _appointmentStartDate)
                    throw new ArgumentException("Bitiş tarihi, başlangıç tarihinden önce olamaz.");
                _appointmentEndDate = value;
            }
        }

        public int Type
        {
            get => _type;
            private set => _type = value;
        }

        public string Subject
        {
            get => _subject;
            private set => _subject = value?.Trim(); // Başındaki ve sonundaki boşlukları temizler
        }

        public string Location
        {
            get => _location;
            private set => _location = value?.Trim();
        }

        public string Description
        {
            get => _description;
            private set => _description = value?.Trim();
        }

        public int? Status
        {
            get => _status;
            private set => _status = value;
        }

        public string ReminderInfo
        {
            get => _reminderInfo;
            set => _reminderInfo = value;
        }

        public string RecurrenceInfo
        {
            get => _recurrenceInfo;
            set => _recurrenceInfo = value;
        }

        public int? Label
        {
            get => _label;
            private set => _label = value;
        }

        public int? ResourceId
        {
            get => _resourceId;
            private set
            {
                if (value.HasValue && value.Value <= 0)
                    throw new ArgumentException("Geçersiz bir Personel/Kaynak ID'si atanamaz.");
                _resourceId = value;
            }
        }

        public bool? AllDay
        {
            get => _allDay;
            private set => _allDay = value;
        }

        public int? ServiceId
        {
            get => _serviceId;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Hizmet ID'si sıfır veya negatif olamaz.");
                _serviceId = value;
            }
        }

    }

}
