using DevExpress.Mvvm.POCO;
using DevExpress.Utils;
using DevExpress.Utils.Helpers;
using DevExpress.XtraEditors;

using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
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


        public ServicesControl()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            serviceRepo = new ServiceRepository(connectionString);
            servicePackageRepo = new ServicePackageRepository(connectionString);



        }

        private void ServicesControl_Load(object sender, EventArgs e)
        {
            LoadServiceButtons();

        }


        private void LoadServiceButtons()
        {

            var services = serviceRepo.GetAll();

            gridControl1.DataSource = services;

        }

        private void CreateService_Click(object sender, EventArgs e)
        {
            CreateServiceControl createService = new UI.CreateServiceControl();

            XtraForm popup = new XtraForm();


            popup.StartPosition = FormStartPosition.CenterScreen;
            createService.Dock = DockStyle.Fill;
            popup.Controls.Add(createService);

            popup.Show();

            createService.ServiceSaved += (service) =>
            {
                LoadServiceButtons();
                popup.Close();
            };
        }

        private void addPackageButton_Click(object sender, EventArgs e)
        {
            
        }

        private void AddPackageToFlowPanel(AddPackageControl control)
        {
            control.ServicePackageSaved += (servicePackage) =>
            {
                // Yeni paketi flowLayoutPanel1'e ekle
                try
                {

                    // Kendi tasarladığın kontrolü oluştur
                    PackageCardControl uc = new PackageCardControl(servicePackage);

                    // Opsiyonel: Kontrolün genişliğini panelin genişliğine göre ayarlayabilirsin
                    uc.Width = flowLayoutPanel1.Width - 25;

                    flowLayoutPanel1.Controls.Add(uc);

                }
                finally
                {
                    // 4. UI güncellemesini serbest bırak
                    flowLayoutPanel1.ResumeLayout();
                }
            };
        }

        private void layoutView1_CardClick(object sender, DevExpress.XtraGrid.Views.Layout.Events.CardClickEventArgs e)
        {
            Service selectedService = layoutView1.GetFocusedRow() as Service;

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
