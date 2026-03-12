namespace DXBeauty.UI
{
    partial class PaymentPlanWizardControl
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
            cmbIntervalType = new DevExpress.XtraEditors.ComboBoxEdit();
            spinIntervalValue = new DevExpress.XtraEditors.SpinEdit();
            btnCancel = new DevExpress.XtraEditors.SimpleButton();
            gridInstallments = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            calcRemainingDebt = new DevExpress.XtraEditors.CalcEdit();
            calcDownPayment = new DevExpress.XtraEditors.CalcEdit();
            calcTotalPrice = new DevExpress.XtraEditors.CalcEdit();
            rgPaymentType = new DevExpress.XtraEditors.RadioGroup();
            spinInstallmentCount = new DevExpress.XtraEditors.SpinEdit();
            btnGeneratePlan = new DevExpress.XtraEditors.SimpleButton();
            btnSave = new DevExpress.XtraEditors.SimpleButton();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            lblPackageName = new DevExpress.XtraLayout.SimpleLabelItem();
            calcTotalPriceLayout = new DevExpress.XtraLayout.LayoutControlItem();
            rgPaymentTypeLayout = new DevExpress.XtraLayout.LayoutControlItem();
            calcDownPaymentLayout = new DevExpress.XtraLayout.LayoutControlItem();
            calcRemainingDebtLayout = new DevExpress.XtraLayout.LayoutControlItem();
            simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            spinInstallmentCountLayout = new DevExpress.XtraLayout.LayoutControlItem();
            btnGeneratePlanLayout = new DevExpress.XtraLayout.LayoutControlItem();
            gridInstallmentsLayout = new DevExpress.XtraLayout.LayoutControlItem();
            btnSaveLayout = new DevExpress.XtraLayout.LayoutControlItem();
            btnCancelLayout = new DevExpress.XtraLayout.LayoutControlItem();
            spinIntervalValueLayout = new DevExpress.XtraLayout.LayoutControlItem();
            cmbIntervalTypeLayout = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cmbIntervalType.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)spinIntervalValue.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridInstallments).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)calcRemainingDebt.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)calcDownPayment.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)calcTotalPrice.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rgPaymentType.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)spinInstallmentCount.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lblPackageName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)calcTotalPriceLayout).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rgPaymentTypeLayout).BeginInit();
            ((System.ComponentModel.ISupportInitialize)calcDownPaymentLayout).BeginInit();
            ((System.ComponentModel.ISupportInitialize)calcRemainingDebtLayout).BeginInit();
            ((System.ComponentModel.ISupportInitialize)simpleSeparator1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)spinInstallmentCountLayout).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnGeneratePlanLayout).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridInstallmentsLayout).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnSaveLayout).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnCancelLayout).BeginInit();
            ((System.ComponentModel.ISupportInitialize)spinIntervalValueLayout).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmbIntervalTypeLayout).BeginInit();
            SuspendLayout();
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(cmbIntervalType);
            layoutControl1.Controls.Add(spinIntervalValue);
            layoutControl1.Controls.Add(btnCancel);
            layoutControl1.Controls.Add(gridInstallments);
            layoutControl1.Controls.Add(calcRemainingDebt);
            layoutControl1.Controls.Add(calcDownPayment);
            layoutControl1.Controls.Add(calcTotalPrice);
            layoutControl1.Controls.Add(rgPaymentType);
            layoutControl1.Controls.Add(spinInstallmentCount);
            layoutControl1.Controls.Add(btnGeneratePlan);
            layoutControl1.Controls.Add(btnSave);
            layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControl1.Location = new System.Drawing.Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1100, 295, 650, 400);
            layoutControl1.Root = Root;
            layoutControl1.Size = new System.Drawing.Size(717, 565);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // cmbIntervalType
            // 
            cmbIntervalType.Location = new System.Drawing.Point(105, 165);
            cmbIntervalType.Name = "cmbIntervalType";
            cmbIntervalType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbIntervalType.Properties.Items.AddRange(new object[] { "Ay", "Hafta", "Gün" });
            cmbIntervalType.Size = new System.Drawing.Size(126, 22);
            cmbIntervalType.StyleController = layoutControl1;
            cmbIntervalType.TabIndex = 11;
            // 
            // spinIntervalValue
            // 
            spinIntervalValue.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            spinIntervalValue.Location = new System.Drawing.Point(339, 165);
            spinIntervalValue.Name = "spinIntervalValue";
            spinIntervalValue.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            spinIntervalValue.Size = new System.Drawing.Size(116, 22);
            spinIntervalValue.StyleController = layoutControl1;
            spinIntervalValue.TabIndex = 5;
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(360, 531);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(345, 22);
            btnCancel.StyleController = layoutControl1;
            btnCancel.TabIndex = 10;
            btnCancel.Text = "İptal Et";
            // 
            // gridInstallments
            // 
            gridInstallments.Location = new System.Drawing.Point(12, 217);
            gridInstallments.MainView = gridView1;
            gridInstallments.Name = "gridInstallments";
            gridInstallments.Size = new System.Drawing.Size(693, 310);
            gridInstallments.TabIndex = 8;
            gridInstallments.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.GridControl = gridInstallments;
            gridView1.Name = "gridView1";
            // 
            // calcRemainingDebt
            // 
            calcRemainingDebt.Location = new System.Drawing.Point(135, 138);
            calcRemainingDebt.Name = "calcRemainingDebt";
            calcRemainingDebt.Properties.AppearanceReadOnly.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Critical;
            calcRemainingDebt.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            calcRemainingDebt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            calcRemainingDebt.Properties.ReadOnly = true;
            calcRemainingDebt.Size = new System.Drawing.Size(570, 22);
            calcRemainingDebt.StyleController = layoutControl1;
            calcRemainingDebt.TabIndex = 4;
            // 
            // calcDownPayment
            // 
            calcDownPayment.Location = new System.Drawing.Point(135, 112);
            calcDownPayment.Name = "calcDownPayment";
            calcDownPayment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            calcDownPayment.Size = new System.Drawing.Size(570, 22);
            calcDownPayment.StyleController = layoutControl1;
            calcDownPayment.TabIndex = 3;
            calcDownPayment.EditValueChanged += calcDownPayment_EditValueChanged;
            // 
            // calcTotalPrice
            // 
            calcTotalPrice.Location = new System.Drawing.Point(135, 29);
            calcTotalPrice.Name = "calcTotalPrice";
            calcTotalPrice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            calcTotalPrice.Properties.ReadOnly = true;
            calcTotalPrice.Size = new System.Drawing.Size(570, 22);
            calcTotalPrice.StyleController = layoutControl1;
            calcTotalPrice.TabIndex = 0;
            // 
            // rgPaymentType
            // 
            rgPaymentType.Location = new System.Drawing.Point(12, 72);
            rgPaymentType.Name = "rgPaymentType";
            rgPaymentType.Properties.Columns = 3;
            rgPaymentType.Properties.ItemHorzAlignment = DevExpress.XtraEditors.RadioItemHorzAlignment.Center;
            rgPaymentType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] { new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Peşin"), new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Taksit"), new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Açık Hesap", true, null, "") });
            rgPaymentType.Properties.ItemsLayout = DevExpress.XtraEditors.RadioGroupItemsLayout.Flow;
            rgPaymentType.Size = new System.Drawing.Size(693, 36);
            rgPaymentType.StyleController = layoutControl1;
            rgPaymentType.TabIndex = 2;
            rgPaymentType.SelectedIndexChanged += rgPaymentType_SelectedIndexChanged;
            // 
            // spinInstallmentCount
            // 
            spinInstallmentCount.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            spinInstallmentCount.Location = new System.Drawing.Point(530, 165);
            spinInstallmentCount.Name = "spinInstallmentCount";
            spinInstallmentCount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            spinInstallmentCount.Size = new System.Drawing.Size(175, 22);
            spinInstallmentCount.StyleController = layoutControl1;
            spinInstallmentCount.TabIndex = 6;
            // 
            // btnGeneratePlan
            // 
            btnGeneratePlan.Location = new System.Drawing.Point(12, 191);
            btnGeneratePlan.Name = "btnGeneratePlan";
            btnGeneratePlan.Size = new System.Drawing.Size(693, 22);
            btnGeneratePlan.StyleController = layoutControl1;
            btnGeneratePlan.TabIndex = 7;
            btnGeneratePlan.Text = "Planı Oluştur";
            btnGeneratePlan.Click += btnGeneratePlan_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new System.Drawing.Point(12, 531);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(344, 22);
            btnSave.StyleController = layoutControl1;
            btnSave.TabIndex = 9;
            btnSave.Text = "Onayla ve Satışı Tamamla";
            btnSave.Click += btnSave_Click;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { lblPackageName, calcTotalPriceLayout, rgPaymentTypeLayout, calcDownPaymentLayout, calcRemainingDebtLayout, simpleSeparator1, spinInstallmentCountLayout, btnGeneratePlanLayout, gridInstallmentsLayout, btnSaveLayout, btnCancelLayout, spinIntervalValueLayout, cmbIntervalTypeLayout });
            Root.Name = "Root";
            Root.Size = new System.Drawing.Size(717, 565);
            Root.TextVisible = false;
            // 
            // lblPackageName
            // 
            lblPackageName.Location = new System.Drawing.Point(0, 0);
            lblPackageName.Name = "lblPackageName";
            lblPackageName.Size = new System.Drawing.Size(697, 17);
            lblPackageName.TextSize = new System.Drawing.Size(111, 13);
            // 
            // calcTotalPriceLayout
            // 
            calcTotalPriceLayout.Control = calcTotalPrice;
            calcTotalPriceLayout.Location = new System.Drawing.Point(0, 17);
            calcTotalPriceLayout.Name = "calcTotalPriceLayout";
            calcTotalPriceLayout.Size = new System.Drawing.Size(697, 26);
            calcTotalPriceLayout.Text = "Toplam tutar :";
            calcTotalPriceLayout.TextSize = new System.Drawing.Size(111, 13);
            // 
            // rgPaymentTypeLayout
            // 
            rgPaymentTypeLayout.AppearanceItemCaption.Options.UseTextOptions = true;
            rgPaymentTypeLayout.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            rgPaymentTypeLayout.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Center;
            rgPaymentTypeLayout.Control = rgPaymentType;
            rgPaymentTypeLayout.Location = new System.Drawing.Point(0, 43);
            rgPaymentTypeLayout.MaxSize = new System.Drawing.Size(697, 0);
            rgPaymentTypeLayout.MinSize = new System.Drawing.Size(697, 55);
            rgPaymentTypeLayout.Name = "rgPaymentTypeLayout";
            rgPaymentTypeLayout.Size = new System.Drawing.Size(697, 57);
            rgPaymentTypeLayout.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            rgPaymentTypeLayout.Text = "Ödeme Türü";
            rgPaymentTypeLayout.TextLocation = DevExpress.Utils.Locations.Top;
            rgPaymentTypeLayout.TextSize = new System.Drawing.Size(111, 13);
            // 
            // calcDownPaymentLayout
            // 
            calcDownPaymentLayout.Control = calcDownPayment;
            calcDownPaymentLayout.Location = new System.Drawing.Point(0, 100);
            calcDownPaymentLayout.Name = "calcDownPaymentLayout";
            calcDownPaymentLayout.Size = new System.Drawing.Size(697, 26);
            calcDownPaymentLayout.Text = "Peşinat Tutarı :";
            calcDownPaymentLayout.TextSize = new System.Drawing.Size(111, 13);
            // 
            // calcRemainingDebtLayout
            // 
            calcRemainingDebtLayout.Control = calcRemainingDebt;
            calcRemainingDebtLayout.Location = new System.Drawing.Point(0, 126);
            calcRemainingDebtLayout.Name = "calcRemainingDebtLayout";
            calcRemainingDebtLayout.Size = new System.Drawing.Size(697, 26);
            calcRemainingDebtLayout.Text = "Kalan Bakiye :";
            calcRemainingDebtLayout.TextSize = new System.Drawing.Size(111, 13);
            // 
            // simpleSeparator1
            // 
            simpleSeparator1.Location = new System.Drawing.Point(0, 152);
            simpleSeparator1.Name = "simpleSeparator1";
            simpleSeparator1.Size = new System.Drawing.Size(697, 1);
            // 
            // spinInstallmentCountLayout
            // 
            spinInstallmentCountLayout.Control = spinInstallmentCount;
            spinInstallmentCountLayout.Location = new System.Drawing.Point(447, 153);
            spinInstallmentCountLayout.Name = "spinInstallmentCountLayout";
            spinInstallmentCountLayout.Size = new System.Drawing.Size(250, 26);
            spinInstallmentCountLayout.Text = "Taksit Sayısı :";
            spinInstallmentCountLayout.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            spinInstallmentCountLayout.TextSize = new System.Drawing.Size(66, 13);
            spinInstallmentCountLayout.TextToControlDistance = 5;
            // 
            // btnGeneratePlanLayout
            // 
            btnGeneratePlanLayout.ContentVertAlignment = DevExpress.Utils.VertAlignment.Top;
            btnGeneratePlanLayout.Control = btnGeneratePlan;
            btnGeneratePlanLayout.Location = new System.Drawing.Point(0, 179);
            btnGeneratePlanLayout.Name = "btnGeneratePlanLayout";
            btnGeneratePlanLayout.Size = new System.Drawing.Size(697, 26);
            btnGeneratePlanLayout.TextVisible = false;
            // 
            // gridInstallmentsLayout
            // 
            gridInstallmentsLayout.Control = gridInstallments;
            gridInstallmentsLayout.Location = new System.Drawing.Point(0, 205);
            gridInstallmentsLayout.Name = "gridInstallmentsLayout";
            gridInstallmentsLayout.Size = new System.Drawing.Size(697, 314);
            gridInstallmentsLayout.TextVisible = false;
            // 
            // btnSaveLayout
            // 
            btnSaveLayout.Control = btnSave;
            btnSaveLayout.Location = new System.Drawing.Point(0, 519);
            btnSaveLayout.MaxSize = new System.Drawing.Size(348, 26);
            btnSaveLayout.MinSize = new System.Drawing.Size(348, 26);
            btnSaveLayout.Name = "btnSaveLayout";
            btnSaveLayout.Size = new System.Drawing.Size(348, 26);
            btnSaveLayout.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            btnSaveLayout.TextVisible = false;
            // 
            // btnCancelLayout
            // 
            btnCancelLayout.Control = btnCancel;
            btnCancelLayout.Location = new System.Drawing.Point(348, 519);
            btnCancelLayout.MaxSize = new System.Drawing.Size(349, 26);
            btnCancelLayout.MinSize = new System.Drawing.Size(349, 26);
            btnCancelLayout.Name = "btnCancelLayout";
            btnCancelLayout.Size = new System.Drawing.Size(349, 26);
            btnCancelLayout.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            btnCancelLayout.TextVisible = false;
            // 
            // spinIntervalValueLayout
            // 
            spinIntervalValueLayout.Control = spinIntervalValue;
            spinIntervalValueLayout.Location = new System.Drawing.Point(223, 153);
            spinIntervalValueLayout.Name = "spinIntervalValueLayout";
            spinIntervalValueLayout.Size = new System.Drawing.Size(224, 26);
            spinIntervalValueLayout.Text = "Vade Aralığı Sayısı :";
            spinIntervalValueLayout.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            spinIntervalValueLayout.TextSize = new System.Drawing.Size(99, 13);
            spinIntervalValueLayout.TextToControlDistance = 5;
            // 
            // cmbIntervalTypeLayout
            // 
            cmbIntervalTypeLayout.Control = cmbIntervalType;
            cmbIntervalTypeLayout.Location = new System.Drawing.Point(0, 153);
            cmbIntervalTypeLayout.Name = "cmbIntervalTypeLayout";
            cmbIntervalTypeLayout.Size = new System.Drawing.Size(223, 26);
            cmbIntervalTypeLayout.Text = "Vade Aralığı Türü";
            cmbIntervalTypeLayout.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            cmbIntervalTypeLayout.TextSize = new System.Drawing.Size(88, 13);
            cmbIntervalTypeLayout.TextToControlDistance = 5;
            // 
            // PaymentPlanWizardControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(layoutControl1);
            Name = "PaymentPlanWizardControl";
            Size = new System.Drawing.Size(717, 565);
            Load += PaymentPlanWizardControl_Load;
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)cmbIntervalType.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)spinIntervalValue.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridInstallments).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)calcRemainingDebt.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)calcDownPayment.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)calcTotalPrice.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)rgPaymentType.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)spinInstallmentCount.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)lblPackageName).EndInit();
            ((System.ComponentModel.ISupportInitialize)calcTotalPriceLayout).EndInit();
            ((System.ComponentModel.ISupportInitialize)rgPaymentTypeLayout).EndInit();
            ((System.ComponentModel.ISupportInitialize)calcDownPaymentLayout).EndInit();
            ((System.ComponentModel.ISupportInitialize)calcRemainingDebtLayout).EndInit();
            ((System.ComponentModel.ISupportInitialize)simpleSeparator1).EndInit();
            ((System.ComponentModel.ISupportInitialize)spinInstallmentCountLayout).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnGeneratePlanLayout).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridInstallmentsLayout).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnSaveLayout).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnCancelLayout).EndInit();
            ((System.ComponentModel.ISupportInitialize)spinIntervalValueLayout).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmbIntervalTypeLayout).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.CalcEdit calcTotalPrice;
        private DevExpress.XtraLayout.SimpleLabelItem lblPackageName;
        private DevExpress.XtraLayout.LayoutControlItem calcTotalPriceLayout;
        private DevExpress.XtraEditors.RadioGroup rgPaymentType;
        private DevExpress.XtraLayout.LayoutControlItem rgPaymentTypeLayout;
        private DevExpress.XtraEditors.CalcEdit calcDownPayment;
        private DevExpress.XtraLayout.LayoutControlItem calcDownPaymentLayout;
        private DevExpress.XtraEditors.CalcEdit calcRemainingDebt;
        private DevExpress.XtraLayout.LayoutControlItem calcRemainingDebtLayout;
        private DevExpress.XtraEditors.SpinEdit spinInstallmentCount;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator1;
        private DevExpress.XtraLayout.LayoutControlItem spinInstallmentCountLayout;
        private DevExpress.XtraEditors.SimpleButton btnGeneratePlan;
        private DevExpress.XtraLayout.LayoutControlItem btnGeneratePlanLayout;
        private DevExpress.XtraGrid.GridControl gridInstallments;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem gridInstallmentsLayout;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraLayout.LayoutControlItem btnSaveLayout;
        private DevExpress.XtraLayout.LayoutControlItem btnCancelLayout;
        private DevExpress.XtraEditors.ComboBoxEdit cmbIntervalType;
        private DevExpress.XtraEditors.SpinEdit spinIntervalValue;
        private DevExpress.XtraLayout.LayoutControlItem spinIntervalValueLayout;
        private DevExpress.XtraLayout.LayoutControlItem cmbIntervalTypeLayout;
    }
}
