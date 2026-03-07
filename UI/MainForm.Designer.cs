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
            customerGroup = new DevExpress.XtraNavBar.NavBarGroup();
            registerCustomer = new DevExpress.XtraNavBar.NavBarItem();
            customerHistory = new DevExpress.XtraNavBar.NavBarItem();
            CustomerPackages = new DevExpress.XtraNavBar.NavBarItem();
            organizerGroup = new DevExpress.XtraNavBar.NavBarGroup();
            scheduler = new DevExpress.XtraNavBar.NavBarItem();
            paymentGroup = new DevExpress.XtraNavBar.NavBarGroup();
            getPayment = new DevExpress.XtraNavBar.NavBarItem();
            servicesGroup = new DevExpress.XtraNavBar.NavBarGroup();
            createService = new DevExpress.XtraNavBar.NavBarItem();
            reminderGroup = new DevExpress.XtraNavBar.NavBarGroup();
            ReminderMessage = new DevExpress.XtraNavBar.NavBarItem();
            ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            skinDropDownButtonItem1 = new DevExpress.XtraBars.SkinDropDownButtonItem();
            skinPaletteRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinPaletteRibbonGalleryBarItem();
            skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            btnRibbonPayment = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            popupControlContainer2 = new DevExpress.XtraBars.PopupControlContainer(components);
            buttonEdit = new DevExpress.XtraEditors.ButtonEdit();
            popupControlContainer1 = new DevExpress.XtraBars.PopupControlContainer(components);
            someLabelControl2 = new DevExpress.XtraEditors.LabelControl();
            someLabelControl1 = new DevExpress.XtraEditors.LabelControl();
            navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
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
            splitContainerControl.Size = new System.Drawing.Size(1110, 532);
            splitContainerControl.SplitterPosition = 171;
            splitContainerControl.TabIndex = 0;
            splitContainerControl.Text = "splitContainerControl1";
            // 
            // navBarControl
            // 
            navBarControl.ActiveGroup = customerGroup;
            navBarControl.Dock = System.Windows.Forms.DockStyle.Fill;
            navBarControl.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] { customerGroup, organizerGroup, paymentGroup, servicesGroup, reminderGroup });
            navBarControl.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] { scheduler, registerCustomer, customerHistory, getPayment, createService, ReminderMessage, CustomerPackages });
            navBarControl.Location = new System.Drawing.Point(0, 0);
            navBarControl.Name = "navBarControl";
            navBarControl.OptionsNavPane.ExpandedWidth = 171;
            navBarControl.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            navBarControl.Size = new System.Drawing.Size(171, 520);
            navBarControl.StoreDefaultPaintStyleName = true;
            navBarControl.TabIndex = 1;
            navBarControl.Text = "navBarControl1";
            // 
            // customerGroup
            // 
            customerGroup.Caption = "Customers";
            customerGroup.Expanded = true;
            customerGroup.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("customerGroup.ImageOptions.LargeImage");
            customerGroup.ImageOptions.LargeImageIndex = 0;
            customerGroup.ImageOptions.SmallImage = (System.Drawing.Image)resources.GetObject("customerGroup.ImageOptions.SmallImage");
            customerGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] { new DevExpress.XtraNavBar.NavBarItemLink(registerCustomer), new DevExpress.XtraNavBar.NavBarItemLink(customerHistory), new DevExpress.XtraNavBar.NavBarItemLink(CustomerPackages) });
            customerGroup.Name = "customerGroup";
            // 
            // registerCustomer
            // 
            registerCustomer.Caption = "Register Customer";
            registerCustomer.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("registerCustomer.ImageOptions.LargeImage");
            registerCustomer.ImageOptions.SmallImage = (System.Drawing.Image)resources.GetObject("registerCustomer.ImageOptions.SmallImage");
            registerCustomer.Name = "registerCustomer";
            registerCustomer.LinkClicked += RegisterCustomer_LinkClicked;
            // 
            // customerHistory
            // 
            customerHistory.Caption = "Customer History";
            customerHistory.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("customerHistory.ImageOptions.LargeImage");
            customerHistory.ImageOptions.SmallImage = (System.Drawing.Image)resources.GetObject("customerHistory.ImageOptions.SmallImage");
            customerHistory.Name = "customerHistory";
            customerHistory.LinkClicked += CustomerHistory_LinkClicked;
            // 
            // CustomerPackages
            // 
            CustomerPackages.Caption = "Customer Packages";
            CustomerPackages.ImageOptions.LargeImage = Properties.Resources.colormixer_32x32;
            CustomerPackages.ImageOptions.SmallImage = Properties.Resources.colormixer_16x16;
            CustomerPackages.Name = "CustomerPackages";
            CustomerPackages.LinkClicked += CustomerPackages_LinkClicked;
            // 
            // organizerGroup
            // 
            organizerGroup.Caption = "Organizer";
            organizerGroup.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("organizerGroup.ImageOptions.LargeImage");
            organizerGroup.ImageOptions.LargeImageIndex = 1;
            organizerGroup.ImageOptions.SmallImage = (System.Drawing.Image)resources.GetObject("organizerGroup.ImageOptions.SmallImage");
            organizerGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] { new DevExpress.XtraNavBar.NavBarItemLink(scheduler) });
            organizerGroup.Name = "organizerGroup";
            // 
            // scheduler
            // 
            scheduler.Caption = "Scheduler";
            scheduler.ImageOptions.LargeImage = Properties.Resources.switchtimescalesto_32x32;
            scheduler.ImageOptions.SmallImage = Properties.Resources.switchtimescalesto_16x16;
            scheduler.ImageOptions.SmallImageIndex = 4;
            scheduler.Name = "scheduler";
            scheduler.LinkClicked += NavBarItemScheduler_LinkClicked;
            // 
            // paymentGroup
            // 
            paymentGroup.Caption = "Payment";
            paymentGroup.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("paymentGroup.ImageOptions.LargeImage");
            paymentGroup.ImageOptions.LargeImageIndex = 1;
            paymentGroup.ImageOptions.SmallImage = (System.Drawing.Image)resources.GetObject("paymentGroup.ImageOptions.SmallImage");
            paymentGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] { new DevExpress.XtraNavBar.NavBarItemLink(getPayment) });
            paymentGroup.Name = "paymentGroup";
            // 
            // getPayment
            // 
            getPayment.Caption = "Get Payment";
            getPayment.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("getPayment.ImageOptions.LargeImage");
            getPayment.ImageOptions.SmallImage = (System.Drawing.Image)resources.GetObject("getPayment.ImageOptions.SmallImage");
            getPayment.Name = "getPayment";
            getPayment.LinkClicked += getPayment_LinkClicked;
            // 
            // servicesGroup
            // 
            servicesGroup.Caption = "Services";
            servicesGroup.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("servicesGroup.ImageOptions.LargeImage");
            servicesGroup.ImageOptions.SmallImage = (System.Drawing.Image)resources.GetObject("servicesGroup.ImageOptions.SmallImage");
            servicesGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] { new DevExpress.XtraNavBar.NavBarItemLink(createService) });
            servicesGroup.Name = "servicesGroup";
            // 
            // createService
            // 
            createService.Caption = "Create Service";
            createService.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("createService.ImageOptions.LargeImage");
            createService.ImageOptions.SmallImage = (System.Drawing.Image)resources.GetObject("createService.ImageOptions.SmallImage");
            createService.Name = "createService";
            createService.LinkClicked += createService_LinkClicked;
            // 
            // reminderGroup
            // 
            reminderGroup.Caption = "Reminder";
            reminderGroup.ImageOptions.LargeImage = Properties.Resources.reminder_32x32;
            reminderGroup.ImageOptions.LargeImageIndex = 0;
            reminderGroup.ImageOptions.LargeImageKey = "reminder_32x32.png";
            reminderGroup.ImageOptions.SmallImage = Properties.Resources.reminder_16x16;
            reminderGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] { new DevExpress.XtraNavBar.NavBarItemLink(ReminderMessage) });
            reminderGroup.Name = "reminderGroup";
            // 
            // ReminderMessage
            // 
            ReminderMessage.Caption = "Send Reminder Message";
            ReminderMessage.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("ReminderMessage.ImageOptions.LargeImage");
            ReminderMessage.ImageOptions.SmallImage = (System.Drawing.Image)resources.GetObject("ReminderMessage.ImageOptions.SmallImage");
            ReminderMessage.Name = "ReminderMessage";
            ReminderMessage.LinkClicked += ReminderMessage_LinkClicked;
            // 
            // ribbonStatusBar
            // 
            ribbonStatusBar.Location = new System.Drawing.Point(0, 702);
            ribbonStatusBar.Name = "ribbonStatusBar";
            ribbonStatusBar.Ribbon = ribbonControl1;
            ribbonStatusBar.Size = new System.Drawing.Size(1110, 31);
            // 
            // ribbonControl1
            // 
            ribbonControl1.CaptionBarItemLinks.Add(skinDropDownButtonItem1);
            ribbonControl1.CaptionBarItemLinks.Add(skinPaletteRibbonGalleryBarItem1);
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { skinDropDownButtonItem1, skinPaletteRibbonGalleryBarItem1, ribbonControl1.ExpandCollapseItem, skinRibbonGalleryBarItem1, btnRibbonPayment });
            ribbonControl1.Location = new System.Drawing.Point(0, 0);
            ribbonControl1.MaxItemId = 5;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl1.Size = new System.Drawing.Size(1110, 170);
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
            // btnRibbonPayment
            // 
            btnRibbonPayment.Caption = "Tahsilat Al";
            btnRibbonPayment.Hint = "Tahsilat Al";
            btnRibbonPayment.Id = 4;
            btnRibbonPayment.ImageOptions.SvgImage = Properties.Resources.financial;
            btnRibbonPayment.Name = "btnRibbonPayment";
            btnRibbonPayment.ItemClick += btnRibbonPayment_ItemClick;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "Parasal İşlemler";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(btnRibbonPayment);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
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
            // MainForm
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1110, 733);
            Controls.Add(splitContainerControl);
            Controls.Add(popupControlContainer1);
            Controls.Add(popupControlContainer2);
            Controls.Add(ribbonStatusBar);
            Controls.Add(ribbonControl1);
            Font = new System.Drawing.Font("Segoe UI", 8.25F);
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
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.SkinDropDownButtonItem skinDropDownButtonItem1;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.XtraBars.SkinPaletteRibbonGalleryBarItem skinPaletteRibbonGalleryBarItem1;
        private DevExpress.XtraNavBar.NavBarItem CustomerPackages;
        private DevExpress.XtraBars.BarButtonItem btnRibbonPayment;
    }
}
