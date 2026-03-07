using DevExpress.DataAccess.Native.Json;
using DevExpress.XtraEditors;
using DXBeauty.Data;
using DXBeauty.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXBeauty.UI
{
    public partial class AddPackageControl : DevExpress.XtraEditors.XtraUserControl
    {

        public event Action<ServicePackage> ServicePackageSaved;
        private readonly ServicePackageRepository repo;
        private readonly string connectionString;
        private Service _SelectedService;

        public AddPackageControl(Service service)
        {
            InitializeComponent();

            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            repo = new ServicePackageRepository(connectionString);
            _SelectedService = service;
            Root.Text = _SelectedService.Name;
        }

    

        private void savePackageButton_Click(object sender, EventArgs e)
        {
            string newPrice = totalPrice.Text;
            decimal validPrice = 0;

            // 1. İsim Boş mu?
            if (string.IsNullOrWhiteSpace(packageName.Text))
            {
                MessageBox.Show("Paket adı boş olamaz!");
                return;
            }

            // 2. Sayısal Değerlerin Kontrolü
            if (sessionCount.Value < 0)
            {
                MessageBox.Show("Seans sayısı 0'dan büyük olmalıdır.");
                return;
            }

            try
            {
                validPrice = decimal.Parse(newPrice, NumberStyles.Currency, new CultureInfo("tr-TR"));
            }
            catch (Exception)
            {
                MessageBox.Show("Gecersiz fiyat girdiniz.");
                return;
            }   

            // Tüm kontroller geçildiyse nesneyi oluştur
            var servicePackage = new ServicePackage
            {
                ServiceId = _SelectedService.ServiceId,
                Name = packageName.Text.Trim(),
                IsActive = isActiveCheck.Checked,
                IsInstallmentAllowed = isInstallmentAllowed.Checked,
                SessionCount = (int)sessionCount.Value,
                TotalPrice = validPrice
            };


            //Db Insert
            
            repo.Insert(servicePackage);

            ServicePackageSaved?.Invoke(servicePackage);
            this.ParentForm.Close();
            
        }
    }
}
