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
    public partial class ServicesControl : DevExpress.XtraEditors.XtraUserControl
    {
        public ServicesControl()
        {
            InitializeComponent();
        }

        private void CreateService_Click(object sender, EventArgs e)
        {
            CreateServiceControl createService = new UI.CreateServiceControl();
            
            XtraForm popup = new XtraForm();
            popup.StartPosition = FormStartPosition.CenterScreen;
            popup.Controls.Add(createService);
            popup.ShowDialog();
            


        }
    }
}
