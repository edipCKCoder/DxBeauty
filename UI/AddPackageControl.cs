using DevExpress.XtraEditors;
using DXBeauty.Data;
using DXBeauty.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
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
        }


        private void savePackageButton_Click(object sender, EventArgs e)
        {
            // 1. İsim Boş mu?
            if (string.IsNullOrWhiteSpace(packageName.Text))
            {
                MessageBox.Show("Paket adı boş olamaz!");
                return;
            }

            // 2. Sayısal Değerlerin Kontrolü
            if (sessionCount.Value <= 0)
            {
                MessageBox.Show("Seans sayısı 0'dan büyük olmalıdır.");
                return;
            }

            // 3. Fiyat Kontrolü (TryParse ile)
            if (!decimal.TryParse(totalPrice.Text, out decimal validPrice) || validPrice < 0)
            {
                MessageBox.Show("Geçerli bir toplam fiyat giriniz.");
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
