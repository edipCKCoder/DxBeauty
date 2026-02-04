using DXBeauty.Data;
using DXBeauty.Entities;
using System;
using System.Configuration;

namespace DXBeauty.UI
{
    public partial class CustomerRegisterControl : DevExpress.XtraEditors.XtraUserControl
    {

        public event Action <Customer> CustomerSaved;

        public CustomerRegisterControl()
        {
            InitializeComponent();

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer
            {
                FirstName = nameBox.Text,
                LastName = surnameBox.Text,
                Phone = phoneBox.Text,
                Email = emailBox.Text,
                Address = addressBox.Text,
                Birthday = birthdayBox.DateTime,
            };

            CustomerSaved?.Invoke(customer);

        }
    }
}
