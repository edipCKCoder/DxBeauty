using DXBeauty.Data;
using DXBeauty.Entities;
using System;
using System.Configuration;


namespace DXBeauty.UI
{
    public partial class CreateServiceControl : DevExpress.XtraEditors.XtraUserControl
    {

        public event Action<Service> ServiceSaved;
        private readonly ServiceRepository repo;
        private readonly string connectionString;

        public CreateServiceControl()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            repo = new ServiceRepository(connectionString);
        }


        private void createServiceButton_Click(object sender, EventArgs e)
        {
            var service = new Service
            {
                Name = serviceName.Text,
                Description = serviceDescription.Text,
                IsActive = isActive.Checked,
            };

            // DB insert burada olabilir
            repo.Insert(service);
            ServiceSaved?.Invoke(service);
            
        }
    }
}
