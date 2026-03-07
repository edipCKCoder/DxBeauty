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
            btnSavePayment = new DevExpress.XtraEditors.SimpleButton();
            txtDescription = new DevExpress.XtraEditors.MemoEdit();
            calcAmount = new DevExpress.XtraEditors.CalcEdit();
            cmbPaymentMethod = new DevExpress.XtraEditors.ComboBoxEdit();
            dtPaymentDate = new DevExpress.XtraEditors.DateEdit();
            slueCustomer = new DevExpress.XtraEditors.SearchLookUpEdit();
            searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtDescription.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)calcAmount.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmbPaymentMethod.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtPaymentDate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtPaymentDate.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)slueCustomer.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)searchLookUpEdit1View).BeginInit();
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
            groupControl1.Controls.Add(btnSavePayment);
            groupControl1.Controls.Add(txtDescription);
            groupControl1.Controls.Add(calcAmount);
            groupControl1.Controls.Add(cmbPaymentMethod);
            groupControl1.Controls.Add(dtPaymentDate);
            groupControl1.Controls.Add(slueCustomer);
            groupControl1.Location = new System.Drawing.Point(358, 12);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new System.Drawing.Size(343, 450);
            groupControl1.TabIndex = 5;
            groupControl1.Text = "Tahsilat Bilgileri";
            // 
            // btnSavePayment
            // 
            btnSavePayment.Location = new System.Drawing.Point(125, 375);
            btnSavePayment.Name = "btnSavePayment";
            btnSavePayment.Size = new System.Drawing.Size(116, 60);
            btnSavePayment.TabIndex = 5;
            btnSavePayment.Text = "Kaydet (Tahsilatı Al)";
            btnSavePayment.Click += btnSavePayment_Click;
            // 
            // txtDescription
            // 
            txtDescription.Location = new System.Drawing.Point(5, 215);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new System.Drawing.Size(184, 96);
            txtDescription.TabIndex = 4;
            // 
            // calcAmount
            // 
            calcAmount.Location = new System.Drawing.Point(5, 166);
            calcAmount.Name = "calcAmount";
            calcAmount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            calcAmount.Size = new System.Drawing.Size(100, 22);
            calcAmount.TabIndex = 3;
            // 
            // cmbPaymentMethod
            // 
            cmbPaymentMethod.Location = new System.Drawing.Point(5, 118);
            cmbPaymentMethod.Name = "cmbPaymentMethod";
            cmbPaymentMethod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbPaymentMethod.Properties.Items.AddRange(new object[] { "Nakit", "Kredi Kartı", "Havale/EFT" });
            cmbPaymentMethod.Size = new System.Drawing.Size(120, 22);
            cmbPaymentMethod.TabIndex = 2;
            // 
            // dtPaymentDate
            // 
            dtPaymentDate.EditValue = null;
            dtPaymentDate.Location = new System.Drawing.Point(5, 64);
            dtPaymentDate.Name = "dtPaymentDate";
            dtPaymentDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dtPaymentDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dtPaymentDate.Size = new System.Drawing.Size(100, 22);
            dtPaymentDate.TabIndex = 1;
            // 
            // slueCustomer
            // 
            slueCustomer.Location = new System.Drawing.Point(5, 25);
            slueCustomer.Name = "slueCustomer";
            slueCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            slueCustomer.Properties.PopupView = searchLookUpEdit1View;
            slueCustomer.Size = new System.Drawing.Size(100, 22);
            slueCustomer.TabIndex = 0;
            slueCustomer.EditValueChanged += slueCustomer_EditValueChanged;
            // 
            // searchLookUpEdit1View
            // 
            searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
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
            ((System.ComponentModel.ISupportInitialize)txtDescription.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)calcAmount.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmbPaymentMethod.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtPaymentDate.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtPaymentDate.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)slueCustomer.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)searchLookUpEdit1View).EndInit();
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
        private DevExpress.XtraEditors.DateEdit dtPaymentDate;
        private DevExpress.XtraEditors.SearchLookUpEdit slueCustomer;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.ComboBoxEdit cmbPaymentMethod;
        private DevExpress.XtraEditors.SimpleButton btnSavePayment;
        private DevExpress.XtraEditors.MemoEdit txtDescription;
        private DevExpress.XtraEditors.CalcEdit calcAmount;
    }
}
