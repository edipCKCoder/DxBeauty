using DevExpress.XtraEditors;

using DevExpress.XtraEditors.Repository;
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXBeauty.UI
{
    public partial class ServicesControl : DevExpress.XtraEditors.XtraUserControl
    {

        private readonly ServiceRepository repo;
        private readonly string connectionString;

        public ServicesControl()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            repo = new ServiceRepository(connectionString);

        }

        private void ServicesControl_Load(object sender, EventArgs e)
        {
            LoadServiceButtons();
        }

        private void LoadServiceButtons()
        {

            var services = repo.GetAll();

            gridControl1.DataSource = services;

            winExplorerView1.RefreshData();
                
        }


        private void CreateService_Click(object sender, EventArgs e)
        {
            CreateServiceControl createService = new UI.CreateServiceControl();

            XtraForm popup = new XtraForm();
            createService.Dock = DockStyle.Fill;

            createService.ServiceSaved += (service) =>
            {
                LoadServiceButtons();
                popup.Close();
            };

            popup.StartPosition = FormStartPosition.CenterScreen;
            popup.Controls.Add(createService);
            popup.ShowDialog();
        }

   
    }
}
