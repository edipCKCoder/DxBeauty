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
        private decimal _totalPrice;
        private string _status; // active, completed, cancelled

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

        public decimal TotalPrice
        {
            get => _totalPrice;
            set => _totalPrice = value;
        }

        public string Status
        {
            get => _status;
            set => _status = value?.Trim();
        }
      
    }

}
