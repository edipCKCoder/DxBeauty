using DevExpress.DataAccess.UI.Native.Sql.DataConnectionControls;
using DevExpress.Utils;
using DevExpress.Utils.DragDrop;
using DevExpress.Utils.Extensions;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Tile;
using DevExpress.XtraGrid.Views.Tile.ViewInfo;
using DXBeauty.Data;
using DXBeauty.Entities;
using DXBeauty.Enums;
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
using static DXBeauty.Entities.CustomerService;
namespace DXBeauty.UI
{
    public partial class CustomerPackagesControl : DevExpress.XtraEditors.XtraUserControl
    {
        private readonly string _connectionString;
        private ServiceRepository _serviceRepository;
        private CustomerRepository _customerRepository;
        private ServicePackageRepository _servicePackageRepository;
        private CustomerServiceRepository _customerServiceRepository;
        public static CustomerPackagesControl Instance { get; private set; }
        private DevExpress.Utils.Behaviors.BehaviorManager _dragDropManager;

        public CustomerPackagesControl()
        {
            InitializeComponent();
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _dragDropManager = new DevExpress.Utils.Behaviors.BehaviorManager();
            Instance = this;

            LoadData();

            // 2. Kaynak View'unuza (paketlerin olduğu TileView) sürükleme özelliği ekliyoruz
            _dragDropManager.Attach<DevExpress.Utils.DragDrop.DragDropBehavior>(tileView1, sourceBehavior =>
            {

                sourceBehavior.Properties.AllowDrop = true;
                sourceBehavior.Properties.InsertIndicatorVisible = true;
                sourceBehavior.Properties.PreviewVisible = true;

                sourceBehavior.DragOver += sourceBehavior_DragOver;

            });

            // 3. HEDEF (Target) Ayarı: Müşteri paketlerinin ekleneceği View
            // ÖNEMLİ: GridControl'ün kendisine değil, içindeki View'a (örneğin gridView1) eklemeliyiz.
            var targetView = customerPackageGridControl.MainView;

            _dragDropManager.Attach<DevExpress.Utils.DragDrop.DragDropBehavior>(targetView, targetBehavior =>
            {

                targetBehavior.Properties.AllowDrag = true;
                targetBehavior.Properties.AllowDrop = true;
                targetBehavior.Properties.InsertIndicatorVisible = true;
                targetBehavior.Properties.PreviewVisible = true;

                targetBehavior.DragDrop += targetBehavior_DragDrop;
            });
        }

        private void targetBehavior_DragDrop(object sender, DragDropEventArgs e)
        {

            if (sluCustomerEdit.EditValue == null)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Lütfen önce bir müşteri seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
                return;
            }

            int[] draggedPackage = e.Data as int[];

            var droppedPackage = tileView1.GetRow(draggedPackage[0]) as ServicePackage;

            if (droppedPackage != null)
            {
                // Eger aktif paketse ekledra)
                if (droppedPackage.IsActive == false)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Paket kullanım dışı lütfen aktif bir paket seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Handled = true;
                    return;
                }

                int customerId = (int)sluCustomerEdit.EditValue;

                // 1. AYNI PAKET KONTROLÜ
                // ESKİ KODU SİLİN: (var currentlyCustomerServices = ... foreach(...) kısmı)
                // YERİNE BUNU YAZIN:

                if (!CanCustomerBuyPackage(customerId, droppedPackage.ServicePackageId))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                        "Bu müşterinin zaten devam eden (seansı veya borcu bitmemiş) aynı paketi var!\n\n" +
                        "Önceki paketin seansları bitmeden ve hesabı kapanmadan yenisi tanımlanamaz.",
                        "İşlem Reddedildi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    e.Handled = true;
                    return;
                }

                // 5. TAKSİTLERİ (BORÇ PLANI) OLUŞTUR VE KAYDET
                XtraForm popup = new XtraForm();
                PaymentPlanWizardControl paymentPlanWizardControl = new PaymentPlanWizardControl(customerId, droppedPackage);

                popup.ClientSize = paymentPlanWizardControl.Size;
                paymentPlanWizardControl.Dock = DockStyle.Fill;
                popup.AddControl(paymentPlanWizardControl);
                popup.StartPosition = FormStartPosition.CenterScreen;
                popup.ShowDialog();

