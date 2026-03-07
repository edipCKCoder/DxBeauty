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
            
            if(packageEditMode == true)
            {
                packageServiceEditButton.ImageOptions.SvgImage = svgImageCollection1[1];
                packageServiceEditButton.Text = "Değişikleri Kaydet";
                    foreach (LayoutControlItem item in Root.Items)
                    {
                        if(item.Control.Name.ToString() == "packageServiceEditButton") 
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
     
    }
}
