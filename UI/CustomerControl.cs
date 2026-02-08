using DevExpress.XtraEditors;
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
        private void CustomerControl_Load(object sender, EventArgs e)
        {

            var customers = repo.GetAll().ToList();
            customerGridControl.DataSource = customers;
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
                    customerGridControl.DataSource = repo.GetAll().ToList();
                    popup.Close();
                };

                popup.StartPosition = FormStartPosition.CenterScreen;
                popup.Controls.Add(registerControl);
                popup.ShowDialog();
            }

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var customer = customersGridView.GetFocusedRow() as Customer;

            if (customer == null)
            {
                return;
            }
            var result = XtraMessageBox.Show(
                $"'{customer.FirstName} {customer.LastName}' silinsin mi?",
                "Onay",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            var repo = new CustomerRepository(connectionString);
            repo.Delete(customer.CustomerId);

            customerGridControl.DataSource = repo.GetAll().ToList();

        }

        private void editButton_Click(object sender, EventArgs e)
        {
            var customer = customersGridView.GetFocusedRow() as Customer;
            if (customer == null) return;

            var popup = new XtraForm();
            var registerControl = new CustomerRegisterControl();
            registerControl.Dock = DockStyle.Fill;

            registerControl.LoadCustomer(customer);

            registerControl.CustomerSaved += (updatedCustomer) =>
            {
                var repo = new CustomerRepository(connectionString);
                repo.Update(updatedCustomer);

                customerGridControl.DataSource = repo.GetAll().ToList(); // grid refresh
                popup.Close();
            };

            popup.Controls.Add(registerControl);
            popup.ShowDialog();
        }
    }
}
