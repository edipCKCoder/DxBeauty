using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXBeauty.Entities
{
    public class Payment
    {
        private int _paymentId;
        private int _customerId;
        private int? _appointmentId;
        private decimal _amount;
        private DateTime _paymentDate;
        private string _paymentMethod;

        public int PaymentId
        {
            get => _paymentId;
            private set => _paymentId = value;
        }

        public int CustomerId
        {
            get => _customerId;
            set => _customerId = value;
        }

        public int? AppointmentId
        {
            get => _appointmentId;
            set => _appointmentId = value;
        }

        public decimal Amount
        {
            get => _amount;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Tutar sıfırdan büyük olmalı.");
                _amount = value;
            }
        }

        public DateTime PaymentDate
        {
            get => _paymentDate;
            set => _paymentDate = value == default ? DateTime.Now : value;
        }

        public string PaymentMethod
        {
            get => _paymentMethod;
            set => _paymentMethod = value ?? "Nakit";
        }
    }

}
