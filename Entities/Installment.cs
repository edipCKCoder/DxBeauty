using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXBeauty.Entities
{
    public class Installment
    {
        private int _installmentId;
        private int _customerServiceId;
        private int _installmentNumber;
        private decimal _amount;
        private DateTime _dueDate;
        private bool _isPaid;
        private DateTime _paidAt;

        public int InstallmentId
        {
            get => _installmentId;
           init => _installmentId = value;
        }

        public int CustomerServiceId
        {
            get => _customerServiceId;
           init => _customerServiceId = value;
        }

        public int InstallmentNumber
        {
            get => _installmentNumber;
           init => _installmentNumber = value;
        }

        public decimal Amount
        {
            get => _amount;
           init => _amount = value;
        }

        public DateTime DueDate
        {
            get => _dueDate;
           init => _dueDate = value;
        }

        public bool IsPaid
        {
            get => _isPaid;
           init => _isPaid = value;
        }

        public DateTime PaidAt
        {
            get => _paidAt;
           init => _paidAt = value;
        }
    }
}
