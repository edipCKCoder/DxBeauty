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
        private decimal _price;
        private int _durationMinutes;

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

        public decimal Price
        {
            get => _price;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Fiyat negatif olamaz.");
                _price = value;
            }
        }

        public int DurationMinutes
        {
            get => _durationMinutes;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Süre sıfırdan büyük olmalı.");
                _durationMinutes = value;
            }
        }
    }

}
