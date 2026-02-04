using DevExpress.XtraEditors;
using DXBeauty.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXBeauty.UI
{
    public partial class CustomerRegisterControl : DevExpress.XtraEditors.XtraUserControl
    {

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
                BirthDate = birthdayBox.DateTime,
            };

            this.ParentForm.Close();
        }
    }
}
