using DXBeauty.Data;
using DXBeauty.Entities;
using System;
using System.Configuration;

namespace DXBeauty.UI
{
    public partial class CustomerRegisterControl : DevExpress.XtraEditors.XtraUserControl
    {

        public event Action <Customer> CustomerSaved;
        public Customer EditingCustomer { get; private set; }
        public bool IsEditMode => EditingCustomer != null;


        public CustomerRegisterControl()
        {
            InitializeComponent();

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsEditMode)
            {
                UpdateCustomer();
            }
            else
            {
                InsertCustomer();
            }           
        }

        public void LoadCustomer(Customer customer)
        {
            EditingCustomer = customer;

            nameBox.Text = customer.FirstName;
            surnameBox.Text = customer.LastName;
            phoneBox.Text = customer.PhoneNumber;
            emailBox.Text = customer.Email;
            addressBox.Text = customer.Address;
            birthdayBox.DateTime = customer.Birthday.HasValue ? customer.Birthday.Value : DateTime.MinValue;
        }

        private void UpdateCustomer()
        {
            EditingCustomer.FirstName = nameBox.Text;
            EditingCustomer.LastName = surnameBox.Text;
            EditingCustomer.PhoneNumber = phoneBox.Text;
            EditingCustomer.Email = emailBox.Text;
            EditingCustomer.Address = addressBox.Text;
            EditingCustomer.Birthday = birthdayBox.DateTime;

            CustomerSaved?.Invoke(EditingCustomer);
        }

        private void InsertCustomer()
        {
            Customer customer = new Customer
            {
                FirstName = nameBox.Text,
                LastName = surnameBox.Text,
                PhoneNumber = phoneBox.Text,
                Email = emailBox.Text,
                Address = addressBox.Text,
                Birthday = birthdayBox.DateTime,
            };

            CustomerSaved?.Invoke(customer);
        }
    }
}
