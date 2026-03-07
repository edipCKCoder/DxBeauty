using DevExpress.Utils;
using DevExpress.Utils.Controls;
using DevExpress.Utils.Internal;
using DevExpress.Utils.Menu;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Native;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Internal;
using DevExpress.XtraScheduler.Localization;
using DevExpress.XtraScheduler.Native;
using DevExpress.XtraScheduler.UI;
using DXBeauty.Data;
using DXBeauty.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using Appointment = DevExpress.XtraScheduler.Appointment;

namespace DXBeauty.UI
{
    public partial class CustomAppointmentForm : XtraForm, IDXManagerPopupMenu
    {

        bool openRecurrenceForm;
        readonly ISchedulerStorage storage;
        readonly SchedulerControl control;
        SvgImage recurringSvgImage;
        SvgImage normalSvgImage;
        readonly MyAppointmentFormController controller;
        IDXMenuManager menuManager;
        private string connectionString;
        private DevExpress.XtraScheduler.Appointment _sourceAppointment;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public CustomAppointmentForm()
        {
            InitializeComponent();
        }
        public CustomAppointmentForm(SchedulerControl control, Appointment apt)
            : this(control, apt, false)
        {
        }
        public CustomAppointmentForm(SchedulerControl control, Appointment apt, bool openRecurrenceForm)
        {
            Guard.ArgumentNotNull(control, "control");
            Guard.ArgumentNotNull(control.DataStorage, "control.DataStorage");
            Guard.ArgumentNotNull(apt, "apt");
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            this.openRecurrenceForm = openRecurrenceForm;
            this.controller = (MyAppointmentFormController)CreateController(control, apt);
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            SetupPredefinedConstraints();

            LoadIcons();

            this.control = control;
            this.storage = control.DataStorage;

            this.edtShowTimeAs.Storage = this.storage;
            this.edtLabel.Storage = this.storage;
            this.edtResource.SchedulerControl = control;
            this.edtResource.Storage = this.storage;
            // this.edtResources.SchedulerControl = control;

            SubscribeControllerEvents(Controller);
            SubscribeEditorsEvents();
            BindControllerToControls();

        }

        protected override FormShowMode ShowMode { get { return FormShowMode.AfterInitialization; } }
        [Browsable(false)]
        public IDXMenuManager MenuManager { get { return this.menuManager; } private set { this.menuManager = value; } }
        protected internal new MyAppointmentFormController Controller { get { return this.controller; } } // YENİ
        protected internal SchedulerControl Control { get { return this.control; } }
        protected internal ISchedulerStorage Storage { get { return this.storage; } }
        protected internal bool IsNewAppointment { get { return this.controller != null ? this.controller.IsNewAppointment : true; } }
        protected internal SvgImage RecurringSvgImage { get { return this.recurringSvgImage; } }
        protected internal SvgImage NormalSvgImage { get { return this.normalSvgImage; } }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SvgImage SvgImage { get { return IconOptions.SvgImage; } set { IconOptions.SvgImage = value; } }
        protected internal bool OpenRecurrenceForm { get { return this.openRecurrenceForm; } }
        [DXDescription("DevExpress.XtraScheduler.UI.AppointmentForm,ReadOnly")]
        [DXCategory(CategoryName.Behavior)]
        [DefaultValue(false)]
        public bool ReadOnly
        {
            get { return Controller != null && Controller.ReadOnly; }
            set
            {
                if (Controller.ReadOnly == value)
                    return;
                Controller.ReadOnly = value;
            }
        }

