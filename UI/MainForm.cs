using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;
using DXBeauty.Data;
using DXBeauty.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace DXBeauty
{
    public partial class MainForm : RibbonForm
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        // DevExpress'in şık bildirim (Toast) aracı
        private DevExpress.XtraBars.Alerter.AlertControl toastBildirim = new DevExpress.XtraBars.Alerter.AlertControl();
        public MainForm()
        {
            InitializeComponent();
            ShowControlInPanel(new UI.DashboardControl());
            DevExpress.LookAndFeel.UserLookAndFeel.Default.StyleChanged += UserLookAndFeel_StyleChanged;

        }

        private void UserLookAndFeel_StyleChanged(object sender, EventArgs e)
        {
            // O an ekranda aktif olan temanın adını ve paletini ayarlara yaz
            Properties.Settings.Default.SkinName = DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName;
            Properties.Settings.Default.PaletteName = DevExpress.LookAndFeel.UserLookAndFeel.Default.ActiveSvgPaletteName;

            // Ayarları kalıcı olarak diske kaydet
            Properties.Settings.Default.Save();
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
            CustomerRegisterControl customerRegisterControl = new UI.CustomerRegisterControl();
            customerRegisterControl.Dock = DockStyle.Fill;

            XtraForm popUp = new XtraForm();

            // ÇÖZÜM: MainForm'da da bu Event'e abone oluyoruz (Dinliyoruz)
            customerRegisterControl.CustomerSaved += (customer) =>
            {
                // RİSKLİ ALAN BURASI OLDUĞU İÇİN TRY-CATCH BURADA OLMALIDIR
                try
                {
                    // 1. Müşteriyi veritabanına ekle
                    var repo = new CustomerRepository(connectionString);
                    repo.Insert(customer);

                    // 2. İşlem başarılıysa mesaj ver
                    DevExpress.XtraEditors.XtraMessageBox.Show("Müşteri başarıyla kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 3. SADECE BAŞARILIYSA FORMU KAPAT (Hata verirse buraya hiç ulaşmaz)
                    popUp.Close();
                }
                catch (Exception ex)
                {
                    // 4. HATA DURUMUNDA KULLANICIYI UYAR (Form kapanmaz, ekranda kalır)
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                        "Müşteri kaydedilirken bir hata oluştu!\nLütfen veritabanı bağlantınızı kontrol edin.\n\nHata Detayı: " + ex.Message,
                        "Kayıt Hatası",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            };

            popUp.ClientSize = customerRegisterControl.Size;
            popUp.Controls.Add(customerRegisterControl); // (PopUp.AddControl yerine PopUp.Controls.Add kullanmalısınız)
            popUp.StartPosition = FormStartPosition.CenterScreen;

            // Formu açarken sadece UI (Arayüz) çökmelerine karşı dışarıya basit bir try-catch koyabilirsiniz
            try
            {
                popUp.ShowDialog();
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Ekran açılırken bir sorun oluştu: " + ex.Message, "Sistem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            CreateServiceControl createServiceControl = new UI.CreateServiceControl();
            createServiceControl.Dock = DockStyle.Fill;
            XtraForm popUp = new XtraForm();

            createServiceControl.ServiceSaved += (service) =>
            {
                try
                {
                    var repo = new ServiceRepository(connectionString);
                    repo.Insert(service);
                    DevExpress.XtraEditors.XtraMessageBox.Show("Hizmet başarıyla kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    popUp.Close();
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                        "Hizmet kaydedilirken bir hata oluştu!\nLütfen veritabanı bağlantınızı kontrol edin.\n\nHata Detayı: " + ex.Message,
                        "Kayıt Hatası",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            };

            popUp.ClientSize = createServiceControl.Size;
            popUp.Controls.Add(createServiceControl); // (PopUp.AddControl yerine PopUp.Controls.Add kullanmalısınız)
            popUp.StartPosition = FormStartPosition.CenterScreen;

            // Formu açarken sadece UI (Arayüz) çökmelerine karşı dışarıya basit bir try-catch koyabilirsiniz
            try
            {
                popUp.ShowDialog();
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Ekran açılırken bir sorun oluştu: " + ex.Message, "Sistem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            AddPackageControl addPackageControl = new UI.AddPackageControl();
            addPackageControl.Dock = DockStyle.Fill;
            XtraForm popUp = new XtraForm();


            popUp.ClientSize = addPackageControl.Size;
            popUp.Controls.Add(addPackageControl); // (PopUp.AddControl yerine PopUp.Controls.Add kullanmalısınız)
            popUp.StartPosition = FormStartPosition.CenterScreen;

            popUp.ShowDialog();
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            CustomerHistoryControl customerHistory = new UI.CustomerHistoryControl();
            customerHistory.Dock = DockStyle.Fill;
            XtraForm popUp = new XtraForm();


            popUp.ClientSize = customerHistory.Size;
            popUp.Controls.Add(customerHistory); // (PopUp.AddControl yerine PopUp.Controls.Add kullanmalısınız)
            popUp.StartPosition = FormStartPosition.CenterScreen;

            popUp.ShowDialog();
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            FinancialReportControl financialReportControl = new UI.FinancialReportControl();
            financialReportControl.Dock = DockStyle.Fill;
            XtraForm popUp = new XtraForm();


            popUp.ClientSize = financialReportControl.Size;
            popUp.Controls.Add(financialReportControl); // (PopUp.AddControl yerine PopUp.Controls.Add kullanmalısınız)
            popUp.StartPosition = FormStartPosition.CenterScreen;

            popUp.ShowDialog();
        }
    }
}