                // 6. EKRANI YENİLE VE BAŞARI MESAJI VER
                LoadCustomerServices(customerId);

            }

            e.Handled = true; // CRITICAL

        }

        private void sourceBehavior_DragOver(object sender, DragOverEventArgs e)
        {
            TileView masterView = e.Source as TileView;

            var servicePackage = masterView.FocusedRowObject as ServicePackage;

            if (servicePackage != null && servicePackage.IsActive)
            {
                e.Default();
            }
            else
            {
                e.Handled = false;
            }
        }

        public void LoadData()
        {

            _customerRepository = new CustomerRepository(_connectionString);
            _serviceRepository = new ServiceRepository(_connectionString);
            _servicePackageRepository = new ServicePackageRepository(_connectionString);
            _customerServiceRepository = new CustomerServiceRepository(_connectionString);



            var activePackages = _servicePackageRepository.GetAll().Where(u => u.IsActive == true).ToList();
            packageGridControl.DataSource = activePackages;


            var costumerList = _customerRepository.GetAll();
            sluCustomerEdit.Properties.DataSource = costumerList;

            sluCustomerEdit.Properties.DisplayMember = "FullName";
            sluCustomerEdit.Properties.ValueMember = "CustomerId";

            if (costumerList.Any())
            {
                sluCustomerEdit.EditValue = costumerList.FirstOrDefault().CustomerId;
            }

            // Sütunların otomatik oluşturulmasını zorlayın
            sluCustomerEdit.Properties.PopulateViewColumns();

            sluCustomerEdit.Properties.View.Columns["CustomerId"].Visible = false;
            sluCustomerEdit.Properties.View.Columns["Birthday"].Visible = false;
            sluCustomerEdit.Properties.View.Columns["Email"].Visible = false;
            sluCustomerEdit.Properties.View.Columns["FirstName"].Visible = false;
            sluCustomerEdit.Properties.View.Columns["LastName"].Visible = false;

        }


        private void sluCustomerEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (sluCustomerEdit.EditValue == null || sluCustomerEdit.EditValue == DBNull.Value) return;
            var customerId = (int)sluCustomerEdit.EditValue;
            customerPackageGridControl.DataSource = _customerServiceRepository.GetByCustomer(customerId);
        }

        private void LoadCustomerServices(int customerId)
        {
            customerPackageGridControl.DataSource = _customerServiceRepository.GetByCustomer(customerId);
        }

        private void tileView1_ItemCustomize_1(object sender, TileViewItemCustomizeEventArgs e)
        {
            TileView view = sender as TileView;

            bool isActive = (bool)view.GetRowCellValue(e.RowHandle, layoutViewColumn5);
            bool isInstallmentAllowed = (bool)view.GetRowCellValue(e.RowHandle, layoutViewColumn4);


            var isActiveElement = e.Item.Elements[4];
            isActiveElement.ImageOptions.SvgImage = isActive
                        ? svgImageCollection1[0]
                        : svgImageCollection1[1];


            var isInstallmentAllowedElement = e.Item.Elements[3];

            isInstallmentAllowedElement.ImageOptions.SvgImage = isInstallmentAllowed
                ? svgImageCollection1[0]
                : svgImageCollection1[1];
        }

        private void tileView1_ContextButtonClick(object sender, ContextItemClickEventArgs e)
        {
            TileViewItem controlItem = e.DataItem as TileViewItem;
            if (e.Item.Name == "contextButton1")
            {
                ServicePackage servicePackage = (ServicePackage)tileView1.GetRow(controlItem.RowHandle);
                servicePackage.IsActive = true;
                _servicePackageRepository.Update(servicePackage);
                tileView1.RefreshRow(controlItem.RowHandle);
                tileView1.LayoutChanged();
            }
            else if (e.Item.Name == "contextButton2")
            {
                ServicePackage servicePackage = (ServicePackage)tileView1.GetRow(controlItem.RowHandle);
                servicePackage.IsActive = false;
                _servicePackageRepository.Update(servicePackage);
                tileView1.RefreshRow(controlItem.RowHandle);
                tileView1.LayoutChanged();
            }
            else if (e.Item.Name == "contextButton3")
            {
                ServicePackage servicePackage = (ServicePackage)tileView1.GetRow(controlItem.RowHandle);
                if (sluCustomerEdit.EditValue == null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Lütfen önce bir müşteri seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                if (servicePackage != null)
                {
                    // Eger aktif paketse ekledra)
                    if (servicePackage.IsActive == false)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Paket kullanım dışı lütfen aktif bir paket seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                int customerId = (int)sluCustomerEdit.EditValue;

                // 4. AYNI PAKET KONTROLÜ

                if (!CanCustomerBuyPackage(customerId, servicePackage.ServicePackageId))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                        "Bu müşterinin zaten devam eden (seansı veya borcu bitmemiş) aynı paketi var!\n\n" +
                        "Önceki paketin seansları bitmeden ve hesabı kapanmadan yenisi tanımlanamaz.",
                        "İşlem Reddedildi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // 5. TAKSİTLERİ (BORÇ PLANI) OLUŞTUR VE KAYDET
                XtraForm popup = new XtraForm();
                PaymentPlanWizardControl paymentPlanWizardControl = new PaymentPlanWizardControl(customerId, servicePackage);

                popup.ClientSize = paymentPlanWizardControl.Size;
                paymentPlanWizardControl.Dock = DockStyle.Fill;
                popup.AddControl(paymentPlanWizardControl);
                popup.StartPosition = FormStartPosition.CenterScreen;
                popup.ShowDialog();

                // 6. EKRANI YENİLE VE BAŞARI MESAJI VER
                LoadCustomerServices(customerId);
                //XtraMessageBox.Show($"Paket müşteriye başarıyla tanımlandı!\nToplam: {newCustomerService.TotalPrice} TL\nTaksit Sayısı: {installmentCount}", "Satış Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        // --
        private void tileView2_ItemCustomize(object sender, TileViewItemCustomizeEventArgs e)
        {
            TileView view = sender as TileView;
            CastumerPackageStatusType statusType = (CastumerPackageStatusType)view.GetRowCellValue(e.RowHandle, layoutViewColumn10);

            var isActiveElement = e.Item.Elements[3];

            switch (statusType)
            {
                case CastumerPackageStatusType.NoPayment:
                    isActiveElement.Text = "Hiç Ödeme Yok";
                    break;
                case CastumerPackageStatusType.PartialPayment:
                    isActiveElement.Text = "Kısmi Ödeme Var";
                    break;
                case CastumerPackageStatusType.NoDebt:
                    isActiveElement.Text = "Tümü Ödendi";
                    break;
                default:
                    break;
            }
        }

        private void tileView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            var updatedPackage = e.Row as ServicePackage;
            if (updatedPackage != null)
            {
                _servicePackageRepository.Update(updatedPackage);
            }
        }


        private void tileView1_EditFormShowing(object sender, DevExpress.XtraGrid.Views.Grid.EditFormShowingEventArgs e)
        {
            ServicePackage servicePackage = (ServicePackage)tileView1.GetRow(e.RowHandle);
            if (servicePackage != null && servicePackage.IsActive)
            {
                e.Allow = true;
            }
            else
            {
                e.Allow = false;
            }
        }

        public void RefreshScreenState()
        {
            // =========================================================
            // 1. TILEVIEW 1 YENİLEMESİ (SOL TARAF - AKTİF PAKETLER)
            // =========================================================
            var activePackages = _servicePackageRepository.GetAll().Where(u => u.IsActive == true).ToList();
            packageGridControl.DataSource = activePackages;
            tileView1.RefreshData();

            // =========================================================
            // 2. MÜŞTERİ LİSTESİ YENİLEMESİ (COMBOBOX)
            // Eğer başka sekmede yeni müşteri eklendiyse buraya da düşsün
            // =========================================================

            // Önce o an ekranda seçili olan müşterinin ID'sini hafızaya alalım (Kullanıcının seçimi kaybolmasın)
            object currentSelectedCustomerId = sluCustomerEdit.EditValue;

            // Veritabanından güncel müşteri listesini çek ve kutuyu güncelle
            var updatedCustomerList = _customerRepository.GetAll();
            sluCustomerEdit.Properties.DataSource = updatedCustomerList;

            // Hafızaya aldığımız seçimi geri yükle
            if (currentSelectedCustomerId != null && currentSelectedCustomerId != DBNull.Value)
            {
                sluCustomerEdit.EditValue = currentSelectedCustomerId;
            }

            // =========================================================
            // 3. TILEVIEW 2 YENİLEMESİ (SAĞ TARAF - MÜŞTERİNİN PAKETLERİ)
            // =========================================================

            // UI'daki kutuda (sluCustomerEdit) gerçekten bir müşteri seçiliyse
            if (sluCustomerEdit.EditValue != null && sluCustomerEdit.EditValue != DBNull.Value)
            {
                // ID'yi direkt arayüzden okuyoruz! (Sınıf değişkenine gerek kalmadı)
                int customerId = (int)sluCustomerEdit.EditValue;

                // O müşterinin güncel paket/tahsilat durumunu veritabanından çek
                var customerServices = _customerServiceRepository.GetByCustomer(customerId);

                // TileView2'nin bağlı olduğu Grid'e yeni veriyi bas
                customerPackageGridControl.DataSource = customerServices;

                // (Sizin kodunuzda tileView2 kullanılıyor varsayıyorum)
                // tileView2.RefreshData(); 
            }
        }

        // Müşterinin bu paketi almaya uygun olup olmadığını kontrol eden metot
        private bool CanCustomerBuyPackage(int customerId, int packageId)
        {
            var existingServices = _customerServiceRepository.GetByCustomer(customerId);

            foreach (var service in existingServices)
            {
                if (service.ServicePackageId == packageId)
                {
                    // EĞER AYNI PAKET BULUNURSA:
                    // Seansı bitmemişse (0'dan büyükse) VEYA Kalan Borcu varsa (0'dan büyükse) ALAMAZ!
                    if (service.RemainingSessions > 0 || service.RemainingDebt > 0)
                    {
                        return false; // Alımı Engelle
                    }
                }
            }

            return true; // Hiç aktif/bitmemiş paket yok, Alıma İzin Ver
        }

        private void tileView2_ContextButtonClick(object sender, ContextItemClickEventArgs e)
        {
            // Tıklanan kartın (tile) RowHandle değerini al

            TileViewItem controlItem = e.DataItem as TileViewItem;
            if (e.Item.Name == "contextButton1")
            {
                CustomerService customerPackage = (CustomerService)tileView2.GetRow(controlItem.RowHandle);
                customerPackage.IsVisible = !customerPackage.IsVisible;
                // ❗ KRİTİK EKLENTİ: Değişikliği veritabanına kaydet
                // Kendi repository veya ORM mimarine göre aşağıdaki satırı uyarla
                _customerServiceRepository.Update(customerPackage);
            }
            tileView2.RefreshData();
        }

        private void tileView2_CustomRowFilter(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
        {
            // Veri kaynağına erişim
            var row = tileView2.GetRow(tileView1.GetRowHandle(e.ListSourceRow)) as CustomerService;

            if (row != null && !row.IsVisible && !chkShowHidden.Checked)
            {
                e.Visible = false; // ❗ Gizleme işlemi burada gerçekleşir
                e.Handled = true;
            }
        }

        private void chkShowHidden_CheckedChanged(object sender, EventArgs e)
        {
            //  Sadece ekranı tazelemeye zorlar. Filtre motoru (CustomRowFilter) yeniden çalışır.
            tileView2.RefreshData();
        }

        private void tileView2_ContextButtonCustomize(object sender, TileViewContextButtonCustomizeEventArgs e)
        {
            // Sadece hedeflediğimiz butona müdahale ediyoruz
            if (e.Item.Name == "contextButton1")
            {
                // 1. Arka plandaki veriyi (CustomerService) okuyoruz
                var row = tileView2.GetRow(e.RowHandle) as CustomerService;

                // 2. e.Item nesnesini ContextButton tipine dönüştürüyoruz (Cast)
                var btn = e.Item as DevExpress.Utils.ContextButton;

                if (row != null && btn != null)
                {
                    // 🧠 KRİTİK MANTIK: Duruma göre ikonu dinamik olarak ata
                    if (row.IsVisible)
                    {
                        // IsVisible true ise açık göz ikonunu bas
                        btn.ImageOptions.SvgImage = svgImageCollection1[2];

                        // İsteğe bağlı: Butonun ipucu (tooltip) metnini de değiştirebilirsiniz
                        btn.ToolTip = "Gizle";
                    }
                    else
                    {
                        // IsVisible false ise kapalı göz ikonunu bas
                        btn.ImageOptions.SvgImage = svgImageCollection1[3];
                        btn.ToolTip = "Göster";
                    }
                }
            }
        }
    }
}
