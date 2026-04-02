using DevExpress.LookAndFeel;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils;
using DevExpress.Utils.Helpers;
using DevExpress.XtraEditors;

using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Layout;
using DevExpress.XtraGrid.Views.Tile;
using DevExpress.XtraGrid.Views.WinExplorer;
using DXBeauty.Data;
using DXBeauty.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXBeauty.UI
{
    public partial class ServicesControl : DevExpress.XtraEditors.XtraUserControl
    {

        private readonly ServiceRepository serviceRepo;

        private readonly ServicePackageRepository servicePackageRepo;

        private readonly string connectionString;

        private bool isEditMode = true;

        public ServicesControl()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SetupModernServicesList();
            serviceRepo = new ServiceRepository(connectionString);
            servicePackageRepo = new ServicePackageRepository(connectionString);

        }

        private void ServicesControl_Load(object sender, EventArgs e)
        {


            LoadServiceData();


        }


        private void LoadServiceData()
        {

            var services = serviceRepo.GetAll();

            gridControlServices.DataSource = services;

        }



        // ⚙️ TILEVIEW DESTEKLİ PAKET YÜKLEYİCİ
        private async Task LoadServicePackagesAsync(int serviceId)
        {
            try
            {
                // 1. Paketleri Asenkron Çek
                var servicePackages = await Task.Run(() => servicePackageRepo.GetByService(serviceId));

                // 2. Yeni GridControl (TileView) içine bas!
                gridControlPackages.DataSource = servicePackages;

                // 3. (Opsiyonel ama Rasyonel) TileView Görsel Ayarları 
                // Bunu Designer'dan da yapabilirsiniz ama kodla yapmak her zaman garantidir
                if (gridControlPackages.MainView is TileView tileView)
                {
                    tileView.OptionsTiles.Orientation = Orientation.Horizontal;
                    tileView.OptionsTiles.RowCount = 0; // Dinamik satır
                    tileView.OptionsTiles.ItemSize = new Size(250, 150); // Kart boyutu
                    tileView.OptionsTiles.Padding = new Padding(10);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Paketler yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SetupModernServicesList()
        {
            //  KRİTİK GÖRSEL AYARLAR: Hantallığı silen rasyonel dokunuşlar
            gridViewServices.OptionsView.ShowGroupPanel = false;   // Grup panelini gizle
            gridViewServices.OptionsView.ShowIndicator = false;    // Sol seçim çubuğunu gizle
            gridViewServices.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False; // Yatay çizgileri kaldır
            gridViewServices.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;   // Dikey çizgileri kaldır
            gridViewServices.OptionsView.EnableAppearanceEvenRow = true; // Tek/Çift satır renklendirmeyi aç (Taranabilirliği artırır)

            //// KOLON AYARLARI: Sadece ismi göster
            //gridColumnServiceName.FieldName = "ServiceName";
            //gridColumnServiceName.Caption = "Hizmet Menüsü"; // Modern bir başlık
            //gridColumnServiceName.Visible = true;
            //gridColumnServiceName.OptionsColumn.AllowEdit = false; // Kullanıcı grid üzerinden düzenleme yapamasın
        }

        private async void gridViewServices_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            // Eski "LayoutView" yerine artık yeni GridView'umuzu (gridViewServices) kullanıyoruz
            var selectedService = gridViewServices.GetFocusedRow() as Service;

            if (selectedService != null)
            {
                // 1. Dinamik Başlık (Kullanıcı Nerede Olduğunu Bilsin)
                groupControlPackages.Text = $"{selectedService.ServiceName.ToUpper()} Satış Paketleri";

                // 2. Paketleri Yükle
                await LoadServicePackagesAsync(selectedService.ServiceId);
            }
            else
            {
                // Seçim boşsa ekranı temizle
                gridControlPackages.DataSource = null;
                groupControlPackages.Text = "Lütfen Bir Hizmet Seçiniz";
            }
        }

        private void tileView1_ContextButtonClick(object sender, ContextItemClickEventArgs e)
        {
            // Hangi butona tıklandığını kontrol et (ileride "Sil" butonu da ekleyebilirsiniz)
            if (e.Item.Name == "btnEditPackage")
            {
                // ⚠️ 1. KRİTİK HAMLE: e.DataItem'ı doğrudan veriye değil, "Görsel Kart" nesnesine çeviriyoruz.
                var tileItem = e.DataItem as DevExpress.XtraGrid.Views.Tile.TileViewItem;
                if (tileItem == null) return;

                var clickedPackage = tileViewPackages.GetRow(tileItem.RowHandle) as ServicePackage;

                if (clickedPackage != null)
                {
                    // O an seçili olan ana hizmeti de alıyoruz (Lazer Epilasyon vs.)
                    Service selectedService = gridViewServices.GetFocusedRow() as Service;

                    // 2. Düzenleme formunu EDİT MODUNDA aç
                    // ⚠️ DİKKAT: AddPackageControl formunuza hem hizmeti hem de tıklanan paketi gönderiyoruz.
                    AddPackageControl editControl = new AddPackageControl(selectedService, clickedPackage);
                    editControl.Dock = DockStyle.Fill;

                    XtraForm popup = new XtraForm();
                    popup.StartPosition = FormStartPosition.CenterScreen;
                    popup.Text = $"{clickedPackage.Name} - Paketi Düzenle"; // Dinamik Başlık
                    popup.ClientSize = editControl.Size;
                    popup.Controls.Add(editControl);

                    // 3. Güncelleme bittiğinde ekranı ASENKRON yenile
                    editControl.ServicePackageSaved += async (updatedPackage) =>
                    {
                        popup.Close();
                        // Sadece sağ tarafı (TileView) yeniden yükle, tüm formu değil!
                        await LoadServicePackagesAsync(selectedService.ServiceId);
                    };

                    popup.ShowDialog();
                }
            }


            // 💡 RASYONEL GÜVENLİK: Silme Butonuna tıklandığında çalışır
            if (e.Item.Name == "btnDeletePackage")
            {
                var tileItem = e.DataItem as DevExpress.XtraGrid.Views.Tile.TileViewItem;
                if (tileItem == null) return;

                var clickedPackage = tileViewPackages.GetRow(tileItem.RowHandle) as ServicePackage;

                if (clickedPackage != null)
                {
                    // 1. Rasyonel Onay (Kullanıcı yanlışlıkla basmış olabilir)
                    DialogResult result = XtraMessageBox.Show(
                        $"'{clickedPackage.Name}' isimli paketi katalogdan kalıcı olarak silmek istediğinize emin misiniz?",
                        "Silme Onayı",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            // 2. Dapper üzerinden silme metodunuzu çağırın
                            // ÖNEMLİ: Bu metot veritabanında "DELETE FROM service_packages WHERE..." çalıştırmalıdır.
                            bool success = servicePackageRepo.Delete(clickedPackage.ServicePackageId);

                            if (success)
                            {
                                // Başarılıysa ekranı titremeden, sadece o hizmetin paketlerini çekecek şekilde yenile
                                Service selectedService = gridViewServices.GetFocusedRow() as Service;
                                LoadServicePackagesAsync(selectedService.ServiceId);
                            }
                        }
                        // ⚠️ KRİTİK GÜVENLİK KALKANI: PostgreSQL İlişkisel Bütünlük (Foreign Key) Hatası Yakalama
                        // Eğer PostgreSQL "23503" kodunu dönerse, bu veri başka bir tabloda kullanılıyor demektir!
                        catch (Npgsql.PostgresException ex) when (ex.SqlState == "23503")
                        {
                            XtraMessageBox.Show(
                                "GÜVENLİK İHLALİ: Bu paket daha önce müşterilere satılmış veya randevularda kullanılmış!\n\n" +
                                "Geçmiş finansal ve operasyonel kayıtların bozulmaması için bu paketi silemezsiniz.\n" +
                                "Bunun yerine paketi düzenleyerek 'Aktif' durumunu kapatmayı (Pasife almayı) tercih ediniz.",
                                "Silme İşlemi Reddedildi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                        catch (Exception ex)
                        {
                            // Diğer olası veritabanı bağlantı/sözdizimi hataları
                            XtraMessageBox.Show("Silme işlemi sırasında bir hata oluştu: " + ex.Message, "Kritik Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
        private void CreateService_Click(object sender, EventArgs e)
        {
            CreateServiceControl createService = new UI.CreateServiceControl();
            createService.Dock = DockStyle.Fill;

            XtraForm popup = new XtraForm();
            popup.Text = "Yeni Hizmet Ekle"; // Form başlığını standartlaştırın
            popup.ClientSize = createService.Size;
            popup.Controls.Add(createService);
            popup.StartPosition = FormStartPosition.CenterScreen;

            // ❗ KRİTİK DEĞİŞİKLİK: Kayıt başarılı olduğunda listeyi asenkron güncelle
            createService.ServiceSaved += async (service) =>
            {
                popup.Close();

                // Veritabanından güncel hizmetleri çek ve sol Grid'i tazele
                var services = await Task.Run(() => serviceRepo.GetAll());
                gridControlServices.DataSource = services;

                // Opsiyonel: Yeni eklenen hizmeti Grid üzerinde otomatik olarak seçili hale getirebilirsiniz.
            };

            // Show() yerine ShowDialog() kullanmak, işlem bitene kadar ana ekranı kilitler. Bu veri tutarlılığı için en rasyonel yaklaşımdır.
            popup.ShowDialog();
        }

        private void addPackageButton_Click(object sender, EventArgs e)
        {
            // ⚠️ ESKİ layoutView1 YERİNE YENİ gridViewServices KULLANIYORUZ
            Service selectedService = gridViewServices.GetFocusedRow() as Service;

            // Hata Önleme: Eğer soldan bir hizmet seçilmemişse işlemi durdur
            if (selectedService == null)
            {
                XtraMessageBox.Show("Lütfen önce sol menüden paket eklemek istediğiniz hizmeti (Örn: Lazer Epilasyon) seçiniz.",
                                    "Hizmet Seçilmedi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedService.IsActive == false)
            {
                XtraMessageBox.Show("Lütfen aktif bir hizmet seçiniz. Aktif hizmetlerde paket ekleyebilirsiniz.",
                    "Hizmet Seçilmedi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AddPackageControl addPackageControl = new AddPackageControl(selectedService);
            addPackageControl.Dock = DockStyle.Fill;

            XtraForm popup = new XtraForm();
            popup.Text = $"{selectedService.ServiceName} - Yeni Paket Ekle"; // Dinamik Başlık (UX)
            popup.ClientSize = addPackageControl.Size;
            popup.Controls.Add(addPackageControl);
            popup.StartPosition = FormStartPosition.CenterScreen;

            // ❗ KRİTİK DEĞİŞİKLİK: Kayıt başarılı olduğunda TileView'u asenkron güncelle
            addPackageControl.ServicePackageSaved += async (package) =>
            {
                popup.Close();

                // Yeni kurduğumuz asenkron TileView yükleyici metodumuzu çağırıyoruz
                await LoadServicePackagesAsync(selectedService.ServiceId);
            };

            popup.ShowDialog();
        }

        private void tileViewPackages_ContextButtonCustomize(object sender, TileViewContextButtonCustomizeEventArgs e)
        {
            if (e.Item.Name == "chkActiveStatus")
            {
                // O an çizilen kartın asıl verisini yakala
                var package = tileViewPackages.GetRow(e.RowHandle) as ServicePackage;

                if (package != null)
                {
                    var chkItem = e.Item as DevExpress.Utils.CheckContextButton;
                    if (chkItem != null)
                    {
                        // Veritabanındaki değere göre butonu Açık (True) veya Kapalı (False) yap
                        // Not: Sizin modelinizdeki kolon adı "IsActive" veya benzeri olmalı.
                        chkItem.Checked = package.IsActive;

                        // Farenin ucuyla gelince çıkacak ipucu
                        chkItem.ToolTip = package.IsActive ? "Katalogda GÖRÜNÜYOR (Aktif)" : "Katalogdan GİZLENDİ (Pasif)";
                    }
                }
            }
        }

        private void gridViewServices_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            Service selectedService = gridViewServices.GetFocusedRow() as Service;
            if (selectedService != null) 
            {
                selectedService.IsActive = (bool)gridViewServices.GetRowCellValue(e.RowHandle, "IsActive");
                try
                {
                    serviceRepo.Update(selectedService);
                }
                catch (Exception)
                {

                    XtraMessageBox.Show("Hizmet Güncellenirken Hata oluştu.",
                    "Hizmet Güncellenemedi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
            }
        }
    }

}
