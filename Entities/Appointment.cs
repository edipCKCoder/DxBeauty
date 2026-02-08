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
        private int _customerServiceId;
        private DateTime _appointmentDate;
        private int _durationMinutes;
        private string _status;  // scheduled, completed, cancelled
        private string _notes;
        private DateTime _createdAt;

        public int AppointmentId
        {
            get => _appointmentId;
            private set => _appointmentId = value;
        }

        public int CustomerServiceId
        {
            get => _customerServiceId;
            set => _customerServiceId = value;
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
        public string Notes
        {
            get => _notes;
            set => _notes = value;
        }

        public DateTime CreatedAt
        {
            get => _createdAt;
            private set => _createdAt = DateTime.Now;
        }

    }

}
