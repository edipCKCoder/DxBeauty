using DevExpress.XtraEditors;
using DXBeauty.Data;
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
    public partial class CustomerControl : DevExpress.XtraEditors.XtraUserControl
    {
        private readonly CustomerRepository repo;
        private readonly string connectionString;

        public CustomerControl()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            repo = new CustomerRepository(connectionString);

        }

        private void NewRegister_Click(object sender, EventArgs e)
        {
            using (var popup = new XtraForm())
            {
             
                var registerControl = new CustomerRegisterControl
                {
                    Dock = DockStyle.Fill
                };


                registerControl.CustomerSaved += (customer) =>
                {     
                    repo.Insert(customer);
                    CustomerGridControl.DataSource = repo.GetAll().ToList();
                    popup.Close();
                };

                popup.StartPosition = FormStartPosition.CenterScreen;
                popup.Controls.Add(registerControl);
                popup.ShowDialog();
            }
            
        }

        private void CustomerControl_Load(object sender, EventArgs e)
        {
            
            var customers = repo.GetAll().ToList();
            CustomerGridControl.DataSource = customers;
        }

    }
}
