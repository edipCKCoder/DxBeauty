using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXBeauty.Entities
{
    public class Service
    {
        private int _serviceId;
        private string _name;
        private string _description;
        private bool _isActive;

        // HTML Template doğrudan bu ismi görecektir
        private string _severity;

        public int ServiceId
        {
            get => _serviceId;
            private set => _serviceId = value;
        }

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Hizmet adı boş olamaz.");
                _name = value.Trim();
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Hizmet açıklaması boş olamaz.");
                _description = value.Trim();
            }
        }
    
        public bool IsActive
        { 
            get => _isActive;
            set => _isActive = value;
        }

        public string Severity
        {
            get => _severity = IsActive ? "apply_img" : "cancel_img";
            set => _severity = value;
        }
        
    }

}
