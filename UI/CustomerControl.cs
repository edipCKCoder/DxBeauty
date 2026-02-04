using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public CustomerControl()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            CustomerRegisterControl registerControl = new UI.CustomerRegisterControl();
            registerControl.Dock = DockStyle.Fill;
            registerControl.Show();

            XtraForm popup = new XtraForm();
            popup.StartPosition = FormStartPosition.CenterScreen;


            popup.Controls.Add(registerControl);
            popup.ShowDialog();
        }
    }
}
