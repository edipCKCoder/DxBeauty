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
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            sessionCountEdit = new DevExpress.XtraEditors.TextEdit();
            totalPriceEdit = new DevExpress.XtraEditors.TextEdit();
            installmentAllowedEdit = new DevExpress.XtraEditors.CheckEdit();
            packageServiceEditButton = new DevExpress.XtraEditors.SimpleButton();
            svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(components);
            isActiveEdit = new DevExpress.XtraEditors.CheckEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sessionCountEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)totalPriceEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)installmentAllowedEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)isActiveEdit.Properties).BeginInit();
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
            layoutControl1.Controls.Add(sessionCountEdit);
            layoutControl1.Controls.Add(totalPriceEdit);
            layoutControl1.Controls.Add(installmentAllowedEdit);
            layoutControl1.Controls.Add(packageServiceEditButton);
            layoutControl1.Controls.Add(isActiveEdit);
            layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControl1.Location = new System.Drawing.Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.Root = Root;
            layoutControl1.Size = new System.Drawing.Size(167, 211);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // sessionCountEdit
            // 
            sessionCountEdit.Enabled = false;
            sessionCountEdit.Location = new System.Drawing.Point(104, 37);
            sessionCountEdit.Name = "sessionCountEdit";
            sessionCountEdit.Size = new System.Drawing.Size(51, 20);
            sessionCountEdit.StyleController = layoutControl1;
            sessionCountEdit.TabIndex = 0;
            // 
            // totalPriceEdit
            // 
            totalPriceEdit.Enabled = false;
            totalPriceEdit.Location = new System.Drawing.Point(104, 61);
            totalPriceEdit.Name = "totalPriceEdit";
            totalPriceEdit.Size = new System.Drawing.Size(51, 20);
            totalPriceEdit.StyleController = layoutControl1;
            totalPriceEdit.TabIndex = 2;
            // 
            // installmentAllowedEdit
            // 
            installmentAllowedEdit.Enabled = false;
            installmentAllowedEdit.Location = new System.Drawing.Point(12, 95);
            installmentAllowedEdit.Name = "installmentAllowedEdit";
            installmentAllowedEdit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            installmentAllowedEdit.Properties.Caption = "Installment Allowed";
            installmentAllowedEdit.Properties.ContentAlignment = DevExpress.Utils.HorzAlignment.Center;
            installmentAllowedEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            installmentAllowedEdit.Size = new System.Drawing.Size(143, 20);
            installmentAllowedEdit.StyleController = layoutControl1;
            installmentAllowedEdit.TabIndex = 3;
            // 
            // packageServiceEditButton
            // 
            packageServiceEditButton.Cursor = System.Windows.Forms.Cursors.Hand;
            packageServiceEditButton.ImageOptions.ImageList = svgImageCollection1;
            packageServiceEditButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            packageServiceEditButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            packageServiceEditButton.Location = new System.Drawing.Point(46, 143);
            packageServiceEditButton.MaximumSize = new System.Drawing.Size(75, 60);
            packageServiceEditButton.MinimumSize = new System.Drawing.Size(50, 50);
            packageServiceEditButton.Name = "packageServiceEditButton";
            packageServiceEditButton.Size = new System.Drawing.Size(75, 56);
            packageServiceEditButton.StyleController = layoutControl1;
            packageServiceEditButton.TabIndex = 5;
            packageServiceEditButton.Text = "Edit";
            packageServiceEditButton.Click += packageServiceEditButton_Click;
            // 
            // svgImageCollection1
            // 
            svgImageCollection1.Add("editextractsource", "image://svgimages/dashboards/editextractsource.svg");
            svgImageCollection1.Add("saveall", "image://svgimages/save/saveall.svg");
            // 
            // isActiveEdit
            // 
            isActiveEdit.Enabled = false;
            isActiveEdit.Location = new System.Drawing.Point(23, 119);
            isActiveEdit.MaximumSize = new System.Drawing.Size(120, 0);
            isActiveEdit.MinimumSize = new System.Drawing.Size(90, 0);
            isActiveEdit.Name = "isActiveEdit";
            isActiveEdit.Properties.Caption = "Package Enabled";
            isActiveEdit.Properties.ContentAlignment = DevExpress.Utils.HorzAlignment.Center;
            isActiveEdit.Size = new System.Drawing.Size(120, 20);
            isActiveEdit.StyleController = layoutControl1;
            isActiveEdit.TabIndex = 4;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2, layoutControlItem3, layoutControlItem4, layoutControlItem5 });
            Root.Name = "Root";
            Root.Size = new System.Drawing.Size(167, 211);
            Root.TextLocation = DevExpress.Utils.Locations.Default;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = sessionCountEdit;
            layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new System.Drawing.Size(147, 24);
            layoutControlItem1.Text = "Session Count :";
            layoutControlItem1.TextSize = new System.Drawing.Size(80, 13);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = totalPriceEdit;
            layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new System.Drawing.Size(147, 24);
            layoutControlItem2.Text = "Total Price :";
            layoutControlItem2.TextSize = new System.Drawing.Size(80, 13);
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = installmentAllowedEdit;
            layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new System.Drawing.Size(147, 34);
            layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 10, 0);
            layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Center;
            layoutControlItem4.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            layoutControlItem4.Control = packageServiceEditButton;
            layoutControlItem4.Location = new System.Drawing.Point(0, 106);
            layoutControlItem4.MinSize = new System.Drawing.Size(50, 25);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new System.Drawing.Size(147, 60);
            layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Center;
            layoutControlItem5.Control = isActiveEdit;
            layoutControlItem5.Location = new System.Drawing.Point(0, 82);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.Size = new System.Drawing.Size(147, 24);
            layoutControlItem5.TextVisible = false;
            // 
            // PackageCardControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(layoutControl1);
            Name = "PackageCardControl";
            Size = new System.Drawing.Size(167, 211);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)sessionCountEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)totalPriceEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)installmentAllowedEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)isActiveEdit.Properties).EndInit();
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
        private DevExpress.XtraEditors.TextEdit sessionCountEdit;
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
    }
}
