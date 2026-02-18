namespace DXBeauty.UI
{
    partial class ServicesControl
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServicesControl));
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            layoutView1 = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            descriptionColumn = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            layoutViewField_descriptionColumn = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            IsActiveColumn = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            repositoryItemToggleSwitch1 = new DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch();
            layoutViewField_IsActiveColumn = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            nameColumn = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            layoutViewField_nameColumn = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            addPackageButton = new DevExpress.XtraEditors.SimpleButton();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            simpleSeparator2 = new DevExpress.XtraLayout.SimpleSeparator();
            svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(components);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemMemoEdit1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutViewField_descriptionColumn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemToggleSwitch1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutViewField_IsActiveColumn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutViewField_nameColumn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutViewCard1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)simpleSeparator1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitterItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)simpleSeparator2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            SuspendLayout();
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(gridControl1);
            layoutControl1.Controls.Add(simpleButton1);
            layoutControl1.Controls.Add(addPackageButton);
            layoutControl1.Controls.Add(flowLayoutPanel1);
            layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControl1.Location = new System.Drawing.Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(804, 0, 650, 400);
            layoutControl1.Root = Root;
            layoutControl1.Size = new System.Drawing.Size(892, 522);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            gridControl1.Location = new System.Drawing.Point(24, 49);
            gridControl1.MainView = layoutView1;
            gridControl1.Name = "gridControl1";
            gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemToggleSwitch1, repositoryItemMemoEdit1 });
            gridControl1.Size = new System.Drawing.Size(437, 350);
            gridControl1.TabIndex = 4;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { layoutView1 });
            // 
            // layoutView1
            // 
            layoutView1.CardMinSize = new System.Drawing.Size(228, 132);
            layoutView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] { descriptionColumn, IsActiveColumn, nameColumn });
            layoutView1.GridControl = gridControl1;
            layoutView1.Name = "layoutView1";
            layoutView1.OptionsItemText.TextToControlDistance = 6;
            layoutView1.OptionsView.ShowViewCaption = true;
            layoutView1.TemplateCard = layoutViewCard1;
            layoutView1.CardClick += layoutView1_CardClick;
            // 
            // descriptionColumn
            // 
            descriptionColumn.ColumnEdit = repositoryItemMemoEdit1;
            descriptionColumn.FieldName = "Description";
            descriptionColumn.LayoutViewField = layoutViewField_descriptionColumn;
            descriptionColumn.Name = "descriptionColumn";
            // 
            // repositoryItemMemoEdit1
            // 
            repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // layoutViewField_descriptionColumn
            // 
            layoutViewField_descriptionColumn.EditorPreferredWidth = 128;
            layoutViewField_descriptionColumn.Location = new System.Drawing.Point(0, 24);
            layoutViewField_descriptionColumn.Name = "layoutViewField_descriptionColumn";
            layoutViewField_descriptionColumn.Size = new System.Drawing.Size(210, 48);
            layoutViewField_descriptionColumn.TextSize = new System.Drawing.Size(70, 13);
            // 
            // IsActiveColumn
            // 
            IsActiveColumn.ColumnEdit = repositoryItemToggleSwitch1;
            IsActiveColumn.FieldName = "IsActive";
            IsActiveColumn.LayoutViewField = layoutViewField_IsActiveColumn;
            IsActiveColumn.Name = "IsActiveColumn";
            // 
            // repositoryItemToggleSwitch1
            // 
            repositoryItemToggleSwitch1.AutoHeight = false;
            repositoryItemToggleSwitch1.Name = "repositoryItemToggleSwitch1";
            repositoryItemToggleSwitch1.OffText = "Off";
            repositoryItemToggleSwitch1.OnText = "On";
            // 
            // layoutViewField_IsActiveColumn
            // 
            layoutViewField_IsActiveColumn.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Center;
            layoutViewField_IsActiveColumn.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            layoutViewField_IsActiveColumn.EditorPreferredWidth = 204;
            layoutViewField_IsActiveColumn.Location = new System.Drawing.Point(0, 72);
            layoutViewField_IsActiveColumn.MaxSize = new System.Drawing.Size(0, 22);
            layoutViewField_IsActiveColumn.MinSize = new System.Drawing.Size(99, 22);
            layoutViewField_IsActiveColumn.Name = "layoutViewField_IsActiveColumn";
            layoutViewField_IsActiveColumn.Size = new System.Drawing.Size(210, 22);
            layoutViewField_IsActiveColumn.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutViewField_IsActiveColumn.TextVisible = false;
            // 
            // nameColumn
            // 
            nameColumn.Caption = "Service Name";
            nameColumn.CustomizationCaption = "Service Name";
            nameColumn.FieldName = "Name";
            nameColumn.LayoutViewField = layoutViewField_nameColumn;
            nameColumn.Name = "nameColumn";
            // 
            // layoutViewField_nameColumn
            // 
            layoutViewField_nameColumn.EditorPreferredWidth = 128;
            layoutViewField_nameColumn.Location = new System.Drawing.Point(0, 0);
            layoutViewField_nameColumn.Name = "layoutViewField_nameColumn";
            layoutViewField_nameColumn.Size = new System.Drawing.Size(210, 24);
            layoutViewField_nameColumn.TextSize = new System.Drawing.Size(70, 13);
            // 
            // layoutViewCard1
            // 
            layoutViewCard1.CustomizationFormText = "TemplateCard";
            layoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutViewField_descriptionColumn, layoutViewField_IsActiveColumn, layoutViewField_nameColumn });
            layoutViewCard1.Name = "layoutViewCard1";
            layoutViewCard1.OptionsItemText.TextToControlDistance = 6;
            layoutViewCard1.Text = "TemplateCard";
            // 
            // simpleButton1
            // 
            simpleButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            simpleButton1.Location = new System.Drawing.Point(24, 458);
            simpleButton1.MinimumSize = new System.Drawing.Size(0, 30);
            simpleButton1.Name = "simpleButton1";
            simpleButton1.Size = new System.Drawing.Size(188, 30);
            simpleButton1.StyleController = layoutControl1;
            simpleButton1.TabIndex = 2;
            simpleButton1.Text = "Create Service";
            simpleButton1.Click += CreateService_Click;
            // 
            // addPackageButton
            // 
            addPackageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            addPackageButton.Location = new System.Drawing.Point(216, 458);
            addPackageButton.MinimumSize = new System.Drawing.Size(0, 30);
            addPackageButton.Name = "addPackageButton";
            addPackageButton.Size = new System.Drawing.Size(245, 30);
            addPackageButton.StyleController = layoutControl1;
            addPackageButton.TabIndex = 3;
            addPackageButton.Text = "Add Package";
            addPackageButton.Click += addPackageButton_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new System.Drawing.Point(490, 49);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(378, 439);
            flowLayoutPanel1.TabIndex = 5;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlGroup1, layoutControlGroup2, splitterItem1, simpleSeparator2 });
            Root.Name = "Root";
            Root.Size = new System.Drawing.Size(892, 522);
            Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            layoutControlGroup1.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem2, layoutControlItem3, emptySpaceItem1, simpleSeparator1, emptySpaceItem2, layoutControlItem1 });
            layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            layoutControlGroup1.Name = "layoutControlGroup1";
            layoutControlGroup1.Size = new System.Drawing.Size(465, 492);
            layoutControlGroup1.Text = "Services";
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = simpleButton1;
            layoutControlItem2.Location = new System.Drawing.Point(0, 409);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new System.Drawing.Size(192, 34);
            layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = addPackageButton;
            layoutControlItem3.Location = new System.Drawing.Point(192, 409);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new System.Drawing.Size(249, 34);
            layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.Location = new System.Drawing.Point(0, 354);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new System.Drawing.Size(441, 10);
            // 
            // simpleSeparator1
            // 
            simpleSeparator1.Location = new System.Drawing.Point(0, 364);
            simpleSeparator1.Name = "simpleSeparator1";
            simpleSeparator1.Size = new System.Drawing.Size(441, 1);
            // 
            // emptySpaceItem2
            // 
            emptySpaceItem2.Location = new System.Drawing.Point(0, 365);
            emptySpaceItem2.Name = "emptySpaceItem2";
            emptySpaceItem2.Size = new System.Drawing.Size(441, 44);
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = gridControl1;
            layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new System.Drawing.Size(441, 354);
            layoutControlItem1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            layoutControlGroup2.AppearanceGroup.BackColor = System.Drawing.Color.White;
            layoutControlGroup2.AppearanceGroup.Options.UseBackColor = true;
            layoutControlGroup2.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem4 });
            layoutControlGroup2.Location = new System.Drawing.Point(466, 0);
            layoutControlGroup2.Name = "layoutControlGroup2";
            layoutControlGroup2.Size = new System.Drawing.Size(406, 492);
            layoutControlGroup2.Text = "Packages";
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = flowLayoutPanel1;
            layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.OptionsPrint.AppearanceItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            layoutControlItem4.OptionsPrint.AppearanceItem.Options.UseBackColor = true;
            layoutControlItem4.Size = new System.Drawing.Size(382, 443);
            layoutControlItem4.TextVisible = false;
            // 
            // splitterItem1
            // 
            splitterItem1.Location = new System.Drawing.Point(0, 492);
            splitterItem1.Name = "splitterItem1";
            splitterItem1.Size = new System.Drawing.Size(872, 10);
            // 
            // simpleSeparator2
            // 
            simpleSeparator2.Location = new System.Drawing.Point(465, 0);
            simpleSeparator2.Name = "simpleSeparator2";
            simpleSeparator2.Size = new System.Drawing.Size(1, 492);
            // 
            // svgImageCollection1
            // 
            svgImageCollection1.Add("apply1_img", "image://svgimages/icon builder/actions_checkcircled.svg");
            svgImageCollection1.Add("cancel1_img", "image://svgimages/icon builder/actions_removecircled.svg");
            svgImageCollection1.Add("apply_img", (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgImageCollection1.apply_img"));
            svgImageCollection1.Add("cancel_img", (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgImageCollection1.cancel_img"));
            // 
            // ServicesControl
            // 
            Controls.Add(layoutControl1);
            Name = "ServicesControl";
            Size = new System.Drawing.Size(892, 522);
            Load += ServicesControl_Load;
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemMemoEdit1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutViewField_descriptionColumn).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemToggleSwitch1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutViewField_IsActiveColumn).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutViewField_nameColumn).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutViewCard1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)simpleSeparator1).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)splitterItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)simpleSeparator2).EndInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ResumeLayout(false);

        }
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton addPackageButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
       
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn descriptionColumn;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn IsActiveColumn;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn nameColumn;
        private DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch repositoryItemToggleSwitch1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_descriptionColumn;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_IsActiveColumn;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_nameColumn;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator2;
    }
}
