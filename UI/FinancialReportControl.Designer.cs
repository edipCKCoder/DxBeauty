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
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            gridFinancialReport = new DevExpress.XtraGrid.GridControl();
            gridViewFinancialReport = new DevExpress.XtraGrid.Views.Grid.GridView();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridFinancialReport).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewFinancialReport).BeginInit();
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
            layoutControl1.Root = Root;
            layoutControl1.Size = new System.Drawing.Size(981, 615);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // gridFinancialReport
            // 
            gridFinancialReport.Location = new System.Drawing.Point(12, 12);
            gridFinancialReport.MainView = gridViewFinancialReport;
            gridFinancialReport.Name = "gridFinancialReport";
            gridFinancialReport.Size = new System.Drawing.Size(957, 591);
            gridFinancialReport.TabIndex = 4;
            gridFinancialReport.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewFinancialReport });
            // 
            // gridViewFinancialReport
            // 
            gridViewFinancialReport.GridControl = gridFinancialReport;
            gridViewFinancialReport.Name = "gridViewFinancialReport";
            gridViewFinancialReport.PopupMenuShowing += gridViewFinancialReport_PopupMenuShowing;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1 });
            Root.Name = "Root";
            Root.Size = new System.Drawing.Size(981, 615);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = gridFinancialReport;
            layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new System.Drawing.Size(961, 595);
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
    }
}
