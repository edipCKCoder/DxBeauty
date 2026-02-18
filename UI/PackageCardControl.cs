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

namespace DXBeauty.UI
{
    public partial class PackageCardControl : DevExpress.XtraEditors.XtraUserControl
    {
        ServicePackage _servicePackage = new ServicePackage();
        ServicePackageRepository servicePackageRepository;
        bool editMode = true;
        private readonly string connectionString;
        public PackageCardControl()
        {
            InitializeComponent();
        }

        public PackageCardControl(ServicePackage servicePackage)
        {
            InitializeComponent();
            _servicePackage = servicePackage;
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            servicePackageRepository = new ServicePackageRepository(connectionString);


            Root.Text = _servicePackage.Name;
            sessionCountEdit.Text = _servicePackage.SessionCount.ToString();
            totalPriceEdit.Text = _servicePackage.TotalPrice.ToString();
            installmentAllowedEdit.Checked = _servicePackage.IsInstallmentAllowed;
            isActiveEdit.Checked = _servicePackage.IsActive;

            packageServiceEditButton.ImageOptions.SvgImage = svgImageCollection1[0];

            ChangedBorderColor(isActiveEdit.Checked);

        }

        private void packageServiceEditButton_Click(object sender, EventArgs e)
        {

            //edit modeu aktif hale getir
            if (editMode)
            {
                packageServiceEditButton.ImageOptions.SvgImage = svgImageCollection1[1];
                packageServiceEditButton.Text = "Save";
                sessionCountEdit.Enabled = true;
                totalPriceEdit.Enabled = true;
                installmentAllowedEdit.Enabled = true;
                isActiveEdit.ReadOnly = false;
                isActiveEdit.Enabled = true;
                editMode = false;
            }
            //edit modeu pasif hale getir
            else
            {
                packageServiceEditButton.ImageOptions.SvgImage = svgImageCollection1[0];
                packageServiceEditButton.Text = "Edit";
                sessionCountEdit.Enabled = false;
                totalPriceEdit.Enabled = false;
                installmentAllowedEdit.Enabled = false;
                isActiveEdit.ReadOnly = true;
                editMode = true;

                //değişiklikleri kaydet

                _servicePackage.SessionCount = Convert.ToInt32(sessionCountEdit.Text);
                _servicePackage.TotalPrice = Convert.ToDecimal(totalPriceEdit.Text);
                _servicePackage.IsInstallmentAllowed = installmentAllowedEdit.Checked;
                _servicePackage.IsActive = isActiveEdit.Checked;
                
                ChangedBorderColor(isActiveEdit.Checked);
                servicePackageRepository.Update(_servicePackage);

            }
        }

        void ChangedBorderColor(bool isActive)
        {
            if (isActive)
            {
                isActiveEdit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
                isActiveEdit.Properties.Appearance.Options.UseBorderColor = true;
                isActiveEdit.Properties.Appearance.BorderColor = DXSkinColors.FillColors.Success;
                isActiveEdit.ReadOnly = true;
                isActiveEdit.Enabled = true;
                Root.AppearanceGroup.BorderColor = DXSkinColors.FillColors.Success;
            }
            else
            {
                isActiveEdit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
                isActiveEdit.Properties.Appearance.Options.UseBorderColor = true;
                isActiveEdit.Properties.Appearance.BorderColor = DXSkinColors.FillColors.Warning;
                isActiveEdit.ReadOnly = true;
                isActiveEdit.Enabled = true;
                Root.AppearanceGroup.BorderColor = DXSkinColors.FillColors.Warning;
            }

        }

     
    }
}
