namespace DXBeauty.UI
{
    partial class CreateServiceControl
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
            groupControl1 = new DevExpress.XtraEditors.GroupControl();
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            serviceName = new DevExpress.XtraEditors.TextEdit();
            createServiceButton = new DevExpress.XtraEditors.SimpleButton();
            serviceDescription = new DevExpress.XtraEditors.TextEdit();
            isActive = new DevExpress.XtraEditors.CheckEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)serviceName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)serviceDescription.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)isActive.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            SuspendLayout();
            // 
            // groupControl1
            // 
            groupControl1.AutoSize = true;
            groupControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            groupControl1.Controls.Add(layoutControl1);
            groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupControl1.Location = new System.Drawing.Point(0, 0);
            groupControl1.MaximumSize = new System.Drawing.Size(0, 250);
            groupControl1.MinimumSize = new System.Drawing.Size(0, 150);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new System.Drawing.Size(902, 250);
            groupControl1.TabIndex = 0;
            groupControl1.Text = "Service informations";
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(serviceName);
            layoutControl1.Controls.Add(createServiceButton);
            layoutControl1.Controls.Add(serviceDescription);
            layoutControl1.Controls.Add(isActive);
            layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControl1.Location = new System.Drawing.Point(2, 23);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1012, 157, 650, 400);
            layoutControl1.Root = Root;
            layoutControl1.Size = new System.Drawing.Size(898, 225);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // serviceName
            // 
            serviceName.Location = new System.Drawing.Point(2, 18);
            serviceName.Name = "serviceName";
            serviceName.Size = new System.Drawing.Size(894, 20);
            serviceName.StyleController = layoutControl1;
            serviceName.TabIndex = 0;
            // 
            // createServiceButton
            // 
            createServiceButton.Location = new System.Drawing.Point(2, 125);
            createServiceButton.Margin = new System.Windows.Forms.Padding(0);
            createServiceButton.Name = "createServiceButton";
            createServiceButton.Size = new System.Drawing.Size(894, 22);
            createServiceButton.StyleController = layoutControl1;
            createServiceButton.TabIndex = 4;
            createServiceButton.Text = "Save";
            createServiceButton.Click += createServiceButton_Click;
            // 
            // serviceDescription
            // 
            serviceDescription.Location = new System.Drawing.Point(2, 58);
            serviceDescription.MaximumSize = new System.Drawing.Size(0, 30);
            serviceDescription.MinimumSize = new System.Drawing.Size(0, 30);
            serviceDescription.Name = "serviceDescription";
            serviceDescription.Size = new System.Drawing.Size(894, 30);
            serviceDescription.StyleController = layoutControl1;
            serviceDescription.TabIndex = 2;
            // 
            // isActive
            // 
            isActive.Location = new System.Drawing.Point(36, 101);
            isActive.Name = "isActive";
            isActive.Properties.Caption = "";
            isActive.Size = new System.Drawing.Size(860, 20);
            isActive.StyleController = layoutControl1;
            isActive.TabIndex = 3;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.False;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem3, layoutControlItem2, layoutControlItem4 });
            Root.Name = "Root";
            Root.Size = new System.Drawing.Size(898, 225);
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = serviceName;
            layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new System.Drawing.Size(898, 40);
            layoutControlItem1.Text = "Service Name";
            layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem1.TextSize = new System.Drawing.Size(91, 13);
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = createServiceButton;
            layoutControlItem3.Location = new System.Drawing.Point(0, 123);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new System.Drawing.Size(898, 102);
            layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = serviceDescription;
            layoutControlItem2.Location = new System.Drawing.Point(0, 40);
            layoutControlItem2.MaxSize = new System.Drawing.Size(0, 59);
            layoutControlItem2.MinSize = new System.Drawing.Size(97, 59);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new System.Drawing.Size(898, 59);
            layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem2.Text = "Service Description";
            layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem2.TextSize = new System.Drawing.Size(91, 13);
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = isActive;
            layoutControlItem4.Location = new System.Drawing.Point(0, 99);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2);
            layoutControlItem4.Size = new System.Drawing.Size(898, 24);
            layoutControlItem4.Text = "Aktif";
            layoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Left;
            layoutControlItem4.TextSize = new System.Drawing.Size(30, 13);
            layoutControlItem4.TextToControlDistance = 1;
            // 
            // CreateServiceControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(groupControl1);
            Name = "CreateServiceControl";
            Size = new System.Drawing.Size(902, 546);
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)serviceName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)serviceDescription.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)isActive.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit serviceName;
        private DevExpress.XtraEditors.SimpleButton createServiceButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.TextEdit serviceDescription;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.CheckEdit isActive;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}
