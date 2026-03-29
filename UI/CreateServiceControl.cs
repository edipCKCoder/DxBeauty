using DevExpress.DashboardCommon.Native;
using DevExpress.XtraEditors.DXErrorProvider;
using DXBeauty.Data;
using DXBeauty.Entities;
using System;
using System.Configuration;


namespace DXBeauty.UI
{
    public partial class CreateServiceControl : DevExpress.XtraEditors.XtraUserControl
    {

        public event Action<Service> ServiceSaved;
        private readonly ServiceRepository repo;
        private readonly string connectionString;
        private DXValidationProvider dxValidationProvider;
        public CreateServiceControl()
        {
            InitializeComponent();
            SetupValidations();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            repo = new ServiceRepository(connectionString);
        }


        private void createServiceButton_Click(object sender, EventArgs e)
        {
            // EKLENEN KISIM: Kuralları kontrol et! Eğer hatalı/boş alan varsa kaydetmeyi durdur.
            if (!dxValidationProvider.Validate())
            {
                // Boş kutuların yanında otomatik kırmızı ikon çıkacak. İşlemi iptal ediyoruz.
                return;
            }
            var service = new Service
                {
                    ServiceName = serviceName.Text,
                    Description = serviceDescription.Text,
                    DefaultPrice = calcDefaultPrice.Value,
                    IsActive = isActive.Checked,
                };

                // DB insert burada olabilir
                repo.Insert(service);
                ServiceSaved?.Invoke(service);
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
            dxValidationProvider.SetValidationRule(serviceName, notEmptyRule); // Ad zorunlu
            dxValidationProvider.SetValidationRule(serviceDescription, notEmptyRule); // Soyad zorunlu
            dxValidationProvider.SetValidationRule(calcDefaultPrice, notEmptyRule); // Telefon zorunlu

            
        }
    }
}
