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
            DevExpress.Utils.ContextButton contextButton1 = new DevExpress.Utils.ContextButton();
            DevExpress.Utils.ContextButton contextButton2 = new DevExpress.Utils.ContextButton();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServicesControl));
            DevExpress.Utils.CheckContextButton checkContextButton1 = new DevExpress.Utils.CheckContextButton();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition1 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition2 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition3 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition1 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition2 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition3 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableSpan tableSpan1 = new DevExpress.XtraEditors.TableLayout.TableSpan();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement1 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement2 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement3 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            nameColumn = new DevExpress.XtraGrid.Columns.TileViewColumn();
            sessionColumn = new DevExpress.XtraGrid.Columns.TileViewColumn();
            totalPriceColumn = new DevExpress.XtraGrid.Columns.TileViewColumn();
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            gridControlPackages = new DevExpress.XtraGrid.GridControl();
            tileViewPackages = new DevExpress.XtraGrid.Views.Tile.TileView();
            installmentColumn = new DevExpress.XtraGrid.Columns.TileViewColumn();
            isActiveColumn = new DevExpress.XtraGrid.Columns.TileViewColumn();
            separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
            gridControlServices = new DevExpress.XtraGrid.GridControl();
            gridViewServices = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridColumnServiceName = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            CreateService = new DevExpress.XtraEditors.SimpleButton();
            addPackageButton = new DevExpress.XtraEditors.SimpleButton();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            groupControlPackages = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            splitterItem2 = new DevExpress.XtraLayout.SplitterItem();
            svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(components);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControlPackages).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tileViewPackages).BeginInit();
            ((System.ComponentModel.ISupportInitialize)separatorControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControlServices).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewServices).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemCheckEdit1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupControlPackages).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitterItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            SuspendLayout();
            // 
            // nameColumn
            // 
            nameColumn.Caption = "tileViewColumn1";
            nameColumn.FieldName = "Name";
            nameColumn.Name = "nameColumn";
            nameColumn.Visible = true;
            nameColumn.VisibleIndex = 1;
            // 
            // sessionColumn
            // 
            sessionColumn.Caption = "Seans Sayısı";
            sessionColumn.FieldName = "SessionCount";
            sessionColumn.Name = "sessionColumn";
            sessionColumn.OptionsColumn.ShowCaption = true;
            sessionColumn.Visible = true;
            sessionColumn.VisibleIndex = 0;
            // 
            // totalPriceColumn
            // 
            totalPriceColumn.DisplayFormat.FormatString = "c2";
            totalPriceColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            totalPriceColumn.FieldName = "TotalPrice";
            totalPriceColumn.Name = "totalPriceColumn";
            totalPriceColumn.Visible = true;
            totalPriceColumn.VisibleIndex = 2;
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(gridControlPackages);
            layoutControl1.Controls.Add(separatorControl1);
            layoutControl1.Controls.Add(gridControlServices);
            layoutControl1.Controls.Add(CreateService);
            layoutControl1.Controls.Add(addPackageButton);
            layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControl1.Location = new System.Drawing.Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1179, 131, 650, 400);
            layoutControl1.Root = Root;
            layoutControl1.Size = new System.Drawing.Size(892, 522);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // gridControlPackages
            // 
            gridControlPackages.Location = new System.Drawing.Point(391, 39);
            gridControlPackages.MainView = tileViewPackages;
            gridControlPackages.Name = "gridControlPackages";
            gridControlPackages.Size = new System.Drawing.Size(477, 459);
            gridControlPackages.TabIndex = 7;
            gridControlPackages.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { tileViewPackages });
            // 
            // tileViewPackages
            // 
            tileViewPackages.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { nameColumn, sessionColumn, totalPriceColumn, installmentColumn, isActiveColumn });
            tileViewPackages.ContextButtonOptions.ItemCursor = System.Windows.Forms.Cursors.Hand;
            tileViewPackages.ContextButtonOptions.PanelCursor = System.Windows.Forms.Cursors.Arrow;
            contextButton1.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Bottom;
            contextButton1.Id = new System.Guid("38cd150d-5098-4345-9667-3e40f7c2861d");
            contextButton1.ImageOptionsCollection.ItemNormal.SvgImage = Properties.Resources.Edit2;
            contextButton1.Name = "btnEditPackage";
            contextButton2.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Bottom;
            contextButton2.AnchorAlignment = DevExpress.Utils.AnchorAlignment.Right;
            contextButton2.AnchorElementId = new System.Guid("38cd150d-5098-4345-9667-3e40f7c2861d");
            contextButton2.AnchorIndent = 17;
            contextButton2.Id = new System.Guid("dee35dc9-48b4-40b5-a701-e426936f9f46");
            contextButton2.ImageOptionsCollection.ItemNormal.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("resource.SvgImage");
            contextButton2.Name = "btnDeletePackage";
            checkContextButton1.Id = new System.Guid("06c7b850-f15b-4cc0-af85-1adb5d7d7d2f");
            checkContextButton1.ImageOptionsCollection.ItemChecked.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("resource.SvgImage1");
            checkContextButton1.ImageOptionsCollection.ItemNormal.SvgImage = Properties.Resources.closeheaderandfooter;
            checkContextButton1.ImageOptionsCollection.ItemNormal.SvgImageSize = new System.Drawing.Size(24, 24);
            checkContextButton1.Name = "chkActiveStatus";
            checkContextButton1.Visibility = DevExpress.Utils.ContextItemVisibility.Visible;
            tileViewPackages.ContextButtons.Add(contextButton1);
            tileViewPackages.ContextButtons.Add(contextButton2);
            tileViewPackages.ContextButtons.Add(checkContextButton1);
            tileViewPackages.GridControl = gridControlPackages;
            tileViewPackages.Name = "tileViewPackages";
            tileViewPackages.TileColumns.Add(tableColumnDefinition1);
            tileViewPackages.TileColumns.Add(tableColumnDefinition2);
            tileViewPackages.TileColumns.Add(tableColumnDefinition3);
            tileViewPackages.TileRows.Add(tableRowDefinition1);
            tileViewPackages.TileRows.Add(tableRowDefinition2);
            tileViewPackages.TileRows.Add(tableRowDefinition3);
            tableSpan1.ColumnSpan = 3;
            tileViewPackages.TileSpans.Add(tableSpan1);
            tileViewItemElement1.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            tileViewItemElement1.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement1.Column = nameColumn;
            tileViewItemElement1.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement1.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Squeeze;
            tileViewItemElement1.Text = "nameColumn";
            tileViewItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement2.Column = sessionColumn;
            tileViewItemElement2.ColumnIndex = 1;
            tileViewItemElement2.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement2.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Squeeze;
            tileViewItemElement2.RowIndex = 1;
            tileViewItemElement2.Text = "sessionColumn";
            tileViewItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement3.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            tileViewItemElement3.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement3.Column = totalPriceColumn;
            tileViewItemElement3.ColumnIndex = 2;
            tileViewItemElement3.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement3.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Squeeze;
            tileViewItemElement3.RowIndex = 2;
            tileViewItemElement3.Text = "totalPriceColumn";
            tileViewItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewPackages.TileTemplate.Add(tileViewItemElement1);
            tileViewPackages.TileTemplate.Add(tileViewItemElement2);
            tileViewPackages.TileTemplate.Add(tileViewItemElement3);
            tileViewPackages.ContextButtonClick += tileView1_ContextButtonClick;
            tileViewPackages.ContextButtonCustomize += tileViewPackages_ContextButtonCustomize;
            // 
            // installmentColumn
            // 
            installmentColumn.Caption = "tileViewColumn4";
            installmentColumn.FieldName = "IsInstallmentAllowed";
            installmentColumn.Name = "installmentColumn";
            installmentColumn.Visible = true;
            installmentColumn.VisibleIndex = 3;
            // 
            // isActiveColumn
            // 
            isActiveColumn.Caption = "tileViewColumn5";
            isActiveColumn.FieldName = "IsActive";
            isActiveColumn.Name = "isActiveColumn";
            isActiveColumn.Visible = true;
            isActiveColumn.VisibleIndex = 4;
            // 
            // separatorControl1
            // 
            separatorControl1.Location = new System.Drawing.Point(24, 112);
            separatorControl1.Name = "separatorControl1";
            separatorControl1.Size = new System.Drawing.Size(327, 23);
            separatorControl1.TabIndex = 6;
            // 
            // gridControlServices
            // 
            gridControlServices.Location = new System.Drawing.Point(24, 139);
            gridControlServices.MainView = gridViewServices;
            gridControlServices.Name = "gridControlServices";
            gridControlServices.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemCheckEdit1 });
            gridControlServices.Size = new System.Drawing.Size(327, 359);
            gridControlServices.TabIndex = 4;
            gridControlServices.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewServices });
            // 
            // gridViewServices
            // 
            gridViewServices.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { gridColumnServiceName, gridColumn1, gridColumn2 });
            gridViewServices.GridControl = gridControlServices;
            gridViewServices.Name = "gridViewServices";
            gridViewServices.FocusedRowChanged += gridViewServices_FocusedRowChanged;
            gridViewServices.CellValueChanged += gridViewServices_CellValueChanged;
            // 
            // gridColumnServiceName
            // 
            gridColumnServiceName.AppearanceHeader.Options.UseTextOptions = true;
            gridColumnServiceName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumnServiceName.Caption = "Hizmet Adı";
            gridColumnServiceName.FieldName = "ServiceName";
            gridColumnServiceName.Name = "gridColumnServiceName";
            gridColumnServiceName.OptionsColumn.AllowEdit = false;
            gridColumnServiceName.OptionsColumn.AllowFocus = false;
            gridColumnServiceName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            gridColumnServiceName.Visible = true;
            gridColumnServiceName.VisibleIndex = 0;
            // 
            // gridColumn1
            // 
            gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn1.Caption = "Açıklama";
            gridColumn1.FieldName = "Description";
            gridColumn1.Name = "gridColumn1";
            gridColumn1.OptionsColumn.AllowEdit = false;
            gridColumn1.OptionsColumn.AllowFocus = false;
            gridColumn1.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            gridColumn1.Visible = true;
            gridColumn1.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            gridColumn2.ColumnEdit = repositoryItemCheckEdit1;
            gridColumn2.FieldName = "IsActive";
            gridColumn2.Name = "gridColumn2";
            gridColumn2.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            gridColumn2.OptionsColumn.ShowCaption = false;
            gridColumn2.Visible = true;
            gridColumn2.VisibleIndex = 2;
            // 
            // repositoryItemCheckEdit1
            // 
            repositoryItemCheckEdit1.AutoHeight = false;
            repositoryItemCheckEdit1.Caption = "";
            repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // CreateService
            // 
            CreateService.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            CreateService.Appearance.Options.UseFont = true;
            CreateService.Cursor = System.Windows.Forms.Cursors.Hand;
            CreateService.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            CreateService.ImageOptions.SvgImage = Properties.Resources.snapinsertheader;
            CreateService.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.Full;
            CreateService.Location = new System.Drawing.Point(42, 43);
            CreateService.MaximumSize = new System.Drawing.Size(125, 0);
            CreateService.MinimumSize = new System.Drawing.Size(0, 60);
            CreateService.Name = "CreateService";
            CreateService.Size = new System.Drawing.Size(125, 60);
            CreateService.StyleController = layoutControl1;
            CreateService.TabIndex = 5;
            CreateService.Text = "Yeni Hizmet";
            CreateService.Click += CreateService_Click;
            // 
            // addPackageButton
            // 
            addPackageButton.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            addPackageButton.Appearance.Options.UseFont = true;
            addPackageButton.Appearance.Options.UseTextOptions = true;
            addPackageButton.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            addPackageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            addPackageButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            addPackageButton.ImageOptions.SvgImage = Properties.Resources.Dpad1;
            addPackageButton.Location = new System.Drawing.Point(207, 43);
            addPackageButton.MaximumSize = new System.Drawing.Size(125, 0);
            addPackageButton.MinimumSize = new System.Drawing.Size(0, 60);
            addPackageButton.Name = "addPackageButton";
            addPackageButton.Size = new System.Drawing.Size(125, 60);
            addPackageButton.StyleController = layoutControl1;
            addPackageButton.TabIndex = 8;
            addPackageButton.Text = "Yeni Paket";
            addPackageButton.Click += addPackageButton_Click;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlGroup1, groupControlPackages, splitterItem2 });
            Root.Name = "Root";
            Root.Size = new System.Drawing.Size(892, 522);
            Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            layoutControlGroup1.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2, layoutControlItem3, layoutControlItem5 });
            layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            layoutControlGroup1.Name = "layoutControlGroup1";
            layoutControlGroup1.Size = new System.Drawing.Size(355, 502);
            layoutControlGroup1.Text = "Hizmetler";
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = gridControlServices;
            layoutControlItem1.Location = new System.Drawing.Point(0, 100);
            layoutControlItem1.MaxSize = new System.Drawing.Size(600, 0);
            layoutControlItem1.MinSize = new System.Drawing.Size(104, 24);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new System.Drawing.Size(331, 363);
            layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Center;
            layoutControlItem2.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            layoutControlItem2.Control = CreateService;
            layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            layoutControlItem2.MaxSize = new System.Drawing.Size(600, 75);
            layoutControlItem2.MinSize = new System.Drawing.Size(114, 50);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new System.Drawing.Size(165, 73);
            layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = separatorControl1;
            layoutControlItem3.Location = new System.Drawing.Point(0, 73);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new System.Drawing.Size(331, 27);
            layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Center;
            layoutControlItem5.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            layoutControlItem5.Control = addPackageButton;
            layoutControlItem5.Location = new System.Drawing.Point(165, 0);
            layoutControlItem5.MaxSize = new System.Drawing.Size(0, 75);
            layoutControlItem5.MinSize = new System.Drawing.Size(78, 26);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.Size = new System.Drawing.Size(166, 73);
            layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem5.TextVisible = false;
            // 
            // groupControlPackages
            // 
            groupControlPackages.AppearanceGroup.BackColor = System.Drawing.Color.White;
            groupControlPackages.AppearanceGroup.Options.UseBackColor = true;
            groupControlPackages.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            groupControlPackages.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem4 });
            groupControlPackages.Location = new System.Drawing.Point(367, 0);
            groupControlPackages.Name = "groupControlPackages";
            groupControlPackages.Size = new System.Drawing.Size(505, 502);
            groupControlPackages.Text = "Satış Paketleri";
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = gridControlPackages;
            layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new System.Drawing.Size(481, 463);
            layoutControlItem4.TextVisible = false;
            // 
            // splitterItem2
            // 
            splitterItem2.Location = new System.Drawing.Point(355, 0);
            splitterItem2.Name = "splitterItem2";
            splitterItem2.Size = new System.Drawing.Size(12, 502);
            // 
            // svgImageCollection1
            // 
            svgImageCollection1.Add("apply1_img", "image://svgimages/icon builder/actions_checkcircled.svg");
            svgImageCollection1.Add("cancel1_img", "image://svgimages/icon builder/actions_removecircled.svg");
            svgImageCollection1.Add("apply_img", (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgImageCollection1.apply_img"));
            svgImageCollection1.Add("cancel_img", (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgImageCollection1.cancel_img"));
            svgImageCollection1.Add("Save.svg", (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgImageCollection1.Save.svg"));
            svgImageCollection1.Add("Edit.svg", (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgImageCollection1.Edit.svg"));
            // 
            // ServicesControl
            // 
            Controls.Add(layoutControl1);
            Name = "ServicesControl";
            Size = new System.Drawing.Size(892, 522);
            Load += ServicesControl_Load;
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridControlPackages).EndInit();
            ((System.ComponentModel.ISupportInitialize)tileViewPackages).EndInit();
            ((System.ComponentModel.ISupportInitialize)separatorControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControlServices).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewServices).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemCheckEdit1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupControlPackages).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)splitterItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ResumeLayout(false);

        }
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;

        #endregion
        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
        private DevExpress.XtraLayout.LayoutControlGroup groupControlPackages;
        private DevExpress.XtraLayout.SplitterItem splitterItem2;
        private DevExpress.XtraGrid.GridControl gridControlServices;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewServices;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton CreateService;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SeparatorControl separatorControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnServiceName;
        private DevExpress.XtraGrid.GridControl gridControlPackages;
        private DevExpress.XtraGrid.Views.Tile.TileView tileViewPackages;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.Columns.TileViewColumn nameColumn;
        private DevExpress.XtraGrid.Columns.TileViewColumn sessionColumn;
        private DevExpress.XtraGrid.Columns.TileViewColumn totalPriceColumn;
        private DevExpress.XtraGrid.Columns.TileViewColumn installmentColumn;
        private DevExpress.XtraGrid.Columns.TileViewColumn isActiveColumn;
        private DevExpress.XtraEditors.SimpleButton addPackageButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
    }
}