        public virtual void LoadFormData(Appointment appointment)
        {

            

            if (Controller == null) return;

            

            var myController = (MyAppointmentFormController)Controller;

            _sourceAppointment = myController.EditedAppointmentCopy; // Tıklanan orijinal randevuyu hafızaya aldık!

            // --- 1. MÜŞTERİYİ SEÇ ---
            if (myController.CustomerId != null)
            {
                slueCustomer.EditValue = myController.CustomerId.Value;
            }

            // --- 2. RADYO BUTONLARI VE PAKET/HİZMET SEÇİMİ ---
            if (myController.CustomerServiceId != null)
            {
                CurrentPackageradioButton.Checked = true;

                if (myController.CustomerId != null)
                {
                    var repo = new CustomerServiceRepository(connectionString);
                    var activeServices = repo.GetByCustomer(myController.CustomerId.Value);

                    lueCustomerService.Properties.DisplayMember = "Name";
                    lueCustomerService.Properties.ValueMember = "CustomerServiceId";
                    lueCustomerService.Properties.DataSource = activeServices;
                    SetupPackageLookupColumns();

                    lueCustomerService.EditValue = myController.CustomerServiceId.Value;
                }
            }
            else if (myController.ServiceId != null)
            {
                oneSeansRadioButton.Checked = true;

                var repo = new ServiceRepository(connectionString);
                var allServices = repo.GetAll();

                lueCustomerService.Properties.DisplayMember = "Name";
                lueCustomerService.Properties.ValueMember = "ServiceId";
                lueCustomerService.Properties.DataSource = allServices;
                lueCustomerService.Properties.Columns.Clear();

                lueCustomerService.EditValue = myController.ServiceId.Value;
            }

            // --- 3. GÜVENLİK KİLİDİ (YENİ EKLENEN KISIM) ---
            // IsNewAppointment true ise butonlar aktif (Enabled = true) olur,
            // Eski randevu ise (IsNewAppointment false) butonlar kilitlenir (Enabled = false) olur.
            CurrentPackageradioButton.Enabled = IsNewAppointment;
            oneSeansRadioButton.Enabled = IsNewAppointment;

            // Opsiyonel: Müşterinin değiştirilmesini de engellemek istersen:
             slueCustomer.Enabled = IsNewAppointment;

        }
        public virtual bool SaveFormData(Appointment appointment)
        {
            var myController = (MyAppointmentFormController)Controller;

            // Eğer Müşteri Listesi'nden (slueCustomer) bir seçim yapılmışsa onu alalım.
            // Çünkü artık randevuda Müşteri ID de tutuyoruz.
            if (slueCustomer.EditValue != null && slueCustomer.EditValue != DBNull.Value)
            {
                myController.CustomerId = Convert.ToInt32(slueCustomer.EditValue);
            }
            else
            {
                myController.CustomerId = null;
            }

            // Hizmet/Paket LookUpEdit'i boş mu?
            if (lueCustomerService.EditValue == null || lueCustomerService.EditValue == DBNull.Value)
            {
                myController.CustomerServiceId = null;
                myController.ServiceId = null;
            }
            else
            {
                // Dinamik olarak seçili satırı alıyoruz, çünkü bu nesne bazen 'CustomerService' bazen 'Service' sınıfıdır.
                var seciliSatir = lueCustomerService.GetSelectedDataRow() as dynamic;

                if (seciliSatir != null)
                {
                    if (CurrentPackageradioButton.Checked)
                    {
                        // Mevcut Paket seçiliyse
                        myController.CustomerServiceId = seciliSatir.CustomerServiceId; // Senin DB tablonun paket ID kolonu
                        myController.ServiceId = null;
                    }
                    else if (oneSeansRadioButton.Checked)
                    {
                        // Tek Seans seçiliyse
                        myController.ServiceId = seciliSatir.ServiceId; // Senin DB tablonun servis ID kolonu
                        myController.CustomerServiceId = null;
                    }
                }
            }
            return true;
        }
        public virtual bool IsAppointmentChanged(Appointment appointment)
        {
            return false;
        }
        public virtual void SetMenuManager(IDXMenuManager menuManager)
        {
            MenuManagerUtils.SetMenuManager(Controls, menuManager);
            this.menuManager = menuManager;
        }

