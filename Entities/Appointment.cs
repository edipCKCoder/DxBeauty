using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXBeauty.Entities
{
    public class Appointment
    {
        private int _appointmentId;
        private int _customerId;
        private int _serviceId;
        private DateTime _appointmentDate;
        private int _durationMinutes;
        private string _status;

        public int AppointmentId
        {
            get => _appointmentId;
            private set => _appointmentId = value;
        }

        public int CustomerId
        {
            get => _customerId;
            set => _customerId = value;
        }

        public int ServiceId
        {
            get => _serviceId;
            set => _serviceId = value;
        }

        public DateTime AppointmentDate
        {
            get => _appointmentDate;
            set
            {
                if (value < DateTime.Now.AddDays(-1))
                    throw new ArgumentException("Randevu tarihi geçmiş olamaz.");
                _appointmentDate = value;
            }
        }

        public int DurationMinutes
        {
            get => _durationMinutes;
            set => _durationMinutes = value > 0 ? value : throw new ArgumentException("Süre sıfırdan büyük olmalı.");
        }

        public string Status
        {
            get => _status;
            set => _status = value ?? "scheduled";
        }
    }

}
