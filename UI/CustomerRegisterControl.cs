using DXBeauty.Data;
using DXBeauty.Entities;
using System;
using System.Configuration;

namespace DXBeauty.UI
{
    public partial class CustomerRegisterControl : DevExpress.XtraEditors.XtraUserControl
    {

        public event Action <Customer> CustomerSaved;
        public Customer EditingCustomer { get; private set; }
        public bool IsEditMode => EditingCustomer != null;

        // DevExpress doğrulama sağlayıcısı
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider;

        public CustomerRegisterControl()
        {
            InitializeComponent();

            SetupValidations();

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsEditMode)
            {
                UpdateCustomer();
            }
            else
            {
                InsertCustomer();
            }           
        }

        public void LoadCustomer(Customer customer)
        {
            EditingCustomer = customer;

            nameBox.Text = customer.FirstName;
            surnameBox.Text = customer.LastName;
            phoneBox.Text = customer.PhoneNumber;
            emailBox.Text = customer.Email;
            addressBox.Text = customer.Address;
            birthdayBox.DateTime = customer.Birthday.HasValue ? customer.Birthday.Value : DateTime.MinValue;
        }

        private void UpdateCustomer()
        {
            // EKLENEN KISIM: Kuralları kontrol et! Eğer hatalı/boş alan varsa kaydetmeyi durdur.
            if (!dxValidationProvider.Validate())
            {
                // Boş kutuların yanında otomatik kırmızı ikon çıkacak. İşlemi iptal ediyoruz.
                return;
            }

            EditingCustomer.FirstName = nameBox.Text;
            EditingCustomer.LastName = surnameBox.Text;
            EditingCustomer.PhoneNumber = phoneBox.Text;
            EditingCustomer.Email = emailBox.Text;
            EditingCustomer.Address = addressBox.Text;
            EditingCustomer.Birthday = birthdayBox.DateTime;

            CustomerSaved?.Invoke(EditingCustomer);
        }

        private void InsertCustomer()
        {

            // EKLENEN KISIM: Kuralları kontrol et! Eğer hatalı/boş alan varsa kaydetmeyi durdur.
            if (!dxValidationProvider.Validate())
            {
                // Boş kutuların yanında otomatik kırmızı ikon çıkacak. İşlemi iptal ediyoruz.
                return;
            }

            Customer customer = new Customer
            {
                FirstName = nameBox.Text,
                LastName = surnameBox.Text,
                PhoneNumber = phoneBox.Text,
                Email = emailBox.Text,
                Address = addressBox.Text,
                Birthday = birthdayBox.DateTime,
            };

            CustomerSaved?.Invoke(customer);
        }

        private void SetupValidations()
        {
            dxValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider();

            // 1. KURAL: Alan Boş Bırakılamaz (Zorunlu Alan Kuralı)
            var notEmptyRule = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            notEmptyRule.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            notEmptyRule.ErrorText = "Bu alan boş bırakılamaz!"; // Çarpı ikonunun üzerine gelince yazacak yazı
            notEmptyRule.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical; // Kırmızı ikon çıkarır

            // Hangi kutucuklar "Boş Bırakılamaz" olacaksa onlara bu kuralı atıyoruz:
            dxValidationProvider.SetValidationRule(nameBox, notEmptyRule); // Ad zorunlu
            dxValidationProvider.SetValidationRule(surnameBox, notEmptyRule); // Soyad zorunlu
            dxValidationProvider.SetValidationRule(phoneBox, notEmptyRule); // Telefon zorunlu

            // 2. KURAL (Opsiyonel): E-Posta formatı kontrolü
            var emailRule = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            emailRule.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.Contains;
            emailRule.Value1 = "@";
            emailRule.ErrorText = "Lütfen geçerli bir e-posta adresi giriniz!";
            emailRule.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning; // Sarı ikon çıkarır (zorunlu değil ama uyarır)

            // E-Posta kutusu boş değilse format kontrolü yap
            dxValidationProvider.SetValidationRule(emailBox, emailRule);
        }
    }
}