        protected internal virtual void SetupPredefinedConstraints()
        {

            // this.edtResources.Visible = true;
        }
        protected virtual void BindControllerToControls()
        {
            BindControllerToIcon();
            BindProperties(this.tbSubject, "Text", "Subject");
            BindProperties(this.tbLocation, "Text", "Location");
            BindProperties(this.tbDescription, "Text", "Description");
            BindProperties(this.edtShowTimeAs, "Status", "Status");
            BindProperties(this.edtStartDate, "EditValue", "DisplayStartDate");
            BindProperties(this.edtStartDate, "Enabled", "IsDateTimeEditable");
            BindProperties(this.edtStartTime, "EditValue", "DisplayStartTime");
            BindProperties(this.edtStartTime, "Visible", "IsTimeVisible");
            BindProperties(this.edtStartTime, "Enabled", "IsTimeVisible");
            BindProperties(this.edtEndDate, "EditValue", "DisplayEndDate", DataSourceUpdateMode.Never);
            BindProperties(this.edtEndDate, "Enabled", "IsDateTimeEditable", DataSourceUpdateMode.Never);
            BindProperties(this.edtEndTime, "EditValue", "DisplayEndTime", DataSourceUpdateMode.Never);
            BindProperties(this.edtEndTime, "Visible", "IsTimeVisible", DataSourceUpdateMode.Never);
            BindProperties(this.edtEndTime, "Enabled", "IsTimeVisible", DataSourceUpdateMode.Never);
            BindProperties(this.chkAllDay, "Checked", "AllDay");
            BindProperties(this.chkAllDay, "Enabled", "IsDateTimeEditable");

            BindProperties(this.edtResource, "ResourceId", "ResourceId");
            BindProperties(this.slueCustomer, "EditValue", "CustomerId");
           

            BindProperties(this.edtResource, "Enabled", "CanEditResource");
            BindToBoolPropertyAndInvert(this.edtResource, "Visible", "ResourceSharing");

            
            BindProperties(this.lblResource, "Enabled", "CanEditResource");

            BindProperties(this.edtLabel, "Label", "Label");
            BindProperties(this.chkReminder, "Enabled", "ReminderVisible");
            BindProperties(this.chkReminder, "Visible", "ReminderVisible");
            BindProperties(this.chkReminder, "Checked", "HasReminder");
            BindProperties(this.cbReminder, "Enabled", "HasReminder");
            BindProperties(this.cbReminder, "Visible", "ReminderVisible");
            BindProperties(this.cbReminder, "Duration", "ReminderTimeBeforeStart");



            BindToBoolPropertyAndInvert(this.btnOk, "Enabled", "ReadOnly");
            BindToBoolPropertyAndInvert(this.btnRecurrence, "Enabled", "ReadOnly");
            BindProperties(this.btnDelete, "Enabled", "CanDeleteAppointment");
            BindProperties(this.btnRecurrence, "Visible", "ShouldShowRecurrenceButton");
          
        }
        protected virtual void BindControllerToIcon()
        {
            Binding binding = new Binding("SvgImage", Controller, "AppointmentType");
            binding.Format += AppointmentTypeToIconConverter;
            DataBindings.Add(binding);
        }
        protected virtual void ObjectToStringConverter(object o, ConvertEventArgs e)
        {
            e.Value = e.Value.ToString();
        }
        protected virtual void AppointmentTypeToIconConverter(object o, ConvertEventArgs e)
        {
            AppointmentType type = (AppointmentType)e.Value;
            if (type == AppointmentType.Pattern)
                e.Value = RecurringSvgImage;
            else
                e.Value = NormalSvgImage;
        }
        protected virtual void BindProperties(Control target, string targetProperty, string sourceProperty)
        {
            BindProperties(target, targetProperty, sourceProperty, DataSourceUpdateMode.OnPropertyChanged);
        }
        protected virtual void BindProperties(Control target, string targetProperty, string sourceProperty, DataSourceUpdateMode updateMode)
        {
            target.DataBindings.Add(targetProperty, Controller, sourceProperty, true, updateMode);
        }
        protected virtual void BindProperties(Control target, string targetProperty, string sourceProperty, ConvertEventHandler objectToStringConverter)
        {
            Binding binding = new Binding(targetProperty, Controller, sourceProperty, true);
            binding.Format += objectToStringConverter;
            target.DataBindings.Add(binding);
        }
        protected virtual void BindToBoolPropertyAndInvert(Control target, string targetProperty, string sourceProperty)
        {
            target.DataBindings.Add(new BoolInvertBinding(targetProperty, Controller, sourceProperty));
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (Controller == null)
                return;

            // --- MÜŞTERİ LİSTESİNİ DOLDURMA ---
            try
            {
                // 1. ÖNCE AYARLAR: Veriyi vermeden önce hangi kolonların kullanılacağını söyle (Çift render'ı önler)
                slueCustomer.Properties.DisplayMember = "FullName";
                slueCustomer.Properties.ValueMember = "CustomerId";

                // 2. VERİYİ ÇEK: 
                var customerRepo = new CustomerRepository(connectionString);
                var customers = customerRepo.GetAll();

                // 3. VERİYİ BAĞLA: Ayarları zaten bildiği için tek seferde işler
                slueCustomer.Properties.DataSource = customers;

                // 4. ZORUNLU ÇİZİM (SİHİRLİ DOKUNUŞ): DevExpress'e "Tembellik yapma, görseli anında hesapla ve ekrana çiz" diyoruz.
                slueCustomer.ForceInitialize();

                // 5. BAĞLAMAYI OKU: Formdaki ID'ye göre müşteriyi seç
                if (this.slueCustomer.DataBindings["EditValue"] != null)
                {
                    this.slueCustomer.DataBindings["EditValue"].ReadValue();
                }

                // Arama kısmında hangi kolonlar görünsün?
                SetupCustomerSearchLookupColumns();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Müşteri listesi yüklenirken hata oluştu: " + ex.Message);
            }
            DataBindings.Add("Text", Controller, "Caption");
            SubscribeControlsEvents();
            LoadFormData(Controller.EditedAppointmentCopy);

        }
        protected virtual AppointmentFormController CreateController(SchedulerControl control, Appointment apt)
        {
            return new MyAppointmentFormController(control, apt);
        }
        void SubscribeEditorsEvents()
        {
            this.cbReminder.EditValueChanging += OnCbReminderEditValueChanging;
        }
        void SubscribeControllerEvents(AppointmentFormController controller)
        {
            if (controller == null)
                return;
            controller.PropertyChanged += OnControllerPropertyChanged;
        }
        void OnControllerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ReadOnly")
                UpdateReadonly();
        }
        protected virtual void UpdateReadonly()
        {
            if (Controller == null)
                return;
            IList<Control> controls = GetAllControls(this);
            foreach (Control control in controls)
            {
                BaseEdit editor = control as BaseEdit;
                if (editor == null)
                    continue;
                editor.ReadOnly = Controller.ReadOnly;
            }
            this.btnOk.Enabled = !Controller.ReadOnly;
            this.btnRecurrence.Enabled = !Controller.ReadOnly;
        }

