using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Utils.Colors;
using DevExpress.XtraScheduler;
namespace DXBeauty.Entities
{
    public class Personnel
    {
        // --- PRIVATE BACKING FIELDS ---
        private int _personnelId;
        private string _fullName;
        private int _colorId;
        private bool _isActive;
        private string _phoneNumber;
     


        // --- DAPPER İÇİN PARAMETRESİZ CONSTRUCTOR ---
        protected Personnel() { }

        // --- YENİ KAYIT İÇİN CONSTRUCTOR ---
        public Personnel(string fullName, int colorId = 0)
        {
            FullName = fullName;
            ColorId = colorId;
            IsActive = true;
        }

        // --- PROPERTIES ---

        public int PersonnelId
        {
            get => _personnelId;
            private set => _personnelId = value;
        }

        public string FullName
        {
            get => _fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Personel adı boş bırakılamaz.");
                _fullName = value.Trim();
            }
        }

        public int ColorId
        {
            get => _colorId;
            private set => _colorId = value;
        }


        public bool IsActive
        {
            get => _isActive;
            private set => _isActive = value;
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            private set => _phoneNumber = value?.Trim();
        }

        // --- YARDIMCI METOTLAR ---
        public void UpdateContactInfo(string newPhone) => PhoneNumber = newPhone;
        public void Deactivate() => IsActive = false;
        public void Activate() => IsActive = true;
    }
}
