using DevExpress.XtraEditors.Filtering.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXBeauty.Entities
{
    public class Customer
    {
        private int _customerId;
        private string _firstName;
        private string _lastName;
        private string _phone;
        private string _email;
        private string _address;
        private DateTime? _birthDay;
        private DateTime _createdDate;

        public int CustomerId
        {
            get => _customerId;
            private set => _customerId = value; // ID dışarıdan değiştirilemez
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("İsim boş olamaz.");
                _firstName = value.Trim();
            }
        }

        public string LastName
        {
            get => _lastName;
            set => _lastName = value?.Trim();
        }

        // Hesaplanmış özellik (read-only)
        public string FullName => $"{FirstName} {LastName}";

        public string Phone
        {
            get => _phone;
            set
            {
                if (value?.Length < 10)
                    throw new ArgumentException("Telefon numarası eksik.");
                _phone = value;
            }
        }

        public string Email
        {
            get => _email;
            set => _email = value?.Trim();
        }

        public string Address
        {
            get => _address;
            set => _address = value?.Trim();
        }

        public DateTime? Birthday
        {
            get => _birthDay;
            set => _birthDay = value;
        }
        
        public DateTime CreatedDate
        {
            get => _createdDate;
            set => _createdDate = DateTime.Now; // Oluşturulma tarihi otomatik atanır
        }
    }

}
