using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXBeauty.Entities
{
    public class PaymentPlan
    {
        private int _paymentPlanId;
        private int _customerServiceId;
        private int _sequenceNumber;
        private decimal _amount;
        private DateTime _dueDate;
        private bool _isPaid;
        private DateTime? _paidAt;
        private decimal _paidAmount;
        public int PaymentPlanId
        {
            get => _paymentPlanId;
           init => _paymentPlanId = value;
        }

        public int CustomerServiceId
        {
            get => _customerServiceId;
           init => _customerServiceId = value;
        }

        public int SequenceNumber
        {
            get => _sequenceNumber;
           init => _sequenceNumber = value;
        }

        public decimal Amount
        {
            get => _amount;
           init => _amount = value;
        }

        public decimal PaidAmount
        {
            get => _paidAmount;
           init => _paidAmount = value;
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

        public DateTime? PaidAt
        {
            get => _paidAt;
           init => _paidAt = value;
        }
    }
}
