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
            packageName = new DevExpress.XtraEditors.TextEdit();
            sessionCount = new DevExpress.XtraEditors.SpinEdit();
            totalPrice = new DevExpress.XtraEditors.TextEdit();
            isActiveCheck = new DevExpress.XtraEditors.CheckEdit();
            isInstallmentAllowed = new DevExpress.XtraEditors.CheckEdit();
            savePackageButton = new DevExpress.XtraEditors.SimpleButton();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            simpleSeparator2 = new DevExpress.XtraLayout.SimpleSeparator();
            addPackageButton = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)packageName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sessionCount.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)totalPrice.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)isActiveCheck.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)isInstallmentAllowed.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)simpleSeparator1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)simpleSeparator2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)addPackageButton).BeginInit();
            SuspendLayout();
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(packageName);
            layoutControl1.Controls.Add(sessionCount);
            layoutControl1.Controls.Add(totalPrice);
            layoutControl1.Controls.Add(isActiveCheck);
            layoutControl1.Controls.Add(isInstallmentAllowed);
            layoutControl1.Controls.Add(savePackageButton);
            layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControl1.Location = new System.Drawing.Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(652, 0, 650, 400);
            layoutControl1.Root = Root;
            layoutControl1.Size = new System.Drawing.Size(417, 415);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // packageName
            // 
            packageName.Location = new System.Drawing.Point(108, 36);
            packageName.Name = "packageName";
            packageName.Size = new System.Drawing.Size(287, 20);
            packageName.StyleController = layoutControl1;
            packageName.TabIndex = 0;
            // 
            // sessionCount
            // 
            sessionCount.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            sessionCount.Location = new System.Drawing.Point(108, 60);
            sessionCount.Name = "sessionCount";
            sessionCount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            sessionCount.Size = new System.Drawing.Size(287, 20);
            sessionCount.StyleController = layoutControl1;
            sessionCount.TabIndex = 2;
            // 
            // totalPrice
            // 
            totalPrice.Location = new System.Drawing.Point(108, 84);
            totalPrice.Name = "totalPrice";
            totalPrice.Size = new System.Drawing.Size(287, 20);
            totalPrice.StyleController = layoutControl1;
            totalPrice.TabIndex = 3;
            // 
            // isActiveCheck
            // 
            isActiveCheck.Location = new System.Drawing.Point(22, 110);
            isActiveCheck.Name = "isActiveCheck";
            isActiveCheck.Properties.Caption = "Enable";
            isActiveCheck.Size = new System.Drawing.Size(184, 20);
            isActiveCheck.StyleController = layoutControl1;
            isActiveCheck.TabIndex = 4;
            // 
            // isInstallmentAllowed
            // 
            isInstallmentAllowed.Location = new System.Drawing.Point(210, 110);
            isInstallmentAllowed.Name = "isInstallmentAllowed";
            isInstallmentAllowed.Properties.Caption = "Installment Allowed";
            isInstallmentAllowed.Size = new System.Drawing.Size(185, 20);
            isInstallmentAllowed.StyleController = layoutControl1;
            isInstallmentAllowed.TabIndex = 5;
            // 
            // savePackageButton
            // 
            savePackageButton.Location = new System.Drawing.Point(22, 134);
            savePackageButton.Name = "savePackageButton";
            savePackageButton.Size = new System.Drawing.Size(373, 22);
            savePackageButton.StyleController = layoutControl1;
            savePackageButton.TabIndex = 6;
            savePackageButton.Text = "Save";
            savePackageButton.Click += savePackageButton_Click;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2, layoutControlItem3, simpleSeparator1, layoutControlItem4, layoutControlItem5, simpleSeparator2, addPackageButton });
            Root.Name = "Root";
            Root.Size = new System.Drawing.Size(417, 415);
            Root.Spacing = new DevExpress.XtraLayout.Utils.Padding(10, 10, 3, 10);
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = packageName;
            layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new System.Drawing.Size(377, 24);
            layoutControlItem1.Text = "Package Name";
            layoutControlItem1.TextSize = new System.Drawing.Size(74, 13);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = sessionCount;
            layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new System.Drawing.Size(377, 24);
            layoutControlItem2.Text = "Session Count";
            layoutControlItem2.TextSize = new System.Drawing.Size(74, 13);
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = totalPrice;
            layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new System.Drawing.Size(377, 24);
            layoutControlItem3.Text = "Total Price";
            layoutControlItem3.TextSize = new System.Drawing.Size(74, 13);
            // 
            // simpleSeparator1
            // 
            simpleSeparator1.Location = new System.Drawing.Point(0, 73);
            simpleSeparator1.Name = "simpleSeparator1";
            simpleSeparator1.Size = new System.Drawing.Size(377, 1);
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = isActiveCheck;
            layoutControlItem4.Location = new System.Drawing.Point(0, 74);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new System.Drawing.Size(188, 24);
            layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.Control = isInstallmentAllowed;
            layoutControlItem5.Location = new System.Drawing.Point(188, 74);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.Size = new System.Drawing.Size(189, 24);
            layoutControlItem5.TextVisible = false;
            // 
            // simpleSeparator2
            // 
            simpleSeparator2.Location = new System.Drawing.Point(0, 72);
            simpleSeparator2.Name = "simpleSeparator2";
            simpleSeparator2.Size = new System.Drawing.Size(377, 1);
            // 
            // addPackageButton
            // 
            addPackageButton.Control = savePackageButton;
            addPackageButton.Location = new System.Drawing.Point(0, 98);
            addPackageButton.Name = "addPackageButton";
            addPackageButton.Size = new System.Drawing.Size(377, 263);
            addPackageButton.TextVisible = false;
            // 
            // AddPackageControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(layoutControl1);
            Name = "AddPackageControl";
            Size = new System.Drawing.Size(417, 415);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)packageName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)sessionCount.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)totalPrice.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)isActiveCheck.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)isInstallmentAllowed.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)simpleSeparator1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)simpleSeparator2).EndInit();
            ((System.ComponentModel.ISupportInitialize)addPackageButton).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit packageName;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SpinEdit sessionCount;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.TextEdit totalPrice;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.CheckEdit isActiveCheck;
        private DevExpress.XtraEditors.CheckEdit isInstallmentAllowed;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator2;
        private DevExpress.XtraEditors.SimpleButton savePackageButton;
        private DevExpress.XtraLayout.LayoutControlItem addPackageButton;
    }
}
