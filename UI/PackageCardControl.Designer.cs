namespace DXBeauty.UI
{
    partial class PackageCardControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions1 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            totalPriceEdit = new DevExpress.XtraEditors.TextEdit();
            installmentAllowedEdit = new DevExpress.XtraEditors.CheckEdit();
            packageServiceEditButton = new DevExpress.XtraEditors.SimpleButton();
            svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(components);
            isActiveEdit = new DevExpress.XtraEditors.CheckEdit();
            sessionCountEdit = new DevExpress.XtraEditors.SpinEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)totalPriceEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)installmentAllowedEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)isActiveEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sessionCountEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            SuspendLayout();
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(totalPriceEdit);
            layoutControl1.Controls.Add(installmentAllowedEdit);
            layoutControl1.Controls.Add(packageServiceEditButton);
            layoutControl1.Controls.Add(isActiveEdit);
            layoutControl1.Controls.Add(sessionCountEdit);
            layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControl1.Location = new System.Drawing.Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsPrint.AppearanceGroupCaption.BorderColor = System.Drawing.Color.FromArgb(255, 192, 192);
            layoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseBorderColor = true;
            layoutControl1.Root = Root;
            layoutControl1.Size = new System.Drawing.Size(199, 209);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // totalPriceEdit
            // 
            totalPriceEdit.Location = new System.Drawing.Point(94, 58);
            totalPriceEdit.Name = "totalPriceEdit";
            totalPriceEdit.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            totalPriceEdit.Properties.MaskSettings.Set("mask", "c");
            totalPriceEdit.Properties.UseMaskAsDisplayFormat = true;
            totalPriceEdit.Size = new System.Drawing.Size(93, 22);
            totalPriceEdit.StyleController = layoutControl1;
            totalPriceEdit.TabIndex = 2;
            // 
            // installmentAllowedEdit
            // 
            installmentAllowedEdit.Location = new System.Drawing.Point(139, 84);
            installmentAllowedEdit.MaximumSize = new System.Drawing.Size(20, 30);
            installmentAllowedEdit.Name = "installmentAllowedEdit";
            installmentAllowedEdit.Properties.Caption = "";
            installmentAllowedEdit.Size = new System.Drawing.Size(20, 20);
            installmentAllowedEdit.StyleController = layoutControl1;
            installmentAllowedEdit.TabIndex = 3;
            // 
            // packageServiceEditButton
            // 
            packageServiceEditButton.Cursor = System.Windows.Forms.Cursors.Hand;
            packageServiceEditButton.ImageOptions.ImageList = svgImageCollection1;
            packageServiceEditButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            packageServiceEditButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            packageServiceEditButton.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None;
            packageServiceEditButton.ImageOptions.SvgImageSize = new System.Drawing.Size(15, 15);
            packageServiceEditButton.Location = new System.Drawing.Point(49, 153);
            packageServiceEditButton.MaximumSize = new System.Drawing.Size(100, 40);
            packageServiceEditButton.MinimumSize = new System.Drawing.Size(70, 10);
            packageServiceEditButton.Name = "packageServiceEditButton";
            packageServiceEditButton.Size = new System.Drawing.Size(100, 40);
            packageServiceEditButton.StyleController = layoutControl1;
            packageServiceEditButton.TabIndex = 5;
            packageServiceEditButton.Text = "Düzenle";
            packageServiceEditButton.Click += packageServiceEditButton_Click;
            // 
            // svgImageCollection1
            // 
            svgImageCollection1.ImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.CommonPalette;
            svgImageCollection1.Add("open2", "image://svgimages/actions/open2.svg");
            svgImageCollection1.Add("up", "image://svgimages/actions/up.svg");
            // 
            // isActiveEdit
            // 
            isActiveEdit.Location = new System.Drawing.Point(163, 117);
            isActiveEdit.MaximumSize = new System.Drawing.Size(20, 30);
            isActiveEdit.Name = "isActiveEdit";
            isActiveEdit.Properties.Caption = "";
            isActiveEdit.Properties.ContentAlignment = DevExpress.Utils.HorzAlignment.Center;
            isActiveEdit.Size = new System.Drawing.Size(20, 20);
            isActiveEdit.StyleController = layoutControl1;
            isActiveEdit.TabIndex = 4;
            // 
            // sessionCountEdit
            // 
            sessionCountEdit.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            sessionCountEdit.Location = new System.Drawing.Point(94, 32);
            sessionCountEdit.Name = "sessionCountEdit";
            sessionCountEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            sessionCountEdit.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            sessionCountEdit.Properties.MaskSettings.Set("mask", "");
            sessionCountEdit.Properties.MaskSettings.Set("autoHideDecimalSeparator", true);
            sessionCountEdit.Properties.UseMaskAsDisplayFormat = true;
            sessionCountEdit.Size = new System.Drawing.Size(93, 22);
            sessionCountEdit.StyleController = layoutControl1;
            sessionCountEdit.TabIndex = 0;
            // 
            // Root
            // 
            buttonImageOptions1.Location = DevExpress.XtraEditors.ButtonPanel.ImageLocation.AfterText;
            buttonImageOptions1.SvgImage = Properties.Resources.EducationIcon;
            buttonImageOptions1.SvgImageSize = new System.Drawing.Size(16, 16);
            Root.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] { new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("", true, buttonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "Yeni isim ver", -1, true, null, true, false, true, "btnEditTitle", -1) });
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupStyle = DevExpress.Utils.GroupStyle.Card;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2, layoutControlItem3, layoutControlItem4, layoutControlItem5 });
            Root.Name = "Root";
            Root.Size = new System.Drawing.Size(199, 209);
            Root.TextLocation = DevExpress.Utils.Locations.Default;
            Root.CustomButtonClick += Root_CustomButtonClick_1;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = sessionCountEdit;
            layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new System.Drawing.Size(179, 26);
            layoutControlItem1.Text = "Seans Sayısı :";
            layoutControlItem1.TextSize = new System.Drawing.Size(70, 13);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = totalPriceEdit;
            layoutControlItem2.Location = new System.Drawing.Point(0, 26);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new System.Drawing.Size(179, 26);
            layoutControlItem2.Text = "Toplam Tutar :";
            layoutControlItem2.TextSize = new System.Drawing.Size(70, 13);
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Center;
            layoutControlItem3.Control = installmentAllowedEdit;
            layoutControlItem3.CustomizationFormText = "Taksit Yapılabilir : ";
            layoutControlItem3.Location = new System.Drawing.Point(0, 52);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new System.Drawing.Size(179, 33);
            layoutControlItem3.Text = "Taksit Yapılabilir :";
            layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Left;
            layoutControlItem3.TextSize = new System.Drawing.Size(90, 13);
            layoutControlItem3.TextToControlDistance = 10;
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Center;
            layoutControlItem4.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            layoutControlItem4.Control = packageServiceEditButton;
            layoutControlItem4.Location = new System.Drawing.Point(0, 118);
            layoutControlItem4.MinSize = new System.Drawing.Size(50, 25);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new System.Drawing.Size(179, 51);
            layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Center;
            layoutControlItem5.Control = isActiveEdit;
            layoutControlItem5.Location = new System.Drawing.Point(0, 85);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.Size = new System.Drawing.Size(179, 33);
            layoutControlItem5.Text = "Kullanımda / Kullanım Dışı :";
            layoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Left;
            layoutControlItem5.TextSize = new System.Drawing.Size(138, 20);
            layoutControlItem5.TextToControlDistance = 10;
            // 
            // PackageCardControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(layoutControl1);
            Name = "PackageCardControl";
            Size = new System.Drawing.Size(199, 209);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)totalPriceEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)installmentAllowedEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)isActiveEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)sessionCountEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.TextEdit totalPriceEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.CheckEdit installmentAllowedEdit;
        private DevExpress.XtraEditors.SimpleButton packageServiceEditButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.CheckEdit isActiveEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
        private DevExpress.XtraEditors.SpinEdit sessionCountEdit;
    }
}
