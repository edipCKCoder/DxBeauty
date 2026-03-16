namespace DXBeauty
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            splitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            navBarControl = new DevExpress.XtraNavBar.NavBarControl();
            reminderGroup = new DevExpress.XtraNavBar.NavBarGroup();
            ReminderMessage = new DevExpress.XtraNavBar.NavBarItem();
            customerGroup = new DevExpress.XtraNavBar.NavBarGroup();
            registerCustomer = new DevExpress.XtraNavBar.NavBarItem();
            customerHistory = new DevExpress.XtraNavBar.NavBarItem();
            CustomerPackages = new DevExpress.XtraNavBar.NavBarItem();
            organizerGroup = new DevExpress.XtraNavBar.NavBarGroup();
            scheduler = new DevExpress.XtraNavBar.NavBarItem();
            paymentGroup = new DevExpress.XtraNavBar.NavBarGroup();
            getPayment = new DevExpress.XtraNavBar.NavBarItem();
            financialReport = new DevExpress.XtraNavBar.NavBarItem();
            servicesGroup = new DevExpress.XtraNavBar.NavBarGroup();
            createService = new DevExpress.XtraNavBar.NavBarItem();
            ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            skinDropDownButtonItem1 = new DevExpress.XtraBars.SkinDropDownButtonItem();
            skinPaletteRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinPaletteRibbonGalleryBarItem();
            skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            btnRibbonPayment = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            btnRibbonfinancialReport = new DevExpress.XtraBars.BarButtonItem();
            customerRegisterbarButtonItem = new DevExpress.XtraBars.BarButtonItem();
            CustomerHistorybarButtonItem = new DevExpress.XtraBars.BarButtonItem();
            customerPackagesbarButtonItem = new DevExpress.XtraBars.BarButtonItem();
            schedulerBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
            dashboardBarButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            servicesPackagesBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
            reminderMessagebarButtonItem = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            popupControlContainer2 = new DevExpress.XtraBars.PopupControlContainer(components);
            buttonEdit = new DevExpress.XtraEditors.ButtonEdit();
            popupControlContainer1 = new DevExpress.XtraBars.PopupControlContainer(components);
            someLabelControl2 = new DevExpress.XtraEditors.LabelControl();
            someLabelControl1 = new DevExpress.XtraEditors.LabelControl();
            navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl.Panel1).BeginInit();
            splitContainerControl.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl.Panel2).BeginInit();
            splitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)navBarControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)popupControlContainer2).BeginInit();
            popupControlContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)buttonEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)popupControlContainer1).BeginInit();
            popupControlContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainerControl
            // 
            splitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainerControl.Location = new System.Drawing.Point(0, 170);
            splitContainerControl.Name = "splitContainerControl";
            splitContainerControl.Padding = new System.Windows.Forms.Padding(6);
            // 
            // splitContainerControl.Panel1
            // 
            splitContainerControl.Panel1.Controls.Add(navBarControl);
            splitContainerControl.Panel1.Text = "Panel1";
            // 
            // splitContainerControl.Panel2
            // 
            splitContainerControl.Panel2.Text = "Panel2";
            splitContainerControl.Size = new System.Drawing.Size(1194, 548);
            splitContainerControl.SplitterPosition = 205;
            splitContainerControl.TabIndex = 0;
            splitContainerControl.Text = "splitContainerControl1";
            // 
            // navBarControl
            // 
            navBarControl.ActiveGroup = reminderGroup;
            navBarControl.Dock = System.Windows.Forms.DockStyle.Fill;
            navBarControl.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] { customerGroup, organizerGroup, paymentGroup, servicesGroup, reminderGroup });
            navBarControl.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] { scheduler, registerCustomer, customerHistory, getPayment, createService, ReminderMessage, CustomerPackages, financialReport });
            navBarControl.Location = new System.Drawing.Point(0, 0);
            navBarControl.Name = "navBarControl";
            navBarControl.OptionsNavPane.ExpandedWidth = 205;
            navBarControl.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            navBarControl.Size = new System.Drawing.Size(205, 536);
            navBarControl.StoreDefaultPaintStyleName = true;
            navBarControl.TabIndex = 1;
            navBarControl.Text = "navBarControl1";
            // 
            // reminderGroup
            // 
            reminderGroup.Caption = "Hatırlatıcı";
            reminderGroup.Expanded = true;
            reminderGroup.ImageOptions.LargeImage = Properties.Resources.reminder_32x32;
            reminderGroup.ImageOptions.LargeImageIndex = 0;
            reminderGroup.ImageOptions.LargeImageKey = "reminder_32x32.png";
            reminderGroup.ImageOptions.SmallImage = Properties.Resources.reminder_16x16;
            reminderGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] { new DevExpress.XtraNavBar.NavBarItemLink(ReminderMessage) });
            reminderGroup.Name = "reminderGroup";
            // 
            // ReminderMessage
            // 
            ReminderMessage.Caption = "Mesaj Şablonu Oluştur";
            ReminderMessage.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("ReminderMessage.ImageOptions.LargeImage");
            ReminderMessage.ImageOptions.SmallImage = (System.Drawing.Image)resources.GetObject("ReminderMessage.ImageOptions.SmallImage");
            ReminderMessage.Name = "ReminderMessage";
            ReminderMessage.LinkClicked += ReminderMessage_LinkClicked;
            // 
            // customerGroup
            // 
            customerGroup.Caption = "Müşteriler";
            customerGroup.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("customerGroup.ImageOptions.LargeImage");
            customerGroup.ImageOptions.LargeImageIndex = 0;
            customerGroup.ImageOptions.SmallImage = (System.Drawing.Image)resources.GetObject("customerGroup.ImageOptions.SmallImage");
            customerGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] { new DevExpress.XtraNavBar.NavBarItemLink(registerCustomer), new DevExpress.XtraNavBar.NavBarItemLink(customerHistory), new DevExpress.XtraNavBar.NavBarItemLink(CustomerPackages) });
            customerGroup.Name = "customerGroup";
            // 
            // registerCustomer
            // 
            registerCustomer.Caption = "Müşteri Kayıt";
            registerCustomer.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("registerCustomer.ImageOptions.LargeImage");
            registerCustomer.ImageOptions.SmallImage = (System.Drawing.Image)resources.GetObject("registerCustomer.ImageOptions.SmallImage");
            registerCustomer.Name = "registerCustomer";
            registerCustomer.LinkClicked += RegisterCustomer_LinkClicked;
            // 
            // customerHistory
            // 
            customerHistory.Caption = "Müşteri Geçmiş Hareketler";
            customerHistory.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("customerHistory.ImageOptions.LargeImage");
            customerHistory.ImageOptions.SmallImage = (System.Drawing.Image)resources.GetObject("customerHistory.ImageOptions.SmallImage");
            customerHistory.Name = "customerHistory";
            customerHistory.LinkClicked += CustomerHistory_LinkClicked;
            // 
            // CustomerPackages
            // 
            CustomerPackages.Caption = "Müşteri Paketleri";
            CustomerPackages.ImageOptions.LargeImage = Properties.Resources.colormixer_32x32;
            CustomerPackages.ImageOptions.SmallImage = Properties.Resources.colormixer_16x16;
            CustomerPackages.Name = "CustomerPackages";
            CustomerPackages.LinkClicked += CustomerPackages_LinkClicked;
            // 
            // organizerGroup
            // 
            organizerGroup.Caption = "Planlayıcı";
            organizerGroup.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("organizerGroup.ImageOptions.LargeImage");
            organizerGroup.ImageOptions.LargeImageIndex = 1;
            organizerGroup.ImageOptions.SmallImage = (System.Drawing.Image)resources.GetObject("organizerGroup.ImageOptions.SmallImage");
            organizerGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] { new DevExpress.XtraNavBar.NavBarItemLink(scheduler) });
            organizerGroup.Name = "organizerGroup";
            // 
            // scheduler
            // 
            scheduler.Caption = "Takvim";
            scheduler.ImageOptions.LargeImage = Properties.Resources.switchtimescalesto_32x32;
            scheduler.ImageOptions.SmallImage = Properties.Resources.switchtimescalesto_16x16;
            scheduler.ImageOptions.SmallImageIndex = 4;
            scheduler.Name = "scheduler";
            scheduler.LinkClicked += NavBarItemScheduler_LinkClicked;
            // 
            // paymentGroup
            // 
            paymentGroup.Caption = "Ödeme";
            paymentGroup.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("paymentGroup.ImageOptions.LargeImage");
            paymentGroup.ImageOptions.LargeImageIndex = 1;
            paymentGroup.ImageOptions.SmallImage = (System.Drawing.Image)resources.GetObject("paymentGroup.ImageOptions.SmallImage");
            paymentGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] { new DevExpress.XtraNavBar.NavBarItemLink(getPayment), new DevExpress.XtraNavBar.NavBarItemLink(financialReport) });
            paymentGroup.Name = "paymentGroup";
            // 
            // getPayment
            // 
            getPayment.Caption = "Ödeme Al";
            getPayment.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("getPayment.ImageOptions.LargeImage");
            getPayment.ImageOptions.SmallImage = (System.Drawing.Image)resources.GetObject("getPayment.ImageOptions.SmallImage");
            getPayment.ImageOptions.SmallImageSize = new System.Drawing.Size(16, 16);
            getPayment.Name = "getPayment";
            getPayment.LinkClicked += getPayment_LinkClicked;
            // 
            // financialReport
            // 
            financialReport.Caption = "Tüm Müşteri Bakiyeleri";
            financialReport.ImageOptions.SmallImageSize = new System.Drawing.Size(16, 16);
            financialReport.ImageOptions.SvgImage = Properties.Resources.accounting;
            financialReport.Name = "financialReport";
            financialReport.LinkClicked += financialReport_LinkClicked;
            // 
            // servicesGroup
            // 
            servicesGroup.Caption = "Hizmet/Satış Paketi";
            servicesGroup.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("servicesGroup.ImageOptions.LargeImage");
            servicesGroup.ImageOptions.SmallImage = (System.Drawing.Image)resources.GetObject("servicesGroup.ImageOptions.SmallImage");
            servicesGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] { new DevExpress.XtraNavBar.NavBarItemLink(createService) });
            servicesGroup.Name = "servicesGroup";
            // 
            // createService
            // 
            createService.Caption = "Hizmetler ve Satış Paketleri";
            createService.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("createService.ImageOptions.LargeImage");
            createService.ImageOptions.SmallImage = (System.Drawing.Image)resources.GetObject("createService.ImageOptions.SmallImage");
            createService.Name = "createService";
            createService.LinkClicked += createService_LinkClicked;
            // 
            // ribbonStatusBar
            // 
            ribbonStatusBar.Location = new System.Drawing.Point(0, 718);
            ribbonStatusBar.Name = "ribbonStatusBar";
            ribbonStatusBar.Ribbon = ribbonControl1;
            ribbonStatusBar.Size = new System.Drawing.Size(1194, 31);
            // 
            // ribbonControl1
            // 
            ribbonControl1.CaptionBarItemLinks.Add(skinDropDownButtonItem1);
            ribbonControl1.CaptionBarItemLinks.Add(skinPaletteRibbonGalleryBarItem1);
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { skinDropDownButtonItem1, skinPaletteRibbonGalleryBarItem1, ribbonControl1.ExpandCollapseItem, skinRibbonGalleryBarItem1, barButtonItem1, barButtonItem2, btnRibbonPayment, barButtonItem3, barButtonItem4, barButtonItem5, btnRibbonfinancialReport, customerRegisterbarButtonItem, CustomerHistorybarButtonItem, customerPackagesbarButtonItem, schedulerBarButtonItem, dashboardBarButtonItem6, servicesPackagesBarButtonItem, reminderMessagebarButtonItem, barButtonItem6, barButtonItem7 });
            ribbonControl1.Location = new System.Drawing.Point(0, 0);
            ribbonControl1.MaxItemId = 28;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage2 });
            ribbonControl1.Size = new System.Drawing.Size(1194, 170);
            ribbonControl1.StatusBar = ribbonStatusBar;
            // 
            // skinDropDownButtonItem1
            // 
            skinDropDownButtonItem1.Id = 1;
            skinDropDownButtonItem1.Name = "skinDropDownButtonItem1";
            // 
            // skinPaletteRibbonGalleryBarItem1
            // 
            skinPaletteRibbonGalleryBarItem1.Caption = "skinPaletteRibbonGalleryBarItem1";
            skinPaletteRibbonGalleryBarItem1.Id = 3;
            skinPaletteRibbonGalleryBarItem1.Name = "skinPaletteRibbonGalleryBarItem1";
            // 
            // skinRibbonGalleryBarItem1
            // 
            skinRibbonGalleryBarItem1.Caption = "skinRibbonGalleryBarItem1";
            skinRibbonGalleryBarItem1.Id = 2;
            skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            // 
            // barButtonItem1
            // 
            barButtonItem1.Caption = "barButtonItem1";
            barButtonItem1.Id = 5;
            barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            barButtonItem2.Caption = "barButtonItem2";
            barButtonItem2.Id = 6;
            barButtonItem2.Name = "barButtonItem2";
            // 
            // btnRibbonPayment
            // 
            btnRibbonPayment.Caption = "Ödeme Al";
            btnRibbonPayment.Id = 7;
            btnRibbonPayment.ImageOptions.SvgImage = Properties.Resources.financial1;
            btnRibbonPayment.Name = "btnRibbonPayment";
            btnRibbonPayment.ItemClick += btnRibbonPayment_ItemClick;
            // 
            // barButtonItem3
            // 
            barButtonItem3.Id = 8;
            barButtonItem3.ImageOptions.SvgImage = Properties.Resources.treemap2;
            barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem4
            // 
            barButtonItem4.Id = 17;
            barButtonItem4.Name = "barButtonItem4";
            // 
            // barButtonItem5
            // 
            barButtonItem5.Caption = "barButtonItem5";
            barButtonItem5.Id = 10;
            barButtonItem5.Name = "barButtonItem5";
            // 
            // btnRibbonfinancialReport
            // 
            btnRibbonfinancialReport.Caption = "Tüm Müşteri Bakiyeleri";
            btnRibbonfinancialReport.Id = 11;
            btnRibbonfinancialReport.ImageOptions.SvgImage = Properties.Resources.sparklinewinloss;
            btnRibbonfinancialReport.Name = "btnRibbonfinancialReport";
            btnRibbonfinancialReport.ItemClick += btnRibbonfinancialReport_ItemClick;
            // 
            // customerRegisterbarButtonItem
            // 
            customerRegisterbarButtonItem.Caption = "Müşteri Kayıt";
            customerRegisterbarButtonItem.Id = 12;
            customerRegisterbarButtonItem.ImageOptions.SvgImage = Properties.Resources.newcustomer;
            customerRegisterbarButtonItem.Name = "customerRegisterbarButtonItem";
            customerRegisterbarButtonItem.ItemClick += customerRegisterbarButtonItem_ItemClick;
            // 
            // CustomerHistorybarButtonItem
            // 
            CustomerHistorybarButtonItem.Id = 20;
            CustomerHistorybarButtonItem.Name = "CustomerHistorybarButtonItem";
            // 
            // customerPackagesbarButtonItem
            // 
            customerPackagesbarButtonItem.Id = 21;
            customerPackagesbarButtonItem.Name = "customerPackagesbarButtonItem";
            // 
            // schedulerBarButtonItem
            // 
            schedulerBarButtonItem.Id = 22;
            schedulerBarButtonItem.Name = "schedulerBarButtonItem";
            // 
            // dashboardBarButtonItem6
            // 
            dashboardBarButtonItem6.Id = 23;
            dashboardBarButtonItem6.Name = "dashboardBarButtonItem6";
            // 
            // servicesPackagesBarButtonItem
            // 
            servicesPackagesBarButtonItem.Id = 24;
            servicesPackagesBarButtonItem.Name = "servicesPackagesBarButtonItem";
            // 
            // reminderMessagebarButtonItem
            // 
            reminderMessagebarButtonItem.Id = 25;
            reminderMessagebarButtonItem.Name = "reminderMessagebarButtonItem";
            // 
            // barButtonItem6
            // 
            barButtonItem6.Caption = "Hizmet Oluştur";
            barButtonItem6.Id = 26;
            barButtonItem6.ImageOptions.Image = Properties.Resources.boorderitem_16x16;
            barButtonItem6.ImageOptions.LargeImage = Properties.Resources.boorderitem_32x32;
            barButtonItem6.Name = "barButtonItem6";
            barButtonItem6.ItemClick += barButtonItem6_ItemClick;
            // 
            // ribbonPage2
            // 
            ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup4, ribbonPageGroup5, ribbonPageGroup1 });
            ribbonPage2.Name = "ribbonPage2";
            ribbonPage2.Text = "Kısayollar";
            // 
            // ribbonPageGroup4
            // 
            ribbonPageGroup4.ItemLinks.Add(customerRegisterbarButtonItem);
            ribbonPageGroup4.Name = "ribbonPageGroup4";
            // 
            // ribbonPageGroup5
            // 
            ribbonPageGroup5.ItemLinks.Add(barButtonItem6);
            ribbonPageGroup5.Name = "ribbonPageGroup5";
            // 
            // popupControlContainer2
            // 
            popupControlContainer2.Appearance.BackColor = System.Drawing.Color.Transparent;
            popupControlContainer2.Appearance.Options.UseBackColor = true;
            popupControlContainer2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            popupControlContainer2.Controls.Add(buttonEdit);
            popupControlContainer2.Location = new System.Drawing.Point(238, 289);
            popupControlContainer2.Name = "popupControlContainer2";
            popupControlContainer2.Ribbon = ribbonControl1;
            popupControlContainer2.Size = new System.Drawing.Size(118, 28);
            popupControlContainer2.TabIndex = 3;
            popupControlContainer2.Visible = false;
            // 
            // buttonEdit
            // 
            buttonEdit.EditValue = "Some Text";
            buttonEdit.Location = new System.Drawing.Point(3, 5);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            buttonEdit.Size = new System.Drawing.Size(100, 22);
            buttonEdit.TabIndex = 0;
            // 
            // popupControlContainer1
            // 
            popupControlContainer1.Appearance.BackColor = System.Drawing.Color.Transparent;
            popupControlContainer1.Appearance.Options.UseBackColor = true;
            popupControlContainer1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            popupControlContainer1.Controls.Add(someLabelControl2);
            popupControlContainer1.Controls.Add(someLabelControl1);
            popupControlContainer1.Location = new System.Drawing.Point(111, 197);
            popupControlContainer1.Name = "popupControlContainer1";
            popupControlContainer1.Ribbon = ribbonControl1;
            popupControlContainer1.Size = new System.Drawing.Size(76, 70);
            popupControlContainer1.TabIndex = 2;
            popupControlContainer1.Visible = false;
            // 
            // someLabelControl2
            // 
            someLabelControl2.Location = new System.Drawing.Point(3, 57);
            someLabelControl2.Name = "someLabelControl2";
            someLabelControl2.Size = new System.Drawing.Size(52, 13);
            someLabelControl2.TabIndex = 0;
            someLabelControl2.Text = "Some Info";
            // 
            // someLabelControl1
            // 
            someLabelControl1.Location = new System.Drawing.Point(3, 3);
            someLabelControl1.Name = "someLabelControl1";
            someLabelControl1.Size = new System.Drawing.Size(52, 13);
            someLabelControl1.TabIndex = 0;
            someLabelControl1.Text = "Some Info";
            // 
            // navBarGroup1
            // 
            navBarGroup1.Caption = "Organizer";
            navBarGroup1.ImageOptions.LargeImageIndex = 1;
            navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] { new DevExpress.XtraNavBar.NavBarItemLink(scheduler) });
            navBarGroup1.Name = "navBarGroup1";
            // 
            // ribbonPageGroup2
            // 
            ribbonPageGroup2.Alignment = DevExpress.XtraBars.Ribbon.RibbonPageGroupAlignment.Far;
            ribbonPageGroup2.ItemLinks.Add(barButtonItem4);
            ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(barButtonItem7);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // barButtonItem7
            // 
            barButtonItem7.Caption = "Satış Paketi Oluştur";
            barButtonItem7.Id = 27;
            barButtonItem7.ImageOptions.Image = Properties.Resources.bosaleitem_16x16;
            barButtonItem7.ImageOptions.LargeImage = Properties.Resources.bosaleitem_32x32;
            barButtonItem7.Name = "barButtonItem7";
            barButtonItem7.ItemClick += barButtonItem7_ItemClick;
            // 
            // MainForm
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1194, 749);
            Controls.Add(splitContainerControl);
            Controls.Add(popupControlContainer1);
            Controls.Add(popupControlContainer2);
            Controls.Add(ribbonStatusBar);
            Controls.Add(ribbonControl1);
            Name = "MainForm";
            Ribbon = ribbonControl1;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            StatusBar = ribbonStatusBar;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)splitContainerControl.Panel1).EndInit();
            splitContainerControl.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerControl.Panel2).EndInit();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl).EndInit();
            splitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)navBarControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)popupControlContainer2).EndInit();
            popupControlContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)buttonEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)popupControlContainer1).EndInit();
            popupControlContainer1.ResumeLayout(false);
            popupControlContainer1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl;
        private DevExpress.XtraBars.PopupControlContainer popupControlContainer1;
        private DevExpress.XtraEditors.LabelControl someLabelControl2;
        private DevExpress.XtraEditors.LabelControl someLabelControl1;
        private DevExpress.XtraBars.PopupControlContainer popupControlContainer2;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraNavBar.NavBarControl navBarControl;
        private DevExpress.XtraNavBar.NavBarGroup customerGroup;
        private DevExpress.XtraNavBar.NavBarGroup organizerGroup;
        private DevExpress.XtraNavBar.NavBarItem scheduler;
        private DevExpress.XtraNavBar.NavBarItem registerCustomer;
        private DevExpress.XtraNavBar.NavBarItem customerHistory;
        private DevExpress.XtraNavBar.NavBarGroup paymentGroup;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarItem getPayment;
        private DevExpress.XtraNavBar.NavBarGroup servicesGroup;
        private DevExpress.XtraNavBar.NavBarItem createService;
        private DevExpress.XtraNavBar.NavBarGroup reminderGroup;
        private DevExpress.XtraNavBar.NavBarItem ReminderMessage;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.SkinDropDownButtonItem skinDropDownButtonItem1;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.XtraBars.SkinPaletteRibbonGalleryBarItem skinPaletteRibbonGalleryBarItem1;
        private DevExpress.XtraNavBar.NavBarItem CustomerPackages;
       // private DevExpress.XtraBars.BarButtonItem btnRibbonPayment;
        private DevExpress.XtraNavBar.NavBarItem financialReport;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem btnRibbonPayment;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem btnRibbonfinancialReport;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem customerRegisterbarButtonItem;
        private DevExpress.XtraBars.BarButtonItem CustomerHistorybarButtonItem;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.BarButtonItem customerPackagesbarButtonItem;
        private DevExpress.XtraBars.BarButtonItem schedulerBarButtonItem;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem dashboardBarButtonItem6;
        private DevExpress.XtraBars.BarButtonItem servicesPackagesBarButtonItem;
        private DevExpress.XtraBars.BarButtonItem reminderMessagebarButtonItem;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
    }
}
