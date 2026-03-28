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

            DevExpress.LookAndFeel.UserLookAndFeel.Default.StyleChanged += UserLookAndFeel_StyleChanged;
            ShowControlInPanel(new UI.DashboardControl(), "Gösterge Panosu");
        }

        private void UserLookAndFeel_StyleChanged(object sender, EventArgs e)
        {
            // O an ekranda aktif olan temanın adını ve paletini ayarlara yaz
            Properties.Settings.Default.SkinName = DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName;
            Properties.Settings.Default.PaletteName = DevExpress.LookAndFeel.UserLookAndFeel.Default.ActiveSvgPaletteName;

            // Ayarları kalıcı olarak diske kaydet
            Properties.Settings.Default.Save();
        }


        private void ShowControlInPanel(XtraUserControl control,string sekmeBasligi)
        {
            // Açık sekmeleri tarar, varsa öne getirir, yoksa yeni sekme açar
            foreach (DevExpress.XtraBars.Docking2010.Views.BaseDocument doc in documentManager1.View.Documents)
            {
                if (doc.Control != null && doc.Control.GetType() == control.GetType())
                {
                    documentManager1.View.Controller.Activate(doc);
                    return;
                }
            }
            control.Dock = DockStyle.Fill;
            // ⚠️ YENİ KOD: Eklenen sekmeyi 'yeniSekme' değişkenine alıyoruz
            DevExpress.XtraBars.Docking2010.Views.BaseDocument yeniSekme = documentManager1.View.AddDocument(control);

            // Sekmenin üzerinde yazacak olan başlığı atıyoruz
            yeniSekme.Caption = sekmeBasligi;
        }

        private void btnRibbonScheduler_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowControlInPanel(new UI.AppScheduler(), "Takvim");
        }

        private void btnRibbonPayment_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowControlInPanel(new UI.GetPaymentsControl(), "Tahsilat");
        }

        private void btnRibbonfinancialReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            FinancialReportControl financialReportControl = new UI.FinancialReportControl();
            financialReportControl.Dock = DockStyle.Fill;
            XtraForm popUp = new XtraForm();


            popUp.ClientSize = financialReportControl.Size;
            popUp.Controls.Add(financialReportControl); // (PopUp.AddControl yerine PopUp.Controls.Add kullanmalısınız)
            popUp.StartPosition = FormStartPosition.CenterScreen;

            popUp.ShowDialog();
        }

        private void btnRibbonCustomerHistory_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowControlInPanel(new UI.CustomerHistoryControl(),"Müşteri Geçmişi");
        }

        private void btnRibbonCustomerRegister_ItemClick(object sender, ItemClickEventArgs e)
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

                    // 2. AÇIK OLAN FORMU BUL VE METODU ÇALIŞTIR ❗
                    if (CustomerPackagesControl.Instance != null)
                    {
                        CustomerPackagesControl.Instance.LoadData();
                    }
                    

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

        private void btnRibbonCreateService_ItemClick(object sender, ItemClickEventArgs e)
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

        private void btnRibbonDefinePackage_ItemClick(object sender, ItemClickEventArgs e)
        {
            AddPackageControl addPackageControl = new UI.AddPackageControl();
            addPackageControl.Dock = DockStyle.Fill;
            XtraForm popUp = new XtraForm();


            popUp.ClientSize = addPackageControl.Size;
            popUp.Controls.Add(addPackageControl); // (PopUp.AddControl yerine PopUp.Controls.Add kullanmalısınız)
            popUp.StartPosition = FormStartPosition.CenterScreen;

            popUp.ShowDialog();
        }

        private void btnRibbonDashboard_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowControlInPanel(new UI.DashboardControl(),"Gösterge Panosu");
        }

        private void btnRibbonCustomerList_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowControlInPanel(new UI.CustomerControl(), "Müşteriler");
        }

        private void btnRibbonCustomerPackages_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowControlInPanel(new UI.CustomerPackagesControl(), "Müşteriye Paket Tanımla");
        }

        private void btnRibbonServicePackages_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowControlInPanel(new UI.ServicesControl(), "Hizmetler ve Paketler");
        }

        private void btnRibbonMessageTemplate_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowControlInPanel(new UI.MessageTemplateControl(), "Mesaj Şablonları");
        }
    }
}