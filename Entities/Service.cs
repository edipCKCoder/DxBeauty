using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXBeauty.Entities
{
    public class Service
    {
        private int _serviceId;
        private string _name;
        private string _description;
        private bool _isActive;
        private decimal _defaultPrice;
        private string _severity;
        

        public int ServiceId
        {
            get => _serviceId;
            set  => _serviceId = value;
        }

        public string ServiceName
        {
            get => _name;
            set
            {
                try
                {
                    _name = value.Trim();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
           
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
        
        public decimal DefaultPrice
        {
            get => _defaultPrice;
            set => _defaultPrice = value;
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
