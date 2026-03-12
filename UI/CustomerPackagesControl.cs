using DevExpress.Utils;
using DevExpress.Utils.DragDrop;
using DevExpress.Utils.Extensions;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Tile;
using DevExpress.XtraGrid.Views.Tile.ViewInfo;
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
using DXBeauty.Enums;

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

        private DevExpress.Utils.Behaviors.BehaviorManager _dragDropManager;

        public CustomerPackagesControl()
        {
            InitializeComponent();
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _dragDropManager = new DevExpress.Utils.Behaviors.BehaviorManager();


            LoadData();
            
            // 2. Kaynak View'unuza (paketlerin olduğu TileView) sürükleme özelliği ekliyoruz
            _dragDropManager.Attach<DevExpress.Utils.DragDrop.DragDropBehavior>(tileView1, sourceBehavior =>
            {
              
                sourceBehavior.Properties.AllowDrop = true;
                sourceBehavior.Properties.InsertIndicatorVisible = true;
                sourceBehavior.Properties.PreviewVisible = true;

                sourceBehavior.DragOver +=sourceBehavior_DragOver;

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
                var currentlyCustomerServices = _customerServiceRepository.GetByCustomer(customerId);
                foreach (var item in currentlyCustomerServices)
                {
                    // Eğer müşteri bu paketi önceden aldıysa ve statüsü Active ise uyar
                    if (item.ServicePackageId == droppedPackage.ServicePackageId)
                    {
                        XtraMessageBox.Show("Bu müşterinin zaten devam eden aynı paketi var!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
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
                //XtraMessageBox.Show($"Paket müşteriye başarıyla tanımlandı!\nToplam: {newCustomerService.TotalPrice} TL\nTaksit Sayısı: {installmentCount}", "Satış Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            e.Handled = true; // CRITICAL

        }

        private void sourceBehavior_DragOver(object sender, DragOverEventArgs e)
        {
            TileView masterView = e.Source as TileView;

            var servicePackage =  masterView.FocusedRowObject as ServicePackage;

            if (servicePackage != null && servicePackage.IsActive)
            {
                e.Default();
            }
            else
            {
                e.Handled = false;
            }
        }

        void LoadData()
        {

            _customerRepository = new CustomerRepository(_connectionString);
            _serviceRepository = new ServiceRepository(_connectionString);
            _servicePackageRepository = new ServicePackageRepository(_connectionString);
            _customerServiceRepository = new CustomerServiceRepository(_connectionString);

            sluCustomerEdit.Properties.DataSource = _customerRepository.GetAll();
            packageGridControl.DataSource = _servicePackageRepository.GetAll();
            seviceGridControl.DataSource = _serviceRepository.GetAll();


            sluCustomerEdit.Properties.DisplayMember = "FullName";
            sluCustomerEdit.Properties.ValueMember = "CustomerId";
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
            TileViewItem item = e.DataItem as TileViewItem;
            if (e.Item.Name == "contextButton1")
            {
                ServicePackage servicePackage = (ServicePackage)tileView1.GetRow(item.RowHandle);
                servicePackage.IsActive = true;
                _servicePackageRepository.Update(servicePackage);
                tileView1.RefreshRow(item.RowHandle);
                tileView1.LayoutChanged();
            }
            else if (e.Item.Name == "contextButton2")
            {
                ServicePackage servicePackage = (ServicePackage)tileView1.GetRow(item.RowHandle);
                servicePackage.IsActive = false;
                _servicePackageRepository.Update(servicePackage);
                tileView1.RefreshRow(item.RowHandle);
                tileView1.LayoutChanged();
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


        private void serviceView_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var serviceId = (int)serviceView.GetRowCellValue(e.FocusedRowHandle, "ServiceId");
            packageGridControl.DataSource = _servicePackageRepository.GetByService(serviceId);
        }
    }
}
