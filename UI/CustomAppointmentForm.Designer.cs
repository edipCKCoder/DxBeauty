namespace DXBeauty.UI
{
    partial class CustomAppointmentForm
    {
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomAppointmentForm));
            lblSubject = new DevExpress.XtraEditors.LabelControl();
            lblLocation = new DevExpress.XtraEditors.LabelControl();
            tbSubject = new DevExpress.XtraEditors.TextEdit();
            lblLabel = new DevExpress.XtraEditors.LabelControl();
            lblStartTime = new DevExpress.XtraEditors.LabelControl();
            lblEndTime = new DevExpress.XtraEditors.LabelControl();
            chkAllDay = new DevExpress.XtraEditors.CheckEdit();
            lblShowTimeAs = new DevExpress.XtraEditors.LabelControl();
            btnOk = new DevExpress.XtraEditors.SimpleButton();
            btnCancel = new DevExpress.XtraEditors.SimpleButton();
            btnDelete = new DevExpress.XtraEditors.SimpleButton();
            btnRecurrence = new DevExpress.XtraEditors.SimpleButton();
            edtStartDate = new DevExpress.XtraEditors.DateEdit();
            edtEndDate = new DevExpress.XtraEditors.DateEdit();
            chkReminder = new DevExpress.XtraEditors.CheckEdit();
            tbDescription = new DevExpress.XtraEditors.MemoEdit();
            lblResource = new DevExpress.XtraEditors.LabelControl();
            tbLocation = new DevExpress.XtraEditors.TextEdit();
            panel1 = new DevExpress.XtraEditors.PanelControl();
            cbReminder = new DevExpress.XtraScheduler.UI.DurationEdit();
            edtLabel = new DevExpress.XtraScheduler.UI.AppointmentLabelEdit();
            edtResource = new DevExpress.XtraScheduler.UI.AppointmentResourceEdit();
            edtStartTime = new DevExpress.XtraEditors.TimeEdit();
            edtEndTime = new DevExpress.XtraEditors.TimeEdit();
            edtShowTimeAs = new DevExpress.XtraScheduler.UI.AppointmentStatusEdit();
            slueCustomer = new DevExpress.XtraEditors.SearchLookUpEdit();
            searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            lueCustomerPackages = new DevExpress.XtraEditors.LookUpEdit();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)tbSubject.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chkAllDay.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)edtStartDate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)edtStartDate.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)edtEndDate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)edtEndDate.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chkReminder.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbDescription.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbLocation.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panel1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cbReminder.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)edtLabel.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)edtResource.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)edtStartTime.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)edtEndTime.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)edtShowTimeAs.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)slueCustomer.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)searchLookUpEdit1View).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lueCustomerPackages.Properties).BeginInit();
            SuspendLayout();
            // 
            // lblSubject
            // 
            resources.ApplyResources(lblSubject, "lblSubject");
            lblSubject.Name = "lblSubject";
            // 
            // lblLocation
            // 
            resources.ApplyResources(lblLocation, "lblLocation");
            lblLocation.Name = "lblLocation";
            // 
            // tbSubject
            // 
            resources.ApplyResources(tbSubject, "tbSubject");
            tbSubject.Name = "tbSubject";
            tbSubject.Properties.AccessibleName = resources.GetString("tbSubject.Properties.AccessibleName");
            // 
            // lblLabel
            // 
            resources.ApplyResources(lblLabel, "lblLabel");
            lblLabel.Appearance.BackColor = System.Drawing.Color.Transparent;
            lblLabel.Appearance.Options.UseBackColor = true;
            lblLabel.Name = "lblLabel";
            // 
            // lblStartTime
            // 
            resources.ApplyResources(lblStartTime, "lblStartTime");
            lblStartTime.Name = "lblStartTime";
            // 
            // lblEndTime
            // 
            resources.ApplyResources(lblEndTime, "lblEndTime");
            lblEndTime.Name = "lblEndTime";
            // 
            // chkAllDay
            // 
            resources.ApplyResources(chkAllDay, "chkAllDay");
            chkAllDay.Name = "chkAllDay";
            chkAllDay.Properties.AccessibleName = resources.GetString("chkAllDay.Properties.AccessibleName");
            chkAllDay.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            chkAllDay.Properties.AutoWidth = true;
            chkAllDay.Properties.Caption = resources.GetString("chkAllDay.Properties.Caption");
            // 
            // lblShowTimeAs
            // 
            resources.ApplyResources(lblShowTimeAs, "lblShowTimeAs");
            lblShowTimeAs.Name = "lblShowTimeAs";
            // 
            // btnOk
            // 
            resources.ApplyResources(btnOk, "btnOk");
            btnOk.Name = "btnOk";
            btnOk.Click += OnBtnOkClick;
            // 
            // btnCancel
            // 
            resources.ApplyResources(btnCancel, "btnCancel");
            btnCancel.CausesValidation = false;
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCancel.Name = "btnCancel";
            // 
            // btnDelete
            // 
            resources.ApplyResources(btnDelete, "btnDelete");
            btnDelete.CausesValidation = false;
            btnDelete.Name = "btnDelete";
            btnDelete.Click += OnBtnDeleteClick;
            // 
            // btnRecurrence
            // 
            resources.ApplyResources(btnRecurrence, "btnRecurrence");
            btnRecurrence.Name = "btnRecurrence";
            btnRecurrence.Click += OnBtnRecurrenceClick;
            // 
            // edtStartDate
            // 
            resources.ApplyResources(edtStartDate, "edtStartDate");
            edtStartDate.Name = "edtStartDate";
            edtStartDate.Properties.AccessibleName = resources.GetString("edtStartDate.Properties.AccessibleName");
            edtStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton((DevExpress.XtraEditors.Controls.ButtonPredefines)resources.GetObject("edtStartDate.Properties.Buttons")) });
            edtStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            edtStartDate.Properties.MaxDate = new System.DateTime(4000, 1, 1, 0, 0, 0, 0);
            // 
            // edtEndDate
            // 
            resources.ApplyResources(edtEndDate, "edtEndDate");
            edtEndDate.Name = "edtEndDate";
            edtEndDate.Properties.AccessibleName = resources.GetString("edtEndDate.Properties.AccessibleName");
            edtEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton((DevExpress.XtraEditors.Controls.ButtonPredefines)resources.GetObject("edtEndDate.Properties.Buttons")) });
            edtEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            edtEndDate.Properties.MaxDate = new System.DateTime(4000, 1, 1, 0, 0, 0, 0);
            // 
            // chkReminder
            // 
            resources.ApplyResources(chkReminder, "chkReminder");
            chkReminder.Name = "chkReminder";
            chkReminder.Properties.AutoWidth = true;
            chkReminder.Properties.Caption = resources.GetString("chkReminder.Properties.Caption");
            // 
            // tbDescription
            // 
            resources.ApplyResources(tbDescription, "tbDescription");
            tbDescription.Name = "tbDescription";
            tbDescription.Properties.AccessibleName = resources.GetString("tbDescription.Properties.AccessibleName");
            tbDescription.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.Client;
            // 
            // lblResource
            // 
            resources.ApplyResources(lblResource, "lblResource");
            lblResource.Name = "lblResource";
            // 
            // tbLocation
            // 
            resources.ApplyResources(tbLocation, "tbLocation");
            tbLocation.Name = "tbLocation";
            tbLocation.Properties.AccessibleName = resources.GetString("tbLocation.Properties.AccessibleName");
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            panel1.Controls.Add(lblLabel);
            panel1.Controls.Add(cbReminder);
            panel1.Controls.Add(edtLabel);
            panel1.Controls.Add(chkReminder);
            panel1.Name = "panel1";
            // 
            // cbReminder
            // 
            resources.ApplyResources(cbReminder, "cbReminder");
            cbReminder.Name = "cbReminder";
            cbReminder.Properties.AccessibleName = resources.GetString("cbReminder.Properties.AccessibleName");
            cbReminder.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton((DevExpress.XtraEditors.Controls.ButtonPredefines)resources.GetObject("cbReminder.Properties.Buttons")) });
            cbReminder.Properties.DisabledStateText = "";
            // 
            // edtLabel
            // 
            resources.ApplyResources(edtLabel, "edtLabel");
            edtLabel.Name = "edtLabel";
            edtLabel.Properties.AccessibleName = resources.GetString("edtLabel.Properties.AccessibleName");
            edtLabel.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            edtLabel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton((DevExpress.XtraEditors.Controls.ButtonPredefines)resources.GetObject("edtLabel.Properties.Buttons")) });
            // 
            // edtResource
            // 
            resources.ApplyResources(edtResource, "edtResource");
            edtResource.Name = "edtResource";
            edtResource.Properties.AccessibleName = resources.GetString("edtResource.Properties.AccessibleName");
            edtResource.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            edtResource.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton((DevExpress.XtraEditors.Controls.ButtonPredefines)resources.GetObject("edtResource.Properties.Buttons")) });
            edtResource.Properties.NullText = resources.GetString("edtResource.Properties.NullText");
            // 
            // edtStartTime
            // 
            resources.ApplyResources(edtStartTime, "edtStartTime");
            edtStartTime.Name = "edtStartTime";
            edtStartTime.Properties.AccessibleName = resources.GetString("edtStartTime.Properties.AccessibleName");
            edtStartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            // 
            // edtEndTime
            // 
            resources.ApplyResources(edtEndTime, "edtEndTime");
            edtEndTime.Name = "edtEndTime";
            edtEndTime.Properties.AccessibleName = resources.GetString("edtEndTime.Properties.AccessibleName");
            edtEndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            // 
            // edtShowTimeAs
            // 
            resources.ApplyResources(edtShowTimeAs, "edtShowTimeAs");
            edtShowTimeAs.Name = "edtShowTimeAs";
            edtShowTimeAs.Properties.AccessibleName = resources.GetString("edtShowTimeAs.Properties.AccessibleName");
            edtShowTimeAs.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            edtShowTimeAs.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton((DevExpress.XtraEditors.Controls.ButtonPredefines)resources.GetObject("edtShowTimeAs.Properties.Buttons")) });
            // 
            // slueCustomer
            // 
            resources.ApplyResources(slueCustomer, "slueCustomer");
            slueCustomer.Name = "slueCustomer";
            slueCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton((DevExpress.XtraEditors.Controls.ButtonPredefines)resources.GetObject("slueCustomer.Properties.Buttons")) });
            slueCustomer.Properties.NullText = resources.GetString("slueCustomer.Properties.NullText");
            slueCustomer.Properties.PopupView = searchLookUpEdit1View;
            slueCustomer.EditValueChanged += slueCustomer_EditValueChanged;
            // 
            // searchLookUpEdit1View
            // 
            searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl1
            // 
            resources.ApplyResources(labelControl1, "labelControl1");
            labelControl1.Name = "labelControl1";
            // 
            // lueCustomerPackages
            // 
            resources.ApplyResources(lueCustomerPackages, "lueCustomerPackages");
            lueCustomerPackages.Name = "lueCustomerPackages";
            lueCustomerPackages.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton((DevExpress.XtraEditors.Controls.ButtonPredefines)resources.GetObject("lueCustomerPackages.Properties.Buttons")) });
            lueCustomerPackages.Properties.NullText = resources.GetString("lueCustomerPackages.Properties.NullText");
            // 
            // labelControl2
            // 
            resources.ApplyResources(labelControl2, "labelControl2");
            labelControl2.Name = "labelControl2";
            // 
            // labelControl3
            // 
            resources.ApplyResources(labelControl3, "labelControl3");
            labelControl3.Name = "labelControl3";
            // 
            // CustomAppointmentForm
            // 
            AcceptButton = btnOk;
            AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            Appearance.Options.UseFont = true;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btnCancel;
            Controls.Add(labelControl3);
            Controls.Add(labelControl2);
            Controls.Add(chkAllDay);
            Controls.Add(lueCustomerPackages);
            Controls.Add(edtResource);
            Controls.Add(labelControl1);
            Controls.Add(slueCustomer);
            Controls.Add(lblResource);
            Controls.Add(tbDescription);
            Controls.Add(panel1);
            Controls.Add(edtStartTime);
            Controls.Add(edtStartDate);
            Controls.Add(btnOk);
            Controls.Add(lblStartTime);
            Controls.Add(tbSubject);
            Controls.Add(lblLocation);
            Controls.Add(lblSubject);
            Controls.Add(tbLocation);
            Controls.Add(lblEndTime);
            Controls.Add(lblShowTimeAs);
            Controls.Add(btnCancel);
            Controls.Add(btnDelete);
            Controls.Add(btnRecurrence);
            Controls.Add(edtEndDate);
            Controls.Add(edtEndTime);
            Controls.Add(edtShowTimeAs);
            Name = "CustomAppointmentForm";
            ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)tbSubject.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)chkAllDay.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)edtStartDate.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)edtStartDate.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)edtEndDate.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)edtEndDate.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)chkReminder.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbDescription.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbLocation.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)panel1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cbReminder.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)edtLabel.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)edtResource.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)edtStartTime.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)edtEndTime.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)edtShowTimeAs.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)slueCustomer.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)searchLookUpEdit1View).EndInit();
            ((System.ComponentModel.ISupportInitialize)lueCustomerPackages.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }
        #endregion

        protected DevExpress.XtraEditors.LabelControl lblSubject;
        protected DevExpress.XtraEditors.LabelControl lblLocation;
        protected DevExpress.XtraEditors.LabelControl lblLabel;
        protected DevExpress.XtraEditors.LabelControl lblStartTime;
        protected DevExpress.XtraEditors.LabelControl lblEndTime;
        protected DevExpress.XtraEditors.LabelControl lblShowTimeAs;
        protected DevExpress.XtraEditors.CheckEdit chkAllDay;
        protected DevExpress.XtraEditors.SimpleButton btnOk;
        protected DevExpress.XtraEditors.SimpleButton btnCancel;
        protected DevExpress.XtraEditors.SimpleButton btnDelete;
        protected DevExpress.XtraEditors.SimpleButton btnRecurrence;
        protected DevExpress.XtraEditors.DateEdit edtStartDate;
        protected DevExpress.XtraEditors.DateEdit edtEndDate;
        protected DevExpress.XtraEditors.TimeEdit edtStartTime;
        protected DevExpress.XtraEditors.TimeEdit edtEndTime;
        protected DevExpress.XtraScheduler.UI.AppointmentLabelEdit edtLabel;
        protected DevExpress.XtraScheduler.UI.AppointmentStatusEdit edtShowTimeAs;
        protected DevExpress.XtraEditors.TextEdit tbSubject;
        protected DevExpress.XtraScheduler.UI.AppointmentResourceEdit edtResource;
        protected DevExpress.XtraEditors.LabelControl lblResource;
        protected DevExpress.XtraEditors.CheckEdit chkReminder;
        protected DevExpress.XtraEditors.MemoEdit tbDescription;
        protected DevExpress.XtraScheduler.UI.DurationEdit cbReminder;
        private System.ComponentModel.IContainer components = null;
        protected DevExpress.XtraEditors.TextEdit tbLocation;
        protected DevExpress.XtraEditors.PanelControl panel1;
        private DevExpress.XtraEditors.SearchLookUpEdit slueCustomer;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        protected DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lueCustomerPackages;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}