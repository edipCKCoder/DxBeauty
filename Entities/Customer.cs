using DevExpress.XtraEditors.Filtering.Templates;
using System;
using System.ComponentModel;
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
        private string _phoneNumber;
        private string _email;
        private string _address;
        private DateTime? _birthDay;
        private DateTime _createdDate;

        // Hesaplanmış özellik (read-only)
        [DisplayName("İsim Soyisim")] // Grid'de bu isim görünür 
        public string FullName => $"{FirstName} {LastName}";


        public int CustomerId
        {
            get => _customerId;
            private set => _customerId = value; // ID dışarıdan değiştirilemez
        }
        [DisplayName("İsim")]
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
        [DisplayName("Soyisim")]
        public string LastName
        {
            get => _lastName;
            set => _lastName = value?.Trim();
        }


        [DisplayName("Telefon Numarası")]
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                if (value?.Length < 10)
                    throw new ArgumentException("Telefon numarası eksik.");
                _phoneNumber = value;
            }
        }
        [DisplayName("E-Posta")]
        public string Email
        {
            get => _email;
            set => _email = value?.Trim();
        }
        [DisplayName("Adres")]
        public string Address
        {
            get => _address;
            set => _address = value?.Trim();
        }
        [DisplayName("Doğum Tarihi")]
        public DateTime? Birthday
        {
            get => _birthDay;
            set => _birthDay = value;
        }
        [DisplayName("Oluşturulma Tarihi")]
        public DateTime CreatedDate
        {
            get => _createdDate;
            set => _createdDate = value; // Oluşturulma tarihi otomatik atanır
        }
    }

}
