using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXBeauty.Entities
{
    public class ServicePackage
    {
        private int _servicePackageId;
        private int _serviceId;
        private string _name;
        private int _sessionCount;
        private decimal _totalPrice;
        private bool _isInstallmentAllowed;
        private bool _isActive; 

        public int ServicePackageId
        {
            get => _servicePackageId;
            private set => _servicePackageId = value;
        }

        public int ServiceId
        {
            get => _serviceId;
            private set => _serviceId = value;
        }

        public string Name
        {
            get => _name;
            private set => _name = value;
        }

        public int SessionCount
        {
            get => _sessionCount;
            private set => _sessionCount = value;
        }

        public decimal TotalPrice
        {
            get => _totalPrice;
            private set => _totalPrice = value;
        }

        public bool IsInstallmentAllowed
        {
            get => _isInstallmentAllowed;
            private set => _isInstallmentAllowed = value;
        }

        public bool IsActive
        {
            get => _isActive;
            private set => _isActive = value;
        }
    }
}
