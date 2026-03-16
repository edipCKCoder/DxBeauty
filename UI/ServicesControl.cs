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

            gridControl1.DataSource = services;

        }

        private void CreateService_Click(object sender, EventArgs e)
        {
            CreateServiceControl createService = new UI.CreateServiceControl();

            createService.Dock = DockStyle.Fill;

            XtraForm popup = new XtraForm();

            popup.ClientSize = createService.Size;

            createService.Dock = DockStyle.Fill;

            popup.Controls.Add(createService);

            popup.StartPosition = FormStartPosition.CenterScreen;
            popup.Show();

            createService.ServiceSaved += (service) =>
            {
                LoadServiceData();
                popup.Close();
            };
        }

        private void addPackageButton_Click(object sender, EventArgs e)
        {
            Service selectedService = layoutView1.GetFocusedRow() as Service;
            XtraForm popup = new XtraForm();


            AddPackageControl addPackageControl = new AddPackageControl(selectedService);
            popup.ClientSize = addPackageControl.Size;
            // 1. Formun içeriğe göre boyutlanmasını sağla
            addPackageControl.Dock = DockStyle.Fill;

            popup.Controls.Add(addPackageControl);
            popup.StartPosition = FormStartPosition.CenterScreen;
            popup.Show();
            addPackageControl.ServicePackageSaved += (package) =>
            {
                List<ServicePackage> servicePackage = servicePackageRepo.GetByService(selectedService.ServiceId);
                flowLayoutPanel1.Controls.Clear();
                foreach (var item in servicePackage)
                {
                    PackageCardControl uc = new PackageCardControl(item);
                    flowLayoutPanel1.Controls.Add(uc);
                }
            };
        }

        private void layoutView1_CardClick_1(object sender, DevExpress.XtraGrid.Views.Layout.Events.CardClickEventArgs e)
        {

            LoadServicePackages(layoutView1.GetFocusedRow() as Service);
        }

        private void layoutView1_HiddenEditor(object sender, EventArgs e)
        {
            layoutView1.UpdateCurrentRow();
        }


        private void layoutView1_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            var view = sender as DevExpress.XtraGrid.Views.Layout.LayoutView;
            var service = (Service)e.Row;

            if (string.IsNullOrWhiteSpace(service.Name))
            {
                e.Valid = false;
                view.SetColumnError(view.Columns["Name"], "Hizmet adı boş olamaz.");
                return;
            }

            if (string.IsNullOrWhiteSpace(service.Description))
            {
                e.Valid = false;
                view.SetColumnError(view.Columns["Description"], "Hizmet Açıklaması boş olamaz.");
                return;
            }

            if (service.DefaultPrice < 0)
            {
                e.Valid = false;
                view.SetColumnError(view.Columns["DefaultPrice"], "Hizmet Fiyatı 0'dan kucuk olamaz.");
                return;
            }

        }

        private void layoutView1_RowUpdated(object sender, RowObjectEventArgs e)
        {
            var service = (Service)e.Row;

            serviceRepo.Update(service);
        }

        private void layoutView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            LoadServicePackages(layoutView1.GetFocusedRow() as Service);
        }


        private void LoadServicePackages(Service selectedService)
        {
            if (selectedService == null) return;
            List<ServicePackage> servicePackage = servicePackageRepo.GetByService(selectedService.ServiceId);
            flowLayoutPanel1.Controls.Clear();
            foreach (var package in servicePackage)
            {
                PackageCardControl uc = new PackageCardControl(package);
                flowLayoutPanel1.Controls.Add(uc);
            }
        }
    }

}
