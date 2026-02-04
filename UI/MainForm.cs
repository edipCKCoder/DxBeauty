using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;
using DXBeauty.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace DXBeauty
{
    public partial class MainForm : RibbonForm
    {
        public MainForm()
        {
            InitializeComponent();
            
        }
        private void NavBarItemScheduler_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowControlInPanel(new UI.SchedulerControl());
        }

        private void RegisterCustomer_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowControlInPanel(new UI.CustomerControl());
        }

        private void CustomerHistory_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowControlInPanel(new UI.CustomerHistoryControl());
        }
        private void getPayment_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowControlInPanel(new UI.GetPaymentsControl());
        }
        private void createService_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowControlInPanel(new UI.ServicesControl());
        }

        private void ReminderMessage_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowControlInPanel(new UI.ReminderMessageControl());
        }


        private void ShowControlInPanel(XtraUserControl control)
        {
            // Panel2'yi temizle
            splitContainerControl.Panel2.Controls.Clear();

            // Yeni kontrolü ekle
            control.Dock = DockStyle.Fill;
            splitContainerControl.Panel2.Controls.Add(control);
        }


    }
}