        List<Control> GetAllControls(Control rootControl)
        {
            List<Control> result = new List<Control>();
            foreach (Control control in rootControl.Controls)
            {
                result.Add(control);
                IList<Control> childControls = GetAllControls(control);
                result.AddRange(childControls);
            }
            return result;
        }
        protected internal virtual void LoadIcons()
        {
            Assembly asm = typeof(ResourceImageLoader).Assembly;
            this.recurringSvgImage = ResourceImageHelper.CreateSvgImageFromResources(SchedulerSvgImageNames.NewRecurringAppointment, asm);
            this.normalSvgImage = ResourceImageHelper.CreateSvgImageFromResources(SchedulerSvgImageNames.NewAppointment, asm);
        }
        protected internal virtual void SubscribeControlsEvents()
        {
            this.edtEndDate.Validating += new CancelEventHandler(OnEdtEndDateValidating);
            this.edtEndDate.InvalidValue += new InvalidValueExceptionEventHandler(OnEdtEndDateInvalidValue);
            this.edtEndTime.Validating += new CancelEventHandler(OnEdtEndTimeValidating);
            this.edtEndTime.InvalidValue += new InvalidValueExceptionEventHandler(OnEdtEndTimeInvalidValue);
            this.cbReminder.InvalidValue += new InvalidValueExceptionEventHandler(OnCbReminderInvalidValue);
            this.cbReminder.Validating += new CancelEventHandler(OnCbReminderValidating);
            this.edtStartDate.Validating += new CancelEventHandler(OnEdtStartDateValidating);
            this.edtStartDate.InvalidValue += new InvalidValueExceptionEventHandler(OnEdtStartDateInvalidValue);
            this.edtStartTime.Validating += new CancelEventHandler(OnEdtStartTimeValidating);
            this.edtStartTime.InvalidValue += new InvalidValueExceptionEventHandler(OnEdtStartTimeInvalidValue);
        }
        protected internal virtual void UnsubscribeControlsEvents()
        {
            this.edtEndDate.Validating -= new CancelEventHandler(OnEdtEndDateValidating);
            this.edtEndDate.InvalidValue -= new InvalidValueExceptionEventHandler(OnEdtEndDateInvalidValue);
            this.edtEndTime.Validating -= new CancelEventHandler(OnEdtEndTimeValidating);
            this.edtEndTime.InvalidValue -= new InvalidValueExceptionEventHandler(OnEdtEndTimeInvalidValue);
            this.cbReminder.InvalidValue -= new InvalidValueExceptionEventHandler(OnCbReminderInvalidValue);
            this.cbReminder.Validating -= new CancelEventHandler(OnCbReminderValidating);
            this.edtStartDate.Validating -= new CancelEventHandler(OnEdtStartDateValidating);
            this.edtStartDate.InvalidValue -= new InvalidValueExceptionEventHandler(OnEdtStartDateInvalidValue);
            this.edtStartTime.Validating -= new CancelEventHandler(OnEdtStartTimeValidating);
            this.edtStartTime.InvalidValue -= new InvalidValueExceptionEventHandler(OnEdtStartTimeInvalidValue);
        }
        void OnBtnOkClick(object sender, EventArgs e)
        {
            OnOkButton();
        }
        protected internal virtual void OnEdtStartTimeInvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ErrorText = SchedulerLocalizer.GetString(SchedulerStringId.Msg_DateOutsideLimitInterval);
        }
        protected internal virtual void OnEdtStartTimeValidating(object sender, CancelEventArgs e)
        {
            e.Cancel = !Controller.ValidateLimitInterval(this.edtStartDate.DateTime.Date, this.edtStartTime.Time.TimeOfDay, this.edtEndDate.DateTime.Date, this.edtEndTime.Time.TimeOfDay);
        }
        protected internal virtual void OnEdtStartDateInvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ErrorText = SchedulerLocalizer.GetString(SchedulerStringId.Msg_DateOutsideLimitInterval);
        }
        protected internal virtual void OnEdtStartDateValidating(object sender, CancelEventArgs e)
        {
            e.Cancel = !Controller.ValidateLimitInterval(this.edtStartDate.DateTime.Date, this.edtStartTime.Time.TimeOfDay, this.edtEndDate.DateTime.Date, this.edtEndTime.Time.TimeOfDay);
        }
        protected internal virtual void OnEdtEndDateValidating(object sender, CancelEventArgs e)
        {
            e.Cancel = !IsValidInterval();
            if (!e.Cancel)
                this.edtEndDate.DataBindings["EditValue"].WriteValue();
        }
        protected internal virtual void OnEdtEndDateInvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            if (!AppointmentFormControllerBase.ValidateInterval(this.edtStartDate.DateTime.Date, this.edtStartTime.Time.TimeOfDay, this.edtEndDate.DateTime.Date, this.edtEndTime.Time.TimeOfDay))
                e.ErrorText = SchedulerLocalizer.GetString(SchedulerStringId.Msg_InvalidEndDate);
            else
                e.ErrorText = SchedulerLocalizer.GetString(SchedulerStringId.Msg_DateOutsideLimitInterval);
        }
        protected internal virtual void OnEdtEndTimeValidating(object sender, CancelEventArgs e)
        {
            e.Cancel = !IsValidInterval();
            if (!e.Cancel)
                this.edtEndTime.DataBindings["EditValue"].WriteValue();
        }
        protected internal virtual void OnEdtEndTimeInvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            if (!AppointmentFormControllerBase.ValidateInterval(this.edtStartDate.DateTime.Date, this.edtStartTime.Time.TimeOfDay, this.edtEndDate.DateTime.Date, this.edtEndTime.Time.TimeOfDay))
                e.ErrorText = SchedulerLocalizer.GetString(SchedulerStringId.Msg_InvalidEndDate);
            else
                e.ErrorText = SchedulerLocalizer.GetString(SchedulerStringId.Msg_DateOutsideLimitInterval);
        }
        protected internal virtual bool IsValidInterval()
        {
            return AppointmentFormControllerBase.ValidateInterval(this.edtStartDate.DateTime.Date, this.edtStartTime.Time.TimeOfDay, this.edtEndDate.DateTime.Date, this.edtEndTime.Time.TimeOfDay) &&
                Controller.ValidateLimitInterval(this.edtStartDate.DateTime.Date, this.edtStartTime.Time.TimeOfDay, this.edtEndDate.DateTime.Date, this.edtEndTime.Time.TimeOfDay);
        }
        protected internal virtual void OnOkButton()
        {


            if (oneSeansRadioButton.Checked == false && CurrentPackageradioButton.Checked == false)
            {
                XtraMessageBox.Show(
                    "Lütfen Randevu tipini seçiniz.",
                    "Eksik Bilgi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (lueCustomerService.EditValue == null || lueCustomerService.EditValue == DBNull.Value)
            {
                XtraMessageBox.Show(
                    "Lütfen bir Önce Müşteri sonra Hizmet/Paket seçiniz.",
                    "Eksik Bilgi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if(slueCustomer.EditValue == null || slueCustomer.EditValue == DBNull.Value)
            {
                XtraMessageBox.Show(
                    "Lütfen bir Müşteri seçiniz.",
                    "Eksik Bilgi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if(tbSubject.Text == "" || tbSubject.Text == null)
            {
                XtraMessageBox.Show(
                    "Lütfen Eksik Randevu Bilgilerini G",
                    "Eksik Bilgi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }


            // --- GEÇMİŞ ZAMAN KONTROLÜ ---
            DateTime secilenBaslangic = edtStartDate.DateTime.Date + edtStartTime.Time.TimeOfDay;

            // Kural: Seçilen saat ŞU AN'dan küçükse VE bu YENİ bir randevuysa engelle!
            // (IsNewAppointment kullanıyoruz ki, dünkü randevuyu açıp durumunu güncelleyebilsinler)
            if (Controller.IsNewAppointment && secilenBaslangic < DateTime.Now)
            {
                XtraMessageBox.Show(
                    "Geçmiş bir tarih veya saate yeni randevu oluşturulamaz. Lütfen ileri bir zaman seçiniz.",
                    "Geçersiz Tarih",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return; // Formun kapanmasını ve kaydetmeyi engelle
            }

            if (!Controller.IsNewAppointment && secilenBaslangic < DateTime.Now)
            {
                XtraMessageBox.Show(
                    "Randevular geçmiş bir tarihe veya saate taşınamaz!",
                    "Geçersiz İşlem",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return; // Formun kapanmasını ve kaydetmeyi engelle
            }

           

            if (!ValidateDateAndTime())
                return;
            if (!SaveFormData(Controller.EditedAppointmentCopy))
                return;
            // YENİ HALİ: Personel Çakışma Kontrolü
            if (!Controller.IsConflictResolved())
            {
                XtraMessageBox.Show(
                    "Seçilen personelin bu saat diliminde başka bir randevusu bulunmaktadır. Lütfen farklı bir saat veya personel seçiniz.",
                    "Personel Çakışması",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return; // Formun kapanmasını ve kaydetmeyi engeller
            }
            if (!Controller.IsTimeValid())
            {
                ShowMessageBox(SchedulerLocalizer.GetString(SchedulerStringId.Msg_InvalidAppointmentTime), Controller.GetMessageBoxCaption(SchedulerStringId.Msg_InvalidAppointmentTime), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (IsAppointmentChanged(Controller.EditedAppointmentCopy) || Controller.IsAppointmentChanged() || Controller.IsNewAppointment)
                Controller.ApplyChanges();

            DialogResult = DialogResult.OK;
        }
        private bool ValidateDateAndTime()
        {
            this.edtEndDate.DoValidate();
            this.edtEndTime.DoValidate();
            this.edtStartDate.DoValidate();
            this.edtStartTime.DoValidate();

            return String.IsNullOrEmpty(this.edtEndTime.ErrorText) && String.IsNullOrEmpty(this.edtEndDate.ErrorText) && String.IsNullOrEmpty(this.edtStartDate.ErrorText) && String.IsNullOrEmpty(this.edtStartTime.ErrorText);
        }
        protected internal virtual DialogResult ShowMessageBox(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return XtraMessageBox.Show(this, text, caption, buttons, icon);
        }
        void OnBtnDeleteClick(object sender, EventArgs e)
        {
            OnDeleteButton();
        }
        protected internal virtual void OnDeleteButton()
        {
            if (IsNewAppointment)
                return;

            Controller.DeleteAppointment();

            DialogResult = DialogResult.Abort;
            Close();
        }
        void OnBtnRecurrenceClick(object sender, EventArgs e)
        {
            OnRecurrenceButton();
        }
        protected internal virtual void OnRecurrenceButton()
        {
            if (!Controller.ShouldShowRecurrenceButton)
                return;
            // --- YENİ EKLENEN GÜVENLİK KONTROLÜ ---
            if (oneSeansRadioButton.Checked)
            {
                XtraMessageBox.Show(
                    "Tek seanslık işlemler için tekrarlayan (yineleyen) randevu oluşturamazsınız. Yinelenen bir randevu oluşturmak için lütfen 'Paket' seçimi yapınız.",
                    "Geçersiz İşlem",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return; // İşlemi burada kes! Recurrence formunun açılmasını engeller.
            }
            // ----------------------------------------
            if (oneSeansRadioButton.Checked == false && CurrentPackageradioButton.Checked == false)
            {
                XtraMessageBox.Show(
                    "Yinelenen bir randevu oluşturmak için lütfen Randevu tipini(Paket olarak) seçiniz.",
                    "Geçersiz İşlem",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return; // İşlemi burada kes! Recurrence formunun açılmasını engeller.
            }
            // ----------------------------------------
            Appointment patternCopy = Controller.PrepareToRecurrenceEdit();

            DialogResult result;
            using (Form form = CreateAppointmentRecurrenceForm(patternCopy, Control.OptionsView.FirstDayOfWeek))
            {
                result = ShowRecurrenceForm(form);
            }

            if (result == DialogResult.Abort)
            {
                Controller.RemoveRecurrence();
            }
            else if (result == DialogResult.OK)
            {
                Controller.ApplyRecurrence(patternCopy);
            }
        }
        protected virtual DialogResult ShowRecurrenceForm(Form form)
        {
            return form.ShowDialog(this);
        }
        protected internal virtual Form CreateAppointmentRecurrenceForm(Appointment patternCopy, FirstDayOfWeek firstDayOfWeek)
        {
            AppointmentRecurrenceForm form = new AppointmentRecurrenceForm(patternCopy, firstDayOfWeek, Controller);
            form.SetMenuManager(MenuManager);
            form.LookAndFeel.ParentLookAndFeel = LookAndFeel;
            form.ShowExceptionsRemoveMsgBox = this.controller.AreExceptionsPresent();
            return form;
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (this.openRecurrenceForm)
            {
                this.openRecurrenceForm = false;
                OnRecurrenceButton();
            }
        }
        protected internal virtual void OnCbReminderValidating(object sender, CancelEventArgs e)
        {
            TimeSpan span = this.cbReminder.Duration;
            e.Cancel = (span == TimeSpan.MinValue) || (span.Ticks < 0);
            if (!e.Cancel)
                this.cbReminder.DataBindings["Duration"].WriteValue();
        }
        protected internal virtual void OnCbReminderInvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ErrorText = SchedulerLocalizer.GetString(SchedulerStringId.Msg_InvalidReminderTimeBeforeStart);
        }

        void OnCbReminderEditValueChanging(object sender, ChangingEventArgs e)
        {
            if (e.NewValue is TimeSpan)
                return;
            string stringValue = e.NewValue as String;
            TimeSpan duration = HumanReadableTimeSpanHelper.Parse(stringValue);
            if (duration.Ticks < 0)
                e.NewValue = TimeSpan.FromTicks(0);
        }



        private void slueCustomer_EditValueChanged(object sender, EventArgs e)
        {

            try
            {

                if (slueCustomer.EditValue == null || slueCustomer.EditValue == DBNull.Value) return;

                if (CurrentPackageradioButton.Checked)
                {
                    int selectedCustomerId = Convert.ToInt32(slueCustomer.EditValue);


                    // 1. Paketleri getir
                    var repo = new CustomerServiceRepository(connectionString);
                    var activeServices = repo.GetByCustomer(selectedCustomerId);

                    // 2. Paket LookUpEdit ayarları
                    lueCustomerService.Properties.DisplayMember = "Name";
                    lueCustomerService.Properties.ValueMember = "CustomerServiceId";
                    lueCustomerService.Properties.DataSource = activeServices;
                    
                    
                    SetupPackageLookupColumns();
                }
                else if (oneSeansRadioButton.Checked)
                {
                    lueCustomerService.Properties.Columns.Clear();
                    var repo = new ServiceRepository(connectionString);
                    var allServices = repo.GetAll();

                    // 2. Paket LookUpEdit ayarları
                    lueCustomerService.Properties.DisplayMember = "Name";
                    lueCustomerService.Properties.ValueMember = "ServiceId";
                    lueCustomerService.Properties.DataSource = allServices;
                  
                    
                }

            }
            finally
            {

            }
        }

        private void lueCustomerService_EditValueChanged(object sender, EventArgs e)
        {
            // 1. Güvenlik Kontrolleri

            try
            {
                if (lueCustomerService.EditValue == null || lueCustomerService.EditValue == DBNull.Value) return;
                // 2. Müşteri Adını Al (SearchLookUpEdit'in görünen metni)
                string customerName = slueCustomer.Text;

                // 3. Seçilen Paketin Detaylarını Al 
                // GetSelectedDataRow() kullanarak tüm satır nesnesine erişebiliriz
                var selectedPackage = lueCustomerService.GetSelectedDataRow() as dynamic;

                if (selectedPackage != null)
                {
                    string packageName = selectedPackage.Name; // Veritabanındaki kolon adın
                    int remaining = selectedPackage.RemainingSessions; // Kalan seans sayın

                    // 4. Formatı Oluştur: "Müşteri Adı" - Lazer Epilasyon - (Kalan: 5)
                    string autoSubject = $"\"{customerName}\" - {packageName} - (Kalan: {remaining})";

                    // 5. Formdaki Subject (Konu) kutusuna yazdır
                    // Genelde DevExpress formunda adı 'edtSubject' olur
                    tbSubject.Text = autoSubject;

                    // 6. Controller'a da bildir (Kaydederken sorun çıkmaması için)
                    Controller.Subject = autoSubject;
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda sessizce devam et veya logla
                Debug.WriteLine("Subject oluşturulurken hata: " + ex.Message);
            }
        }

        private void SetupPackageLookupColumns()
        {
            // 3. Kolonları temizle ve yeniden oluştur (Görsellik için)
            lueCustomerService.Properties.Columns.Clear();
            lueCustomerService.Properties.PopulateColumns();

            if (lueCustomerService.Properties.Columns["CustomerServiceId"] != null)
                lueCustomerService.Properties.Columns["CustomerServiceId"].Visible = false;

            if (lueCustomerService.Properties.Columns["CustomerId"] != null)
                lueCustomerService.Properties.Columns["CustomerId"].Visible = false;

            if (lueCustomerService.Properties.Columns["ServicePackageId"] != null)
                lueCustomerService.Properties.Columns["ServicePackageId"].Visible = false;
            if (lueCustomerService.Properties.Columns["StartDate"] != null)
                lueCustomerService.Properties.Columns["StartDate"].Visible = false;
            if (lueCustomerService.Properties.Columns["TotalPrice"] != null)
                lueCustomerService.Properties.Columns["TotalPrice"].Visible = false;
        }

        private void SetupCustomerSearchLookupColumns()
        {
            slueCustomer.Properties.PopulateViewColumns();
            // SearchLookUpEdit için görünüm (View) üzerinden işlem yapılır
            var view = slueCustomer.Properties.View;


            // Önce tüm kolonları gizle, sonra istediklerini aç
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in view.Columns)
            {
                col.Visible = false;
            }

            view.Columns["FullName"].Visible = true;
            view.Columns["PhoneNumber"].Visible = true;
        }
       

        private void CurrentPackageradioButton_Click(object sender, EventArgs e)
        {
            if (slueCustomer.EditValue == null || slueCustomer.EditValue == DBNull.Value) return;
            int selectedCustomerId = Convert.ToInt32(slueCustomer.EditValue);


            // 1. Paketleri getir
            var repo = new CustomerServiceRepository(connectionString);
            var activeServices = repo.GetByCustomer(selectedCustomerId);

            // 2. Paket LookUpEdit ayarları
            lueCustomerService.Properties.DisplayMember = "Name";
            lueCustomerService.Properties.ValueMember = "CustomerServiceId";
            lueCustomerService.Properties.DataSource = activeServices;
           
            

            SetupPackageLookupColumns();
        }

        private void oneSeansRadioButton_Click(object sender, EventArgs e)
        {

            lueCustomerService.Properties.Columns.Clear();
            var repo = new ServiceRepository(connectionString);
            var allServices = repo.GetAll();

            // 2. Paket LookUpEdit ayarları
            lueCustomerService.Properties.DisplayMember = "Name";
            lueCustomerService.Properties.ValueMember = "ServiceId";
            lueCustomerService.Properties.DataSource = allServices;
            
            
        }
      
    }
}