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
using DXBeauty.Dtos;
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
        private CustomerServiceRepository _customerServiceRepository;
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
            _customerServiceRepository = new CustomerServiceRepository(connectionString);

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
            // =====================================================================
            // İŞTE YENİ GÜVENLİK KİLİDİ: MÜŞTERİ DEĞİŞTİRME ENGELİ
            // =====================================================================
            if (!myController.IsNewAppointment)
            {
                // Eğer bu var olan (eski) bir randevuysa, müşteri kutusunu kilitle!
                slueCustomer.ReadOnly = true;
                // İsteğe bağlı: Personel neden kilitli olduğunu anlasın diye ipucu ekleyebilirsin
                slueCustomer.ToolTip = "Var olan bir randevunun müşterisi değiştirilemez. Yanlışlık varsa randevuyu iptal edip yenisini oluşturun.";
            }
            else
            {
                // Yeni randevu açılıyorsa açık bırak
                slueCustomer.ReadOnly = false;
                slueCustomer.ToolTip = "";
            }
            // =====================================================================
            //  RASYONEL MÜDAHALE: Randevu boşluğa veya "Tüm Gün" alanına tıklanarak açılsa bile
            // bunu reddet ve normal saatli randevuya çevir.
            myController.AllDay = false;

            // Arayüzden bu kutuyu tamamen gizle ki personel görüp kafası karışmasın
            this.chkAllDay.Visible = false;

        }
        public virtual bool SaveFormData(Appointment appointment)
        {
            var myController = (MyAppointmentFormController)Controller;

            // Eğer Müşteri Listesi'nden (slueCustomer) bir seçim yapılmışsa onu alalım.
            // Çünkü artık randevuda Müşteri ID de tutuyoruz.
            if (slueCustomer.EditValue != null && slueCustomer.EditValue != DBNull.Value)
            {
                myController.CustomerId = Convert.ToInt32(slueCustomer.EditValue);
                // ZORUNLU BIND: Arka plandaki şablona çiviyle çakıyoruz!
                appointment.CustomFields["CustomerId"] = myController.CustomerId;
            }
            else
            {
                myController.CustomerId = null;
                appointment.CustomFields["CustomerId"] = null;
            }

            // --- EKSİK OLAN: Paket ID (CS_ID) Kaydetme ---
            if (lueCustomerPackages.EditValue != null && lueCustomerPackages.EditValue != DBNull.Value)
            {
                myController.CustomerServiceId = Convert.ToInt32(lueCustomerPackages.EditValue);
                // ZORUNLU BIND: Tekrarlı yavrular doğarken bu CS_ID'yi miras alsın!
                appointment.CustomFields["CS_ID"] = myController.CustomerServiceId;
            }
            else
            {
                myController.CustomerServiceId = null;
                appointment.CustomFields["CS_ID"] = null;
            }

            // --- 3. SUBJECT (KONU) GÜNCELLEMESİ ---
            // Otomasyon metni oluşturmuş olsa bile, tekrarlı randevular bunu kaçırmasın diye
            // TextBox'taki son metni zorla (Hard-Bind) şablona ve Controller'a atıyoruz.
            if (!string.IsNullOrWhiteSpace(tbSubject.Text))
            {
                myController.Subject = tbSubject.Text;
                appointment.Subject = tbSubject.Text;
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
            BindProperties(this.lueCustomerPackages, "EditValue", "CustomerServiceId");

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
        protected override async void OnLoad(EventArgs e)
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
                // Doğrudan cast (null değilse)

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Müşteri listesi yüklenirken hata oluştu: " + ex.Message);
            }
            DataBindings.Add("Text", Controller, "Caption");
            SubscribeControlsEvents();
            LoadFormData(Controller.EditedAppointmentCopy);

        }

        private async void LoadCustomerPackages(int customerId)
        {
            // 1. Veritabanından listeyi çek (Burada SQL kör olduğu için sanal çocukları sayamadı ve Boşta seansı yanlış getirdi)
            var packages = await _customerServiceRepository.GetCustomerActivePackagesAsync(customerId);

            // ======================================================================================
            // 2. SİHİRLİ DOKUNUŞ: DevExpress'in RAM'indeki tüm sanal çocukları sayarak listeyi düzelt!
            // ======================================================================================

            // DevExpress'ten bugünden itibaren gelecek 2 yıl içindeki TÜM randevuları istiyoruz. 
            // GetAppointments metodu XML'leri otomatik açar ve bize sanal/gerçek tüm kutucukları verir!
            var futureAppointments = this.Storage.GetAppointments(DateTime.Now.Date, DateTime.Now.AddYears(2));

            foreach (var package in packages)
            {
                int takvimdekiPlanliSayi = 0;

                // Gelecekteki tüm randevuları dön ve bu pakete ait olanları say
                foreach (DevExpress.XtraScheduler.Appointment apt in futureAppointments)
                {
                    int? aptCsId = apt.CustomFields["CS_ID"] != null ? Convert.ToInt32(apt.CustomFields["CS_ID"]) : (int?)null;
                    int status = apt.StatusKey != null ? Convert.ToInt32(apt.StatusKey) : 0;

                    // Eğer statüsü Planlandı (1) ise ve bu pakete aitse sayacı artır
                    if (aptCsId == package.CustomerServiceId && status == 1)
                    {
                        takvimdekiPlanliSayi++;
                    }
                }

                // 3. Paketin DTO'sunu ezerek GERÇEK Boşta Seansı güncelle!
                // Gerçek Kalan Seans (DB'den gelen kesin bilgi) eksi Takvimdeki Planlı Kutucuklar (DevExpress'ten gelen kesin bilgi)
                package.AvailableSessions = package.RemainingSessions - takvimdekiPlanliSayi;

                if (package.AvailableSessions < 0) package.AvailableSessions = 0; // Eksiye düşme güvenliği
            }


            lueCustomerPackages.Properties.DataSource = packages;
            lueCustomerPackages.Properties.DisplayMember = "DisplayText"; // Bizim o havalı yazımız
            lueCustomerPackages.Properties.ValueMember = "CustomerServiceId";

            // Opsiyonel: "Paket Dışı / Tek Seans" seçeneği de eklenebilir.
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
            // YENİ: Otomasyon tetikleyicilerini bağlıyoruz
            // Herhangi biri değiştiğinde GenerateAutomaticSubject metodu çalışacak!
            this.slueCustomer.EditValueChanged += GenerateAutomaticSubject;
            this.lueCustomerPackages.EditValueChanged += GenerateAutomaticSubject;
            this.edtResource.EditValueChanged += GenerateAutomaticSubject;

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


            //  YENİ: Otomasyon tetikleyicilerini koparıyoruz (Hafıza sızıntısını önler)
            this.slueCustomer.EditValueChanged -= GenerateAutomaticSubject;
            this.lueCustomerPackages.EditValueChanged -= GenerateAutomaticSubject;
            this.edtResource.EditValueChanged -= GenerateAutomaticSubject;
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


            if (slueCustomer.EditValue == null || slueCustomer.EditValue == DBNull.Value)
            {
                XtraMessageBox.Show(
                    "Lütfen bir Müşteri seçiniz.",
                    "Eksik Bilgi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            //Eğer veznedar bir paket seçmediyse kontrol et
            if (lueCustomerPackages.EditValue == null || lueCustomerPackages.EditValue == DBNull.Value)
            {
                XtraMessageBox.Show(
                    "Lütfen bir Aktif bir Paket seçiniz.",
                    "Eksik Bilgi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            // Eğer veznedar bir paket seçtiyse kontrol et
            if (lueCustomerPackages.EditValue != null && lueCustomerPackages.EditValue != DBNull.Value)
            {
                var selectedPackage = lueCustomerPackages.GetSelectedDataRow() as CustomerServiceLookupDto;

                // 1. Randevu YENİ Mİ (Insert), yoksa VAR OLAN bir randevu mu (Update)?
                bool isNewAppointment = Controller.IsNewAppointment;

                // 2. Eğer var olan bir randevuyu düzenliyorsak, "Paketi değiştirmiş mi?" diye bakmalıyız.
                // (Not: CustomFields içindeki isimlendirmeyi kendi Mapping'ine göre yaz. Örn: "CustomerServiceId")
                int originalPackageId = 0;
                if (!isNewAppointment && Controller.EditedAppointmentCopy.CustomFields["CS_ID"] != null)
                {
                    originalPackageId = Convert.ToInt32(Controller.EditedAppointmentCopy.CustomFields["CS_ID"]);
                }

                int selectedPackageId = Convert.ToInt32(lueCustomerPackages.EditValue);

                // Randevunun paketi değiştirilmiş mi? (Örn: Cilt bakımından Lazer paketine mi çekmiş?)
                bool isPackageChanged = (!isNewAppointment && originalPackageId != selectedPackageId);

                // İŞTE SİHİRLİ DOKUNUŞ: 
                // Sadece randevu YENİYSE veya DÜZENLEME ANINDA PAKETİ DEĞİŞTİRDİYSE boşta seans kontrolüne sok!
                // Aynı paketteki eski randevuyu (Açıklama, Saat vs.) değiştiriyorsa bu bloğu ES GEÇ!

                // EĞER BOŞTA SEANS YOKSA KAYDETMEYİ REDDET!
                if (selectedPackage != null && (isNewAppointment || isPackageChanged) && selectedPackage.AvailableSessions <= 0)
                {
                    XtraMessageBox.Show(
                        $"Uyarı: {selectedPackage.PackageName} için müşterinin {selectedPackage.RemainingSessions} hakkı bulunuyor, ancak bu hakların tamamı zaten takvimde başka günlere planlanmış durumda!\n\nLütfen yeni bir randevu açmak yerine, müşterinin planlanmış randevularından birini düzenleyin veya iptal edin.",
                        "Seans Limiti Dolu",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return; // İşlemi anında kes! Veritabanına gitme.
                }
            }


            if (tbSubject.Text == "" || tbSubject.Text == null)
            {
                XtraMessageBox.Show(
                    "Lütfen Eksik Randevu Bilgilerini konu Giriniz.",
                    "Eksik Bilgi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }


            // --- GEÇMİŞ ZAMAN KONTROLÜ ---
            DateTime secilenBaslangic = edtStartDate.DateTime.Date + edtStartTime.Time.TimeOfDay;

            bool gecmisZamanMi = false;

            // Eğer "Tüm Gün" işaretliyse, sadece gün kontrolü yap (Bugünden küçük mü?)
            // DateTime.Today, o günün 00:00:00 saatini verir.
            if (chkAllDay.Checked)
            {
                gecmisZamanMi = secilenBaslangic.Date < DateTime.Today;
            }
            else
            {
                // Normal saatli randevuysa, anlık saate göre kontrol et.
                // Opsiyonel: Eğer işletmede randevuların 5-10 dakika gecikmeli girilme ihtimali varsa,
                // burayı da "secilenBaslangic.Date < DateTime.Today" yaparak 
                // aynı gün içindeki geçmiş saat kısıtlamasını tamamen kaldırabilirsiniz.
                gecmisZamanMi = secilenBaslangic < DateTime.Now;
            }

            // Kural: Seçilen zaman GEÇMİŞTEYSE ve bu YENİ bir randevuysa engelle!
            if (Controller.IsNewAppointment && gecmisZamanMi)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Geçmiş bir tarih veya saate yeni randevu oluşturulamaz. Lütfen geçerli bir zaman seçiniz.",
                    "Geçersiz Tarih",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Warning);
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


            // SİHİRLİ DOKUNUŞ: Kopyalama (Clone) işleminden hemen önce ekrandaki tüm verileri
            // (Subject, CS_ID vb.) Controller'a zorla yazdır ki tekrarlı yavrular boş doğmasın!
            SaveFormData(Controller.EditedAppointmentCopy);


            // --- YENİ EKLENEN GÜVENLİK KONTROLÜ ---

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

        private void slueCustomer_EditValueChanged(object sender, EventArgs e)
        {
            if (slueCustomer.EditValue != null && slueCustomer.EditValue != DBNull.Value)
            {
                int customerId = Convert.ToInt32(slueCustomer.EditValue);
                // İşlemlerine devam et...
                LoadCustomerPackages(customerId);
            }
        }

        // RASYONEL OTOMASYON: Seçimler değiştikçe konuyu otomatik güncelleyen motor
        private void GenerateAutomaticSubject(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                // Müşteri seçilmeden işlem yapma
                if (slueCustomer.EditValue == null || slueCustomer.EditValue == DBNull.Value) return;

                string musteriAdi = slueCustomer.Text;
                string paketBilgisi = "";
                string personelAdi = edtResource.Text;

                // 1. Paket DTO'sunu yakala ve "AvailableSessions" bilgisini al
                var seciliPaket = lueCustomerPackages.GetSelectedDataRow() as CustomerServiceLookupDto;
                if (seciliPaket != null)
                {
                    // İstediğiniz format: Paket Adı (Boşta: X)
                    paketBilgisi = $"{seciliPaket.PackageName}";
                }

                // 2. Metinleri Birleştirme (Müşteri - Paket)
                string yeniKonu = musteriAdi;

                if (!string.IsNullOrWhiteSpace(paketBilgisi))
                {
                    yeniKonu += $" - {paketBilgisi}";
                }

                // 3. Personel (Resource) seçiliyse ve DevExpress'in varsayılan boş değeri değilse ekle
                if (!string.IsNullOrWhiteSpace(personelAdi) && personelAdi != "(None)" && personelAdi != "Any" && personelAdi != "(Herhangi biri)")
                {
                    yeniKonu += $" ({personelAdi})";
                }

                // 4. Sonucu "Konu" kutusuna yazdır ve DevExpress Controller'ına zorla kaydet!
                tbSubject.Text = yeniKonu.Trim();

                if (tbSubject.DataBindings["Text"] != null)
                {
                    tbSubject.DataBindings["Text"].WriteValue();
                }

            }));
            
        }
    }
}