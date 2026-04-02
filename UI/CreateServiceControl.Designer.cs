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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateServiceControl));
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            serviceName = new DevExpress.XtraEditors.TextEdit();
            serviceDescription = new DevExpress.XtraEditors.TextEdit();
            isActive = new DevExpress.XtraEditors.CheckEdit();
            createServiceButton = new DevExpress.XtraEditors.SimpleButton();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)serviceName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)serviceDescription.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)isActive.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem3).BeginInit();
            SuspendLayout();
            // 
            // layoutControl1
            // 
            layoutControl1.AutoScroll = false;
            layoutControl1.Controls.Add(serviceName);
            layoutControl1.Controls.Add(serviceDescription);
            layoutControl1.Controls.Add(isActive);
            layoutControl1.Controls.Add(createServiceButton);
            layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControl1.Location = new System.Drawing.Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(663, 48, 650, 400);
            layoutControl1.Root = Root;
            layoutControl1.Size = new System.Drawing.Size(280, 243);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // serviceName
            // 
            serviceName.Location = new System.Drawing.Point(23, 55);
            serviceName.Name = "serviceName";
            serviceName.Size = new System.Drawing.Size(234, 22);
            serviceName.StyleController = layoutControl1;
            serviceName.TabIndex = 0;
            // 
            // serviceDescription
            // 
            serviceDescription.Location = new System.Drawing.Point(23, 98);
            serviceDescription.Name = "serviceDescription";
            serviceDescription.Size = new System.Drawing.Size(234, 22);
            serviceDescription.StyleController = layoutControl1;
            serviceDescription.TabIndex = 2;
            // 
            // isActive
            // 
            isActive.Location = new System.Drawing.Point(193, 124);
            isActive.MaximumSize = new System.Drawing.Size(30, 0);
            isActive.Name = "isActive";
            isActive.Properties.Caption = "";
            isActive.Properties.ContentAlignment = DevExpress.Utils.HorzAlignment.Center;
            isActive.Size = new System.Drawing.Size(30, 20);
            isActive.StyleController = layoutControl1;
            isActive.TabIndex = 4;
            // 
            // createServiceButton
            // 
            createServiceButton.Cursor = System.Windows.Forms.Cursors.Hand;
            createServiceButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            createServiceButton.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("createServiceButton.ImageOptions.SvgImage");
            createServiceButton.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            createServiceButton.Location = new System.Drawing.Point(70, 159);
            createServiceButton.MaximumSize = new System.Drawing.Size(140, 0);
            createServiceButton.MinimumSize = new System.Drawing.Size(0, 50);
            createServiceButton.Name = "createServiceButton";
            createServiceButton.Size = new System.Drawing.Size(140, 50);
            createServiceButton.StyleController = layoutControl1;
            createServiceButton.TabIndex = 5;
            createServiceButton.Text = "Kaydet";
            createServiceButton.Click += createServiceButton_Click;
            // 
            // Root
            // 
            Root.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2, layoutControlItem3, layoutControlItem4 });
            Root.Name = "Root";
            Root.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            Root.Size = new System.Drawing.Size(280, 243);
            Root.Spacing = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            Root.Text = "Yeni Hizmet";
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = serviceName;
            layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new System.Drawing.Size(238, 43);
            layoutControlItem1.Text = "Hizmet Adı";
            layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem1.TextSize = new System.Drawing.Size(50, 13);
            layoutControlItem1.TextToControlDistance = 4;
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = serviceDescription;
            layoutControlItem2.Location = new System.Drawing.Point(0, 43);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new System.Drawing.Size(238, 43);
            layoutControlItem2.Text = "Açıklama";
            layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem2.TextSize = new System.Drawing.Size(41, 13);
            layoutControlItem2.TextToControlDistance = 4;
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Center;
            layoutControlItem3.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            layoutControlItem3.Control = isActive;
            layoutControlItem3.Location = new System.Drawing.Point(0, 86);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new System.Drawing.Size(238, 24);
            layoutControlItem3.Text = "Kullanımda / Kullanım Dışı :";
            layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Left;
            layoutControlItem3.TextSize = new System.Drawing.Size(124, 13);
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Center;
            layoutControlItem4.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            layoutControlItem4.Control = createServiceButton;
            layoutControlItem4.Location = new System.Drawing.Point(0, 110);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new System.Drawing.Size(238, 76);
            layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            emptySpaceItem3.Location = new System.Drawing.Point(0, 78);
            emptySpaceItem3.MaxSize = new System.Drawing.Size(0, 30);
            emptySpaceItem3.MinSize = new System.Drawing.Size(104, 20);
            emptySpaceItem3.Name = "emptySpaceItem2";
            emptySpaceItem3.Size = new System.Drawing.Size(722, 30);
            emptySpaceItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            // 
            // CreateServiceControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            Controls.Add(layoutControl1);
            Name = "CreateServiceControl";
            Size = new System.Drawing.Size(280, 243);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)serviceName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)serviceDescription.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)isActive.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit serviceName;
        private DevExpress.XtraEditors.TextEdit serviceDescription;
        private DevExpress.XtraEditors.CheckEdit isActive;
        private DevExpress.XtraEditors.SimpleButton createServiceButton;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
    }
}
