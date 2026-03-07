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
        private int _servicePackageId;
        private DateTime _startDate;
        private int _remainingSessions;
        private decimal _remainingDebt;
        private decimal _paidAmount;
        private StatusType _status; // active, completed, cancelled
        private string _packageName;
        private decimal _totalPrice;
        public enum StatusType
        {
            None = 0,
            Active = 1,
            Suspended = 2,
            Continued = 3,
            Completed = 4,
            Cancelled = 5
        }
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

        public int ServicePackageId
        {
            get => _servicePackageId;
            set => _servicePackageId = value;
        }

        public string Name
        {
            get => _packageName;
            set => _packageName = value?.Trim();
        }

        public DateTime StartDate
        {
            get => _startDate;
            set => _startDate = value == default ? DateTime.Now : value;
        }

        public int RemainingSessions
        {
            get => _remainingSessions;
            set => _remainingSessions = value;
        }

        public decimal RemainingDebt
        {
            get => _remainingDebt;
            set => _remainingDebt = value;
        }

        public decimal PaidAmount
        {
            get => _paidAmount;
            set => _paidAmount = value;
        }

        public StatusType Status
        {
            get => _status;
            set => _status = value;
        }

        public decimal TotalPrice
        {
            get => _totalPrice;
            set => _totalPrice = value;
        }
      
    }

}
