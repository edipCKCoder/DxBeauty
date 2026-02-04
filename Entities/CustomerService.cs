using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXBeauty.Entities
{
    public class CustomerService
    {
        private int _customerServiceId;
        private int _customerId;
        private int _serviceId;
        private int? _appointmentId;
        private DateTime _serviceDate;
        private string _notes;

        public int CustomerServiceId
        {
            get => _customerServiceId;
            private set => _customerServiceId = value;
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

        public int? AppointmentId
        {
            get => _appointmentId;
            set => _appointmentId = value;
        }

        public DateTime ServiceDate
        {
            get => _serviceDate;
            set => _serviceDate = value == default ? DateTime.Now : value;
        }

        public string Notes
        {
            get => _notes;
            set => _notes = value?.Trim();
        }
    }

}
