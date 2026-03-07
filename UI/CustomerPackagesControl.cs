using DevExpress.Utils;
using DevExpress.Utils.DragDrop;
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
                    if (item.ServicePackageId == droppedPackage.ServicePackageId && item.Status == CustomerService.StatusType.Active)
                    {
                        XtraMessageBox.Show("Bu müşterinin zaten devam eden aynı paketi var!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // 2. YENİ MÜŞTERİ PAKETİ NESNESİ
                var newCustomerService = new CustomerService
                {
                    CustomerId = customerId,
                    ServicePackageId = droppedPackage.ServicePackageId,
                    StartDate = DateTime.Now,
                    RemainingSessions = droppedPackage.SessionCount,
                    Name = droppedPackage.Name,
                    TotalPrice = droppedPackage.TotalPrice, // Yorumdan çıkarıldı!
                    RemainingDebt = droppedPackage.TotalPrice, // Borç olarak kaydedildi!
                    Status = CustomerService.StatusType.Active
                };


                // 3. TAKSİT SAYISINI BELİRLEME
                int installmentCount = 1; // Varsayılan peşin (1 taksit)

                if (droppedPackage.IsInstallmentAllowed)
                {
                    // DevExpress InputBox ile kullanıcıya soruyoruz
                    string input = XtraInputBox.Show("Bu paket taksitlendirilebilir. Lütfen taksit sayısını giriniz (Peşin için 1 yazın):", "Taksit Sayısı", "1");

                    if (!int.TryParse(input, out installmentCount) || installmentCount <= 0)
                    {
                        XtraMessageBox.Show("Geçersiz taksit sayısı girdiniz. İşlem iptal edildi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }

                // 4. VERİTABANINA KAYDET VE YENİ ID'Yİ AL
                int newCustomerServiceId = _customerServiceRepository.Insert(newCustomerService);
                // 5. TAKSİTLERİ (BORÇ PLANI) OLUŞTUR VE KAYDET
                if (newCustomerServiceId > 0 && newCustomerService.TotalPrice > 0)
                {
                    var installments = new List<Installment>();
                    decimal amountPerInstallment = newCustomerService.TotalPrice / installmentCount;

                    for (int i = 1; i <= installmentCount; i++)
                    {
                        installments.Add(new Installment
                        {
                            CustomerServiceId = newCustomerServiceId,
                            InstallmentNumber = i,
                            Amount = amountPerInstallment,
                            DueDate = DateTime.Now.AddMonths(i - 1) // İlk taksit hemen (bugün), diğerleri 1'er ay sonraya!
                        });
                    }

                    var installmentRepo = new InstallmentRepository(_connectionString);
                    installmentRepo.InsertInstallments(installments);
                }

                // 6. EKRANI YENİLE VE BAŞARI MESAJI VER
                LoadCustomerServices(customerId);
                XtraMessageBox.Show($"Paket müşteriye başarıyla tanımlandı!\nToplam: {newCustomerService.TotalPrice} TL\nTaksit Sayısı: {installmentCount}", "Satış Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            StatusType statusType = (StatusType)view.GetRowCellValue(e.RowHandle, layoutViewColumn10);

            var isActiveElement = e.Item.Elements[3];

            switch (statusType)
            {
                case StatusType.None:
                    isActiveElement.Text = "None";
                    break;
                case StatusType.Active:
                    isActiveElement.Text = "Active";
                    break;
                case StatusType.Suspended:
                    isActiveElement.Text = "Suspended";
                    break;
                case StatusType.Continued:
                    isActiveElement.Text = "Continued";
                    break;
                case StatusType.Completed:
                    isActiveElement.Text = "Completed";
                    break;
                case StatusType.Cancelled:
                    isActiveElement.Text = "Cancelled";
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
