namespace DXBeauty.UI
{
    partial class FinancialReportControl
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            gridFinancialReport = new DevExpress.XtraGrid.GridControl();
            gridViewFinancialReport = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridFinancialReport).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewFinancialReport).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemButtonEdit1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            SuspendLayout();
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(gridFinancialReport);
            layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControl1.Location = new System.Drawing.Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1025, 262, 650, 400);
            layoutControl1.Root = Root;
            layoutControl1.Size = new System.Drawing.Size(981, 615);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // gridFinancialReport
            // 
            gridFinancialReport.Location = new System.Drawing.Point(25, 45);
            gridFinancialReport.MainView = gridViewFinancialReport;
            gridFinancialReport.Name = "gridFinancialReport";
            gridFinancialReport.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemButtonEdit1 });
            gridFinancialReport.Size = new System.Drawing.Size(931, 545);
            gridFinancialReport.TabIndex = 4;
            gridFinancialReport.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewFinancialReport });
            // 
            // gridViewFinancialReport
            // 
            gridViewFinancialReport.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { gridColumn10, gridColumn9, gridColumn1, gridColumn2, gridColumn3, gridColumn4, gridColumn5, gridColumn6, gridColumn7, gridColumn8 });
            gridViewFinancialReport.GridControl = gridFinancialReport;
            gridViewFinancialReport.Name = "gridViewFinancialReport";
            gridViewFinancialReport.OptionsFind.AlwaysVisible = true;
            gridViewFinancialReport.PopupMenuShowing += gridViewFinancialReport_PopupMenuShowing;
            // 
            // gridColumn10
            // 
            gridColumn10.Caption = "Mesaj Gönder";
            gridColumn10.ColumnEdit = repositoryItemButtonEdit1;
            gridColumn10.Name = "gridColumn10";
            gridColumn10.Visible = true;
            gridColumn10.VisibleIndex = 9;
            // 
            // repositoryItemButtonEdit1
            // 
            repositoryItemButtonEdit1.AutoHeight = false;
            repositoryItemButtonEdit1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            editorButtonImageOptions1.SvgImage = Properties.Resources.GoToMessage1;
            editorButtonImageOptions1.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.Full;
            editorButtonImageOptions1.SvgImageSize = new System.Drawing.Size(16, 16);
            repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default) });
            repositoryItemButtonEdit1.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // gridColumn9
            // 
            gridColumn9.Caption = "Paket Adı";
            gridColumn9.FieldName = "PackageName";
            gridColumn9.Name = "gridColumn9";
            gridColumn9.Visible = true;
            gridColumn9.VisibleIndex = 8;
            // 
            // gridColumn1
            // 
            gridColumn1.Caption = "İsim Soyisim";
            gridColumn1.FieldName = "FullName";
            gridColumn1.Name = "gridColumn1";
            gridColumn1.Visible = true;
            gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            gridColumn2.Caption = "Telefon";
            gridColumn2.FieldName = "Phone";
            gridColumn2.Name = "gridColumn2";
            gridColumn2.Visible = true;
            gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            gridColumn3.Caption = "Plan Açıklaması";
            gridColumn3.FieldName = "PlanDescription";
            gridColumn3.Name = "gridColumn3";
            gridColumn3.Visible = true;
            gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            gridColumn4.Caption = "Vade Tarihi";
            gridColumn4.FieldName = "DueDate";
            gridColumn4.Name = "gridColumn4";
            gridColumn4.Visible = true;
            gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            gridColumn5.Caption = "Toplam Tutar";
            gridColumn5.FieldName = "TotalAmount";
            gridColumn5.Name = "gridColumn5";
            gridColumn5.Visible = true;
            gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            gridColumn6.Caption = "Ödenen Tutar";
            gridColumn6.FieldName = "PaidAmount";
            gridColumn6.Name = "gridColumn6";
            gridColumn6.Visible = true;
            gridColumn6.VisibleIndex = 5;
            // 
            // gridColumn7
            // 
            gridColumn7.Caption = "Kalan Borç";
            gridColumn7.FieldName = "RemainingDebt";
            gridColumn7.Name = "gridColumn7";
            gridColumn7.Visible = true;
            gridColumn7.VisibleIndex = 6;
            // 
            // gridColumn8
            // 
            gridColumn8.Caption = "Ödendi mi?";
            gridColumn8.FieldName = "IsPaid";
            gridColumn8.Name = "gridColumn8";
            gridColumn8.Visible = true;
            gridColumn8.VisibleIndex = 7;
            // 
            // Root
            // 
            Root.GroupStyle = DevExpress.Utils.GroupStyle.Card;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1 });
            Root.Name = "Root";
            Root.Size = new System.Drawing.Size(981, 615);
            Root.Spacing = new DevExpress.XtraLayout.Utils.Padding(13, 13, 13, 13);
            Root.Text = "Müşteri Ödeme Planları";
            Root.TextLocation = DevExpress.Utils.Locations.Default;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = gridFinancialReport;
            layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new System.Drawing.Size(935, 549);
            layoutControlItem1.TextVisible = false;
            // 
            // FinancialReportControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(layoutControl1);
            Name = "FinancialReportControl";
            Size = new System.Drawing.Size(981, 615);
            Load += FinancialReportControl_Load;
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridFinancialReport).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewFinancialReport).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemButtonEdit1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridFinancialReport;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewFinancialReport;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
    }
}
