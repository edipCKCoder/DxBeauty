namespace DXBeauty.UI
{
    partial class AddPackageControl
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
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            totalPrice = new DevExpress.XtraEditors.SpinEdit();
            packageName = new DevExpress.XtraEditors.TextEdit();
            sessionCount = new DevExpress.XtraEditors.SpinEdit();
            isActiveCheck = new DevExpress.XtraEditors.CheckEdit();
            isInstallmentAllowed = new DevExpress.XtraEditors.CheckEdit();
            savePackageButton = new DevExpress.XtraEditors.SimpleButton();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            simpleSeparator2 = new DevExpress.XtraLayout.SimpleSeparator();
            addPackageButton = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)totalPrice.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)packageName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sessionCount.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)isActiveCheck.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)isInstallmentAllowed.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)simpleSeparator1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)simpleSeparator2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)addPackageButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            SuspendLayout();
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(totalPrice);
            layoutControl1.Controls.Add(packageName);
            layoutControl1.Controls.Add(sessionCount);
            layoutControl1.Controls.Add(isActiveCheck);
            layoutControl1.Controls.Add(isInstallmentAllowed);
            layoutControl1.Controls.Add(savePackageButton);
            layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControl1.Location = new System.Drawing.Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(652, 0, 650, 400);
            layoutControl1.Root = Root;
            layoutControl1.Size = new System.Drawing.Size(420, 283);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // totalPrice
            // 
            totalPrice.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            totalPrice.Location = new System.Drawing.Point(129, 129);
            totalPrice.MaximumSize = new System.Drawing.Size(150, 0);
            totalPrice.Name = "totalPrice";
            totalPrice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            totalPrice.Properties.MaskSettings.Set("mask", "c");
            totalPrice.Properties.MaskSettings.Set("culture", "tr-TR");
            totalPrice.Properties.UseMaskAsDisplayFormat = true;
            totalPrice.Size = new System.Drawing.Size(150, 22);
            totalPrice.StyleController = layoutControl1;
            totalPrice.TabIndex = 7;
            // 
            // packageName
            // 
            packageName.Location = new System.Drawing.Point(129, 45);
            packageName.Name = "packageName";
            packageName.Size = new System.Drawing.Size(261, 22);
            packageName.StyleController = layoutControl1;
            packageName.TabIndex = 0;
            // 
            // sessionCount
            // 
            sessionCount.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            sessionCount.Location = new System.Drawing.Point(129, 87);
            sessionCount.MaximumSize = new System.Drawing.Size(75, 0);
            sessionCount.Name = "sessionCount";
            sessionCount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            sessionCount.Size = new System.Drawing.Size(75, 22);
            sessionCount.StyleController = layoutControl1;
            sessionCount.TabIndex = 2;
            // 
            // isActiveCheck
            // 
            isActiveCheck.Location = new System.Drawing.Point(30, 173);
            isActiveCheck.Name = "isActiveCheck";
            isActiveCheck.Properties.Caption = "Etkin / Devre Dışı";
            isActiveCheck.Size = new System.Drawing.Size(190, 20);
            isActiveCheck.StyleController = layoutControl1;
            isActiveCheck.TabIndex = 4;
            // 
            // isInstallmentAllowed
            // 
            isInstallmentAllowed.Location = new System.Drawing.Point(240, 173);
            isInstallmentAllowed.MaximumSize = new System.Drawing.Size(150, 0);
            isInstallmentAllowed.Name = "isInstallmentAllowed";
            isInstallmentAllowed.Properties.Caption = "Taksit Yapılabilir";
            isInstallmentAllowed.Properties.ContentAlignment = DevExpress.Utils.HorzAlignment.Center;
            isInstallmentAllowed.Size = new System.Drawing.Size(150, 20);
            isInstallmentAllowed.StyleController = layoutControl1;
            isInstallmentAllowed.TabIndex = 5;
            // 
            // savePackageButton
            // 
            savePackageButton.Location = new System.Drawing.Point(187, 218);
            savePackageButton.MaximumSize = new System.Drawing.Size(50, 0);
            savePackageButton.MinimumSize = new System.Drawing.Size(75, 30);
            savePackageButton.Name = "savePackageButton";
            savePackageButton.Size = new System.Drawing.Size(75, 30);
            savePackageButton.StyleController = layoutControl1;
            savePackageButton.TabIndex = 6;
            savePackageButton.Text = "Kaydet";
            savePackageButton.Click += savePackageButton_Click;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2, simpleSeparator1, layoutControlItem4, layoutControlItem5, simpleSeparator2, addPackageButton, layoutControlItem3 });
            Root.Name = "Root";
            Root.Size = new System.Drawing.Size(420, 283);
            Root.Spacing = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = packageName;
            layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            layoutControlItem1.Size = new System.Drawing.Size(380, 42);
            layoutControlItem1.Text = "Satış Paketi İsmi :";
            layoutControlItem1.TextSize = new System.Drawing.Size(87, 13);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Near;
            layoutControlItem2.Control = sessionCount;
            layoutControlItem2.Location = new System.Drawing.Point(0, 42);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            layoutControlItem2.Size = new System.Drawing.Size(380, 42);
            layoutControlItem2.Text = "Seans Sayısı :";
            layoutControlItem2.TextSize = new System.Drawing.Size(87, 13);
            // 
            // simpleSeparator1
            // 
            simpleSeparator1.Location = new System.Drawing.Point(0, 127);
            simpleSeparator1.Name = "simpleSeparator1";
            simpleSeparator1.Size = new System.Drawing.Size(380, 1);
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = isActiveCheck;
            layoutControlItem4.Location = new System.Drawing.Point(0, 128);
            layoutControlItem4.MaxSize = new System.Drawing.Size(0, 40);
            layoutControlItem4.MinSize = new System.Drawing.Size(120, 40);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            layoutControlItem4.Size = new System.Drawing.Size(210, 40);
            layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.Control = isInstallmentAllowed;
            layoutControlItem5.Location = new System.Drawing.Point(210, 128);
            layoutControlItem5.MaxSize = new System.Drawing.Size(170, 40);
            layoutControlItem5.MinSize = new System.Drawing.Size(170, 40);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            layoutControlItem5.Size = new System.Drawing.Size(170, 40);
            layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem5.TextVisible = false;
            // 
            // simpleSeparator2
            // 
            simpleSeparator2.Location = new System.Drawing.Point(0, 126);
            simpleSeparator2.Name = "simpleSeparator2";
            simpleSeparator2.Size = new System.Drawing.Size(380, 1);
            // 
            // addPackageButton
            // 
            addPackageButton.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Center;
            addPackageButton.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            addPackageButton.Control = savePackageButton;
            addPackageButton.Location = new System.Drawing.Point(0, 168);
            addPackageButton.MaxSize = new System.Drawing.Size(50, 50);
            addPackageButton.MinSize = new System.Drawing.Size(34, 50);
            addPackageButton.Name = "addPackageButton";
            addPackageButton.Size = new System.Drawing.Size(380, 60);
            addPackageButton.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            addPackageButton.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Near;
            layoutControlItem3.Control = totalPrice;
            layoutControlItem3.Location = new System.Drawing.Point(0, 84);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            layoutControlItem3.Size = new System.Drawing.Size(380, 42);
            layoutControlItem3.Text = "Toplam Fiyat :";
            layoutControlItem3.TextSize = new System.Drawing.Size(87, 13);
            // 
            // AddPackageControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(layoutControl1);
            Name = "AddPackageControl";
            Size = new System.Drawing.Size(420, 283);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)totalPrice.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)packageName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)sessionCount.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)isActiveCheck.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)isInstallmentAllowed.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)simpleSeparator1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)simpleSeparator2).EndInit();
            ((System.ComponentModel.ISupportInitialize)addPackageButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit packageName;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SpinEdit sessionCount;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.CheckEdit isActiveCheck;
        private DevExpress.XtraEditors.CheckEdit isInstallmentAllowed;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator2;
        private DevExpress.XtraEditors.SimpleButton savePackageButton;
        private DevExpress.XtraLayout.LayoutControlItem addPackageButton;
        private DevExpress.XtraEditors.SpinEdit totalPrice;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}
