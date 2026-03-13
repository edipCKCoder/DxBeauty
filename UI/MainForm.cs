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
            ShowControlInPanel(new UI.DashboardControl());

        }
        private void NavBarItemScheduler_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowControlInPanel(new UI.AppScheduler());
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
        private void financialReport_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowControlInPanel(new UI.FinancialReportControl());
        }

        private void createService_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowControlInPanel(new UI.ServicesControl());
        }

        private void ReminderMessage_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowControlInPanel(new UI.MessageTemplateControl());
        }
        private void CustomerPackages_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowControlInPanel(new UI.CustomerPackagesControl());
        }
        private void ShowControlInPanel(XtraUserControl control)
        {
            // Panel2'yi temizle
            splitContainerControl.Panel2.Controls.Clear();

            // Yeni kontrolü ekle
            control.Dock = DockStyle.Fill;
            splitContainerControl.Panel2.Controls.Add(control);
        }

        private void btnRibbonPayment_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Ribbon menüden tıklandığında Tahsilat UserControl'ünü ana panele yükle
            ShowControlInPanel(new UI.GetPaymentsControl());
        }


        private void btnRibbonfinancialReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowControlInPanel(new UI.FinancialReportControl());
        }

        private void customerRegisterbarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowControlInPanel(new UI.CustomerRegisterControl());
        }

        private void CustomerHistorybarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowControlInPanel(new UI.CustomerHistoryControl());
        }

        private void customerPackagesbarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowControlInPanel(new UI.CustomerPackagesControl());
        }

        private void schedulerBarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowControlInPanel(new UI.AppScheduler());
        }

        private void dashboardBarButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowControlInPanel(new UI.DashboardControl());
        }

        private void servicesPackagesBarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowControlInPanel(new UI.ServicesControl());
        }

        private void reminderMessagebarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowControlInPanel(new UI.MessageTemplateControl());
        }
    }
}