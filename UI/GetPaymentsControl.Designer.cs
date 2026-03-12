namespace DXBeauty.UI
{
    partial class GetPaymentsControl
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
            groupControl1 = new DevExpress.XtraEditors.GroupControl();
            layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            btnSavePayment = new DevExpress.XtraEditors.SimpleButton();
            txtDescription = new DevExpress.XtraEditors.MemoEdit();
            calcAmount = new DevExpress.XtraEditors.CalcEdit();
            cmbPaymentMethod = new DevExpress.XtraEditors.ComboBoxEdit();
            dtPaymentDate = new DevExpress.XtraEditors.DateEdit();
            slueCustomer = new DevExpress.XtraEditors.SearchLookUpEdit();
            searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)layoutControl2).BeginInit();
            layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtDescription.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)calcAmount.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmbPaymentMethod.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtPaymentDate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtPaymentDate.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)slueCustomer.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)searchLookUpEdit1View).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            SuspendLayout();
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(groupControl1);
            layoutControl1.Controls.Add(gridControl1);
            layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControl1.Location = new System.Drawing.Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.Root = Root;
            layoutControl1.Size = new System.Drawing.Size(713, 474);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // groupControl1
            // 
            groupControl1.Controls.Add(layoutControl2);
            groupControl1.Location = new System.Drawing.Point(358, 12);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new System.Drawing.Size(343, 450);
            groupControl1.TabIndex = 5;
            groupControl1.Text = "Tahsilat Bilgileri";
            // 
            // layoutControl2
            // 
            layoutControl2.Controls.Add(btnSavePayment);
            layoutControl2.Controls.Add(txtDescription);
            layoutControl2.Controls.Add(calcAmount);
            layoutControl2.Controls.Add(cmbPaymentMethod);
            layoutControl2.Controls.Add(dtPaymentDate);
            layoutControl2.Controls.Add(slueCustomer);
            layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControl2.Location = new System.Drawing.Point(2, 22);
            layoutControl2.Name = "layoutControl2";
            layoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1082, 212, 650, 400);
            layoutControl2.Root = layoutControlGroup1;
            layoutControl2.Size = new System.Drawing.Size(339, 426);
            layoutControl2.TabIndex = 0;
            layoutControl2.Text = "layoutControl2";
            // 
            // btnSavePayment
            // 
            btnSavePayment.Location = new System.Drawing.Point(12, 392);
            btnSavePayment.Name = "btnSavePayment";
            btnSavePayment.Size = new System.Drawing.Size(315, 22);
            btnSavePayment.StyleController = layoutControl2;
            btnSavePayment.TabIndex = 11;
            btnSavePayment.Text = "Kaydet (Tahsilatı Al)";
            btnSavePayment.Click += btnSavePayment_Click;
            // 
            // txtDescription
            // 
            txtDescription.Location = new System.Drawing.Point(123, 147);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new System.Drawing.Size(204, 241);
            txtDescription.StyleController = layoutControl2;
            txtDescription.TabIndex = 10;
            // 
            // calcAmount
            // 
            calcAmount.Location = new System.Drawing.Point(123, 121);
            calcAmount.Name = "calcAmount";
            calcAmount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            calcAmount.Size = new System.Drawing.Size(204, 22);
            calcAmount.StyleController = layoutControl2;
            calcAmount.TabIndex = 9;
            // 
            // cmbPaymentMethod
            // 
            cmbPaymentMethod.Location = new System.Drawing.Point(123, 95);
            cmbPaymentMethod.Name = "cmbPaymentMethod";
            cmbPaymentMethod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbPaymentMethod.Properties.Items.AddRange(new object[] { "Nakit", "Kredi Kartı", "Havale/EFT" });
            cmbPaymentMethod.Size = new System.Drawing.Size(204, 22);
            cmbPaymentMethod.StyleController = layoutControl2;
            cmbPaymentMethod.TabIndex = 8;
            // 
            // dtPaymentDate
            // 
            dtPaymentDate.EditValue = null;
            dtPaymentDate.Location = new System.Drawing.Point(123, 69);
            dtPaymentDate.Name = "dtPaymentDate";
            dtPaymentDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dtPaymentDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dtPaymentDate.Size = new System.Drawing.Size(204, 22);
            dtPaymentDate.StyleController = layoutControl2;
            dtPaymentDate.TabIndex = 7;
            // 
            // slueCustomer
            // 
            slueCustomer.Location = new System.Drawing.Point(123, 12);
            slueCustomer.Name = "slueCustomer";
            slueCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            slueCustomer.Properties.PopupView = searchLookUpEdit1View;
            slueCustomer.Size = new System.Drawing.Size(204, 22);
            slueCustomer.StyleController = layoutControl2;
            slueCustomer.TabIndex = 6;
            slueCustomer.EditValueChanged += slueCustomer_EditValueChanged;
            // 
            // searchLookUpEdit1View
            // 
            searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // layoutControlGroup1
            // 
            layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            layoutControlGroup1.GroupBordersVisible = false;
            layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem3, emptySpaceItem1, layoutControlItem4, layoutControlItem5, layoutControlItem6, layoutControlItem7, layoutControlItem8 });
            layoutControlGroup1.Name = "Root";
            layoutControlGroup1.Size = new System.Drawing.Size(339, 426);
            layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = slueCustomer;
            layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new System.Drawing.Size(319, 26);
            layoutControlItem3.TextSize = new System.Drawing.Size(99, 13);
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.Location = new System.Drawing.Point(0, 26);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new System.Drawing.Size(319, 31);
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = dtPaymentDate;
            layoutControlItem4.Location = new System.Drawing.Point(0, 57);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new System.Drawing.Size(319, 26);
            layoutControlItem4.TextSize = new System.Drawing.Size(99, 13);
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.Control = cmbPaymentMethod;
            layoutControlItem5.Location = new System.Drawing.Point(0, 83);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.Size = new System.Drawing.Size(319, 26);
            layoutControlItem5.TextSize = new System.Drawing.Size(99, 13);
            // 
            // layoutControlItem6
            // 
            layoutControlItem6.Control = calcAmount;
            layoutControlItem6.Location = new System.Drawing.Point(0, 109);
            layoutControlItem6.Name = "layoutControlItem6";
            layoutControlItem6.Size = new System.Drawing.Size(319, 26);
            layoutControlItem6.TextSize = new System.Drawing.Size(99, 13);
            // 
            // layoutControlItem7
            // 
            layoutControlItem7.Control = txtDescription;
            layoutControlItem7.Location = new System.Drawing.Point(0, 135);
            layoutControlItem7.Name = "layoutControlItem7";
            layoutControlItem7.Size = new System.Drawing.Size(319, 245);
            layoutControlItem7.TextSize = new System.Drawing.Size(99, 13);
            // 
            // layoutControlItem8
            // 
            layoutControlItem8.Control = btnSavePayment;
            layoutControlItem8.Location = new System.Drawing.Point(0, 380);
            layoutControlItem8.Name = "layoutControlItem8";
            layoutControlItem8.Size = new System.Drawing.Size(319, 26);
            layoutControlItem8.TextVisible = false;
            // 
            // gridControl1
            // 
            gridControl1.Location = new System.Drawing.Point(12, 12);
            gridControl1.MainView = gridView1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new System.Drawing.Size(342, 450);
            gridControl1.TabIndex = 4;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsSelection.MultiSelect = true;
            gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            gridView1.SelectionChanged += gridView1_SelectionChanged;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2 });
            Root.Name = "Root";
            Root.Size = new System.Drawing.Size(713, 474);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = gridControl1;
            layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new System.Drawing.Size(346, 454);
            layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = groupControl1;
            layoutControlItem2.Location = new System.Drawing.Point(346, 0);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new System.Drawing.Size(347, 454);
            layoutControlItem2.TextVisible = false;
            // 
            // GetPaymentsControl
            // 
            Appearance.BackColor = System.Drawing.SystemColors.Control;
            Appearance.Options.UseBackColor = true;
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(layoutControl1);
            Name = "GetPaymentsControl";
            Size = new System.Drawing.Size(713, 474);
            Load += GetPaymentsControl_Load;
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)layoutControl2).EndInit();
            layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtDescription.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)calcAmount.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmbPaymentMethod.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtPaymentDate.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtPaymentDate.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)slueCustomer.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)searchLookUpEdit1View).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem8).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraEditors.SimpleButton btnSavePayment;
        private DevExpress.XtraEditors.MemoEdit txtDescription;
        private DevExpress.XtraEditors.CalcEdit calcAmount;
        private DevExpress.XtraEditors.ComboBoxEdit cmbPaymentMethod;
        private DevExpress.XtraEditors.DateEdit dtPaymentDate;
        private DevExpress.XtraEditors.SearchLookUpEdit slueCustomer;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
    }
}
