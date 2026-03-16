using DevExpress.LookAndFeel;
using DevExpress.Office.Export.Html;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
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
using System.Globalization;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.XtraBars.Docking2010;

namespace DXBeauty.UI
{
    public partial class PackageCardControl : DevExpress.XtraEditors.XtraUserControl
    {
        ServicePackage _servicePackage = new ServicePackage();
        ServicePackageRepository servicePackageRepository;
        bool packageEditMode = true;
        private readonly string connectionString;
        private Skin currentSkin;

        public PackageCardControl()
        {
            InitializeComponent();
        }

        public PackageCardControl(ServicePackage servicePackage)
        {
            InitializeComponent();

            packageServiceEditButton.ImageOptions.SvgImage = svgImageCollection1[0];

            _servicePackage = servicePackage;
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            servicePackageRepository = new ServicePackageRepository(connectionString);

            
            Root.Text = _servicePackage.Name;

          

            sessionCountEdit.Text = _servicePackage.SessionCount.ToString();
            totalPriceEdit.Text = _servicePackage.TotalPrice.ToString();
            installmentAllowedEdit.Checked = _servicePackage.IsInstallmentAllowed;
            isActiveEdit.Checked = _servicePackage.IsActive;

            foreach (LayoutControlItem item in Root.Items)
            {
                if (item.Control.Name.ToString() == "packageServiceEditButton")
                {
                    item.Enabled = true;
                }
                else
                {
                    item.Enabled = false;
                }
            }
        }

      

        private void packageServiceEditButton_Click(object sender, EventArgs e)
        {

            if (packageEditMode == true)
            {
                packageServiceEditButton.ImageOptions.SvgImage = svgImageCollection1[1];
                packageServiceEditButton.Text = "Değişikleri Kaydet";
                foreach (LayoutControlItem item in Root.Items)
                {
                    if (item.Control.Name.ToString() == "packageServiceEditButton")
                    {
                        item.Enabled = true;
                    }
                    else
                    {
                        item.Enabled = true;
                    }
                }


                packageEditMode = false;
            }
            else if (packageEditMode == false)
            {
                packageServiceEditButton.ImageOptions.SvgImage = svgImageCollection1[0];
                packageServiceEditButton.Text = "Düzenle";

                foreach (LayoutControlItem item in Root.Items)
                {
                    if (item.Control.Name.ToString() == "packageServiceEditButton")
                    {
                        item.Enabled = true;
                    }
                    else
                    {
                        item.Enabled = false;
                    }
                }

                _servicePackage.SessionCount = Convert.ToInt32(sessionCountEdit.Text);
                _servicePackage.TotalPrice = decimal.Parse(totalPriceEdit.Text, NumberStyles.Currency, new CultureInfo("tr-TR"));
                _servicePackage.IsInstallmentAllowed = installmentAllowedEdit.Checked;
                _servicePackage.IsActive = isActiveEdit.Checked;
                servicePackageRepository.Update(_servicePackage);

                packageEditMode = true;
            }



        }

        private void Root_CustomButtonClick_1(object sender, BaseButtonEventArgs e)
        {
            // Eylem (Button.Properties.Tag) kontrolü rasyonel bir yaklaşımdır. ❗
            var tag = e.Button.Properties.GetType().GetProperty("Tag")?.GetValue(e.Button.Properties, null);
            if (tag != null && tag.ToString() == "btnEditTitle")
            {
                // Tıklanan öğeyi (Root grubunu) alalım
                LayoutControlGroup clickedGroup = (LayoutControlGroup)sender;

                // Mevcut başlığı alalım
                string mevcutBaslik = clickedGroup.Text;

                // XtraInputBox ile yeni başlığı isteyelim
                string yeniBaslik = XtraInputBox.Show(
                    "Yeni başlığı giriniz:",     // Mesaj
                    "Grup Başlığını Düzenle",    // Pencere Başlığı
                    mevcutBaslik                 // Varsayılan Değer
                );

                // Kullanıcı iptal etmediyse ve boş değilse
                if (!string.IsNullOrEmpty(yeniBaslik))
                {
                    // Görsel başlığı değiştir (Text)
                    clickedGroup.Text = yeniBaslik;

                    // Opsiyonel: CustomizationFormText'i de aynı yapmak isterseniz 🚩
                    // clickedGroup.CustomizationFormText = yeniBaslik;

                    _servicePackage.Name = yeniBaslik;
                    try
                    {
                        servicePackageRepository.Update(_servicePackage);
                    }
                    catch (Exception ex)
                    {
                        // Burada ileride hatayı bir .txt dosyasına (Log) kaydedeceğiz.
                        DevExpress.XtraEditors.XtraMessageBox.Show(
                            "İşlem sırasında beklenmeyen bir hata oluştu.\n\nDetay: " + ex.Message,
                            "Sistem Uyarı",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    

                    XtraMessageBox.Show("Başlık başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
