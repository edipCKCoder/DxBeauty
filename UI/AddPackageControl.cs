using DevExpress.DataAccess.Native.Json;
using DevExpress.Utils.Menu;
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
using System.Xml.Linq;

namespace DXBeauty.UI
{
    public partial class AddPackageControl : DevExpress.XtraEditors.XtraUserControl
    {

        public event Action<ServicePackage> ServicePackageSaved;
        private readonly ServicePackageRepository repo;
        private readonly ServiceRepository service_Repo;
        private readonly string connectionString;
        private Service _SelectedService;
        //  Sınıf seviyesinde, düzenleme modunda olup olmadığımızı tutacak değişkenler
        private bool _isEditMode = false;
        private ServicePackage _packageToEdit = null;

        public AddPackageControl()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            service_Repo = new ServiceRepository(connectionString);
            FillDropDownMenu();
            _SelectedService = new Service();
            layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            dropDownButton1.Visible = true;
            repo = new ServicePackageRepository(connectionString);
            

        }
        //  YENİ: DÜZENLEME (Update) için kullanılacak kurucu metot
        public AddPackageControl(Service selectedService, ServicePackage packageToEdit)
        {
            InitializeComponent();
            layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            dropDownButton1.Visible = false;
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            repo = new ServicePackageRepository(connectionString);
            _isEditMode = true;
            _packageToEdit = packageToEdit;

            // 1. Kutuları eski verilerle doldur
            packageName.Text = packageToEdit.Name;
            sessionCount.Value = packageToEdit.SessionCount;
            totalPrice.Value = packageToEdit.TotalPrice;
            isActiveCheck.Checked = packageToEdit.IsActive;
            isInstallmentAllowed.Checked = packageToEdit.IsInstallmentAllowed;

            // 2. Buton metnini mantıksal olarak değiştir
            savePackageButton.Text = "Değişiklikleri Kaydet";
        }

        public AddPackageControl(Service service)
        {
            InitializeComponent();
            layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            dropDownButton1.Visible = false;

            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            repo = new ServicePackageRepository(connectionString);
            
            _SelectedService = service;
            Root.Text = _SelectedService.ServiceName;
        }

    

        private void savePackageButton_Click(object sender, EventArgs e)
        {

            if (_isEditMode)
            {
                // ⚙️ UPDATE İŞLEMİ
                _packageToEdit.Name = packageName.Text;
                _packageToEdit.SessionCount = (int)sessionCount.Value;
                _packageToEdit.TotalPrice = totalPrice.Value;
                _packageToEdit.IsActive = isActiveCheck.Checked;
                _packageToEdit.IsInstallmentAllowed = isInstallmentAllowed.Checked;
                repo.Update(_packageToEdit); // Dapper update metodunuz

                // İşlemin bittiğini ana forma bildir (TileView yenilenecek)
                ServicePackageSaved?.Invoke(_packageToEdit);
            }
            else
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
                try
                {
                    repo.Insert(servicePackage);
                }
                catch (Exception ex)
                {
                    // Burada ileride hatayı bir .txt dosyasına (Log) kaydedeceğiz.
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                        "İşlem sırasında beklenmeyen bir hata oluştu.\n\nDetay: " + ex.Message,
                        "Sistem Uyarı",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                DevExpress.XtraEditors.XtraMessageBox.Show("Satıl paketi başarıyla kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ServicePackageSaved?.Invoke(servicePackage);
                this.ParentForm.Close();
            }

            
            
        }

        public void FillDropDownMenu()
        {
            // 1. Repository'den verileri çek (Örn: Hizmet Listesi)
            var services = service_Repo.GetAll();

            // 2. Bir DXPopupMenu oluştur
            DXPopupMenu menu = new DXPopupMenu();

            foreach (var service in services)
            {
                // 3. Her veri için bir menü öğesi (DXMenuItem) oluştur
                DXMenuItem menuItem = new DXMenuItem
                {
                    Caption = service.ServiceName,
                    Tag = service.ServiceId // ID değerini Tag içinde saklayabiliriz
                };

                // 4. Tıklama olayını (Event) bağla
                menuItem.Click += MenuItem_Click;

                // 5. Menüye ekle
                menu.Items.Add(menuItem);
            }

            // 💡 KRİTİK NOKTA: Oluşturulan menüyü DropDownButton'a ata
            dropDownButton1.DropDownControl = menu;
        }

        // Menü öğesine tıklandığında çalışacak metod
        private void MenuItem_Click(object sender, EventArgs e)
        {
            DXMenuItem clickedItem = sender as DXMenuItem;
            if (clickedItem != null)
            {
                int selectedId = (int)clickedItem.Tag;

                // 💡 Artık _SelectedService null olmadığı için bu satır hata vermeyecek
                _SelectedService.ServiceId = selectedId;
                dropDownButton1.Text = clickedItem.Caption;
                Root.Text = clickedItem.Caption; // Root.Text'i güncellemek istersen diye ismi de alıyoruz
                //XtraMessageBox.Show($"Seçilen ID: {selectedId} - İsim: {clickedItem.Caption}");
            }
        }
    }
}
