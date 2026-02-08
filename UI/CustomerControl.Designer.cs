namespace DXBeauty.UI
{
    partial class CustomerControl
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
            layoutControl3 = new DevExpress.XtraLayout.LayoutControl();
            NewRegister = new DevExpress.XtraEditors.SimpleButton();
            layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            editButton = new DevExpress.XtraEditors.SimpleButton();
            layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            customerGridControl = new DevExpress.XtraGrid.GridControl();
            customersGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            deleteButton = new DevExpress.XtraEditors.SimpleButton();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)layoutControl3).BeginInit();
            layoutControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControl2).BeginInit();
            layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)customerGridControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)customersGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitterItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            SuspendLayout();
            // 
            // groupControl1
            // 
            groupControl1.Controls.Add(layoutControl1);
            groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupControl1.Location = new System.Drawing.Point(0, 0);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new System.Drawing.Size(898, 614);
            groupControl1.TabIndex = 0;
            groupControl1.Text = "Customers";
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(layoutControl3);
            layoutControl1.Controls.Add(layoutControl2);
            layoutControl1.Controls.Add(customerGridControl);
            layoutControl1.Controls.Add(deleteButton);
            layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControl1.Location = new System.Drawing.Point(2, 23);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1192, 320, 650, 400);
            layoutControl1.Root = Root;
            layoutControl1.Size = new System.Drawing.Size(894, 589);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // layoutControl3
            // 
            layoutControl3.Controls.Add(NewRegister);
            layoutControl3.Location = new System.Drawing.Point(303, 531);
            layoutControl3.Name = "layoutControl3";
            layoutControl3.Root = layoutControlGroup2;
            layoutControl3.Size = new System.Drawing.Size(287, 46);
            layoutControl3.TabIndex = 5;
            layoutControl3.Text = "layoutControl3";
            // 
            // NewRegister
            // 
            NewRegister.Location = new System.Drawing.Point(12, 12);
            NewRegister.Name = "NewRegister";
            NewRegister.Size = new System.Drawing.Size(263, 22);
            NewRegister.StyleController = layoutControl3;
            NewRegister.TabIndex = 4;
            NewRegister.Text = "New Register";
            NewRegister.Click += NewRegister_Click;
            // 
            // layoutControlGroup2
            // 
            layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            layoutControlGroup2.GroupBordersVisible = false;
            layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem7 });
            layoutControlGroup2.Name = "layoutControlGroup2";
            layoutControlGroup2.Size = new System.Drawing.Size(287, 46);
            layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            layoutControlItem7.Control = NewRegister;
            layoutControlItem7.Location = new System.Drawing.Point(0, 0);
            layoutControlItem7.Name = "layoutControlItem7";
            layoutControlItem7.Size = new System.Drawing.Size(267, 26);
            layoutControlItem7.TextVisible = false;
            // 
            // layoutControl2
            // 
            layoutControl2.Controls.Add(editButton);
            layoutControl2.Location = new System.Drawing.Point(12, 531);
            layoutControl2.Name = "layoutControl2";
            layoutControl2.Root = layoutControlGroup1;
            layoutControl2.Size = new System.Drawing.Size(287, 46);
            layoutControl2.TabIndex = 4;
            layoutControl2.Text = "layoutControl2";
            // 
            // editButton
            // 
            editButton.Location = new System.Drawing.Point(12, 12);
            editButton.Name = "editButton";
            editButton.Size = new System.Drawing.Size(263, 22);
            editButton.StyleController = layoutControl2;
            editButton.TabIndex = 4;
            editButton.Text = "Edit";
            editButton.Click += editButton_Click;
            // 
            // layoutControlGroup1
            // 
            layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            layoutControlGroup1.GroupBordersVisible = false;
            layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem6 });
            layoutControlGroup1.Name = "layoutControlGroup1";
            layoutControlGroup1.Size = new System.Drawing.Size(287, 46);
            layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            layoutControlItem6.Control = editButton;
            layoutControlItem6.Location = new System.Drawing.Point(0, 0);
            layoutControlItem6.Name = "layoutControlItem6";
            layoutControlItem6.Size = new System.Drawing.Size(267, 26);
            layoutControlItem6.TextVisible = false;
            // 
            // customerGridControl
            // 
            customerGridControl.Location = new System.Drawing.Point(12, 12);
            customerGridControl.MainView = customersGridView;
            customerGridControl.Name = "customerGridControl";
            customerGridControl.Size = new System.Drawing.Size(870, 515);
            customerGridControl.TabIndex = 0;
            customerGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { customersGridView });
            customerGridControl.Load += CustomerControl_Load;
            // 
            // customersGridView
            // 
            customersGridView.GridControl = customerGridControl;
            customersGridView.Name = "customersGridView";
            // 
            // deleteButton
            // 
            deleteButton.Location = new System.Drawing.Point(594, 541);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new System.Drawing.Size(288, 22);
            deleteButton.StyleController = layoutControl1;
            deleteButton.TabIndex = 6;
            deleteButton.Text = "Delete";
            deleteButton.Click += deleteButton_Click;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, splitterItem1, layoutControlItem2, layoutControlItem3, layoutControlItem5 });
            Root.Name = "Root";
            Root.Size = new System.Drawing.Size(894, 589);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = customerGridControl;
            layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new System.Drawing.Size(874, 519);
            layoutControlItem1.TextVisible = false;
            // 
            // splitterItem1
            // 
            splitterItem1.Location = new System.Drawing.Point(582, 519);
            splitterItem1.Name = "splitterItem1";
            splitterItem1.Size = new System.Drawing.Size(292, 10);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = layoutControl2;
            layoutControlItem2.Location = new System.Drawing.Point(0, 519);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new System.Drawing.Size(291, 50);
            layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = layoutControl3;
            layoutControlItem3.Location = new System.Drawing.Point(291, 519);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new System.Drawing.Size(291, 50);
            layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.Control = deleteButton;
            layoutControlItem5.Location = new System.Drawing.Point(582, 529);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.Size = new System.Drawing.Size(292, 40);
            layoutControlItem5.TextVisible = false;
            // 
            // CustomerControl
            // 
            Appearance.BackColor = System.Drawing.SystemColors.Control;
            Appearance.Options.UseBackColor = true;
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(groupControl1);
            Name = "CustomerControl";
            Size = new System.Drawing.Size(898, 614);
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)layoutControl3).EndInit();
            layoutControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControl2).EndInit();
            layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).EndInit();
            ((System.ComponentModel.ISupportInitialize)customerGridControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)customersGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)splitterItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl customerGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView customersGridView;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private DevExpress.XtraLayout.LayoutControl layoutControl3;
        private DevExpress.XtraEditors.SimpleButton CustomerRegister;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraEditors.SimpleButton editButton;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.SimpleButton deleteButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.SimpleButton NewRegister;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
    }
}
