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
             set => _servicePackageId = value;
        }

        public int ServiceId
        {
            get => _serviceId;
             set => _serviceId = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int SessionCount
        {
            get => _sessionCount;
             set => _sessionCount = value;
        }

        public decimal TotalPrice
        {
            get => _totalPrice;
             set => _totalPrice = value;
        }

        public bool IsInstallmentAllowed
        {
            get => _isInstallmentAllowed;
             set => _isInstallmentAllowed = value;
        }

        public bool IsActive
        {
            get => _isActive;
             set => _isActive = value;
        }
    }
}
