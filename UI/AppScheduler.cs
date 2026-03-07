using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Xml;
using DXBeauty.Data;
using DXBeauty.Entities;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Drawing.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Appointment = DXBeauty.Entities.Appointment;

namespace DXBeauty.UI
{
    public partial class AppScheduler : DevExpress.XtraEditors.XtraUserControl
    {

        private BindingList<Appointment> appointmentList = new BindingList<Appointment>();
        private PersonnelRepository personnelRepo;
        private BindingList<Personnel> personnelList = new BindingList<Personnel>();
        private readonly string connectionString;
        private AppointmentRepository appointmentRepo;

        public AppScheduler()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            personnelRepo = new PersonnelRepository(connectionString);
            appointmentRepo = new AppointmentRepository(connectionString);


        }

        private void SetupMappings()
        {
            // 1. Storage Bağlantısı (DevExpress yeni versiyonlarda SchedulerDataStorage kullanır)
            SchedulerDataStorage storage = schedulerDataStorage1;

            // // Randevu Eşleştirmeleri
            storage.Appointments.Mappings.AppointmentId = "AppointmentId";
            storage.Appointments.Mappings.Start = "AppointmentStartDate";
            storage.Appointments.Mappings.End = "AppointmentEndDate";
            storage.Appointments.Mappings.ResourceId = "ResourceId";
            storage.Appointments.Mappings.Subject = "Subject";
            storage.Appointments.Mappings.AllDay = "AllDay";
            storage.Appointments.Mappings.Description = "Description";
            storage.Appointments.Mappings.Location = "Location";
            storage.Appointments.Mappings.RecurrenceInfo = "RecurrenceInfo";
            storage.Appointments.Mappings.ReminderInfo = "ReminderInfo";
            storage.Appointments.Mappings.Label = "Label";
            storage.Appointments.Mappings.Status = "Status";
            storage.Appointments.Mappings.Type = "Type";

            // Personel (Resource) Eşleştirmeleri
            storage.Resources.Mappings.Id = "PersonnelId";
            storage.Resources.Mappings.Caption = "FullName";
            storage.Resources.Mappings.Color = "ColorId";
            storage.Resources.ColorSaving = DXColorSavingType.ColorString;


            // --- özel atıf eşleşmesi ---
            storage.Appointments.CustomFieldMappings.Clear(); // Mükerrer eklemeyi önle

            // YENİ EKLENEN SATIR: service_id için DevExpress hafızasında yer açıyoruz
            storage.Appointments.CustomFieldMappings.Add(new AppointmentCustomFieldMapping("ServiceId", "ServiceId"));
            storage.Appointments.CustomFieldMappings.Add(new AppointmentCustomFieldMapping("CS_ID", "CustomerServiceId"));
            storage.Appointments.CustomFieldMappings.Add(new AppointmentCustomFieldMapping("CustomerId", "CustomerId"));
        }

        private void schedulerControl2_EditAppointmentFormShowing(object sender, AppointmentFormEventArgs e)
        {
            CustomAppointmentForm form = new CustomAppointmentForm(schedulerControl2, e.Appointment, e.OpenRecurrenceForm);
            form.ShowDialog();
            e.Handled = true; // DevExpress'in varsayılan formunu göstermesini engelle
        }

        private async void AppScheduler_Load(object sender, EventArgs e)
        {
            // Donmayı engellemek için tüm yükleme işlemini tek bir asenkron metotta topluyoruz
            // Randevu EKLENDİĞİNDE çalışır
            schedulerDataStorage1.AppointmentsInserted += SchedulerDataStorage1_AppointmentsInserted;

            // randevu güncellendiğinde çalışır(sürükle bırak dahil)
            schedulerDataStorage1.AppointmentsChanged += SchedulerDataStorage1_AppointmentsChanged;

            // Randevu SİLİNDİĞİNDE çalışır
            schedulerDataStorage1.AppointmentsDeleted += SchedulerDataStorage1_AppointmentsDeleted;

            // Sürükle-bırak olayını tekil (eski) yapıya manuel olarak bağlıyoruz
            schedulerControl2.AppointmentDrop += SchedulerControl2_AppointmentDrop;

            // Sağ tık menüsü açılırken araya giriyoruz
            schedulerControl2.PopupMenuShowing += SchedulerControl2_PopupMenuShowing;

            await InitializeSchedulerDataAsync();
        }

        private void SchedulerControl2_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            // Sadece "Randevu" üzerine sağ tıklandığında menüye ekleme yap
            if (e.Menu.Id == DevExpress.XtraScheduler.SchedulerMenuItemId.AppointmentMenu)
            {
                // 1. Kendi "Tahsilat Al" butonumuzu oluşturuyoruz
                DevExpress.Utils.Menu.DXMenuItem tahsilatButonu = new DevExpress.Utils.Menu.DXMenuItem("Tahsilat Al");

                // Üstüne şık bir çizgi (ayraç) koysun ki DevExpress'in kendi menüsünden ayrı dursun
                tahsilatButonu.BeginGroup = true;

                // 2. Butona Tıklanma (Click) Olayını Tanımlıyoruz
                tahsilatButonu.Click += (s, args) =>
                {
                    // O an sağ tıklanan (seçili olan) randevuyu yakala
                    var seciliRandevu = schedulerControl2.SelectedAppointments.FirstOrDefault();
                    if (seciliRandevu == null) return;

                    // Randevu ID'sini al
                    int? randevuId = seciliRandevu.Id != null ? Convert.ToInt32(seciliRandevu.Id) : (int?)null;

                    // CustomFields üzerinden Müşteri ID'sini al
                    int? musteriId = null;
                    if (seciliRandevu.CustomFields["CustomerId"] != null && seciliRandevu.CustomFields["CustomerId"] != DBNull.Value)
                    {
                        musteriId = Convert.ToInt32(seciliRandevu.CustomFields["CustomerId"]);
                    }

                    // --- BURASI PAYMENT FORM'UN AÇILACAĞI YER ---

                    // 1.Senin oluşturduğun UserControl'ü (Yapboz parçasını) hazırlıyoruz
                    GetPaymentsControl paymentCtrl = new GetPaymentsControl(musteriId, randevuId, null);

                    // 2. Onu taşıyacak boş bir Taşıyıcı Form (Pencere) oluşturuyoruz
                    DevExpress.XtraEditors.XtraForm popupForm = new DevExpress.XtraEditors.XtraForm();
                    popupForm.Text = "Tahsilat Ekranı";
                    popupForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                    popupForm.Size = new System.Drawing.Size(900, 600); // Gözüne hoş gelen bir boyut verebilirsin

                    // 3. Yapboz parçasını taşıyıcı formun içine koyup ekranı kaplamasını (Fill) sağlıyoruz
                    paymentCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
                    popupForm.Controls.Add(paymentCtrl);

                    // 4. Ve Taşıyıcı Formu açıyoruz!
                    popupForm.ShowDialog();


                };

                // 3. Butonu menünün en üstüne (0. indeks) ekle
                e.Menu.Items.Insert(0, tahsilatButonu);
            }
        }

        private async Task InitializeSchedulerDataAsync()
        {
            try
            {
                // UI güncellemelerini durdur (Performans ve titreme engelleme için)
                schedulerControl2.BeginUpdate();

                // Personellerin (Resource) aynı saatte çakışmasını KESİNLİKLE yasakla
                schedulerControl2.OptionsCustomization.AllowAppointmentConflicts = AppointmentConflictsMode.Forbidden;
                // 1. MAPPING AYARLARI (Sadece bir kez yapılmalı)

                SetupMappings();

                // 2. VERİLERİ ASENKRON ÇEK (Aynı anda çekerek vakit kazanalım)
                var personnelTask = personnelRepo.GetAllAsync();
                var appointmentTask = appointmentRepo.GetAllAsync();

                // İkisinin de bitmesini bekle (Donma yapmaz)
                await Task.WhenAll(personnelTask, appointmentTask);

                // 3. LİSTELERİ DOLDUR
                personnelList = new BindingList<Personnel>(personnelTask.Result.ToList());
                appointmentList = new BindingList<Appointment>(appointmentTask.Result.ToList());

                // 4. DATA SOURCE BAĞLANTILARI
                schedulerDataStorage1.Resources.DataSource = personnelList;
                schedulerDataStorage1.Appointments.DataSource = appointmentList;

                // 5. GÖRÜNÜM AYARLARI
                schedulerControl2.Start = DateTime.Now;
                schedulerControl2.ActiveViewType = SchedulerViewType.Month;
                schedulerDataStorage1.RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                schedulerControl2.EndUpdate();
            }


        }


        private async void SchedulerDataStorage1_AppointmentsInserted(object sender, PersistentObjectsEventArgs e)
        {
            // Ekranda birden fazla randevu aynı anda eklenebilir, bu yüzden döngü kullanıyoruz
            foreach (DevExpress.XtraScheduler.Appointment apt in e.Objects)
            {

                // 1. İŞİN SIRRI BURADA: DevExpress'in arkada gizlice güncellediği asıl Entity nesnemizi yakalıyoruz!
                var sourceObj = apt.GetSourceObject(schedulerDataStorage1) as DXBeauty.Entities.Appointment;

                // Eğer nesneyi bulamazsa güvenlice devam etsin
                if (sourceObj == null) continue;
                // 1. DevExpress Appointment nesnesini, kendi Entity nesnemize çeviriyoruz
                var newEntity = new Appointment
                (
                    // * appointmentId (apt.Id obje döner. Yeni bir kayıt eklendiği için genelde null veya boş olabilir, 0 atıyoruz)
                    apt.Id != null ? Convert.ToInt32(apt.Id) : 0,

                    // 1. customerId (Özel CustomField eşleşmenden alıyoruz)
                    apt.CustomFields["CustomerId"] != null ? Convert.ToInt32(apt.CustomFields["CustomerId"]) : (int?)null,

                    // 2. customerServiceId (Özel CustomField eşleşmenden alıyoruz)
                    apt.CustomFields["CS_ID"] != null ? Convert.ToInt32(apt.CustomFields["CS_ID"]) : (int?)null,

                    // 3. appointmentStartDate
                    apt.Start,

                    // 4. createdAt (Yeni kayıt olduğu için şu anki zamanı veriyoruz)
                    DateTime.Now,

                    // 5. appointmentEndDate
                    apt.End,

                    // 6. type (DevExpress enum döner, nullable int'e çeviriyoruz)
                    (int)apt.Type,

                    // 7. subject
                    apt.Subject,

                    // 8. location
                    apt.Location,

                    // 9. description
                    apt.Description,

                    // 10. status (Eski 'Status' yerine DevExpress artık 'StatusKey' kullanıyor)
                    apt.StatusKey != null ? Convert.ToInt32(apt.StatusKey) : (int?)null,

                    // 11. reminderInfo (Hatırlatıcı bilgisi veritabanında XML string olarak tutulur. UI'dan almak biraz farklıdır)
                    sourceObj.ReminderInfo, // Hatırlatıcı bilgisini kaybetmemek için orijinal nesneden alıyoruz

                    // 12. recurrenceInfo (Eğer bu randevu tekrarlıyorsa XML'e çevirip kaydediyoruz)
                    sourceObj.RecurrenceInfo,

                    // 13. label (Eski 'Label' yerine DevExpress artık 'LabelKey' kullanıyor)
                    apt.LabelKey != null ? Convert.ToInt32(apt.LabelKey) : (int?)null,

                    // 14. resourceId (Personel ID)
                    apt.ResourceId != null && apt.ResourceId != ResourceEmpty.Id ? Convert.ToInt32(apt.ResourceId) : (int?)null,

                    // 15. allDay (Tüm gün mü?)
                    apt.AllDay,

                    // 16. serviceId (Artık formdan taşıdığımız Custom Field üzerinden okuyoruz!)
                    apt.CustomFields["ServiceId"] != null ? Convert.ToInt32(apt.CustomFields["ServiceId"]) : (int?)null
                );

                // 2. Repository üzerinden veritabanına kaydet
                int yeniKayitId = await appointmentRepo.AddAsync(newEntity);
                // 2. DevExpress'e bu yeni ID'yi zorla atıyoruz! (Sihirli Dokunuş)
                schedulerDataStorage1.SetAppointmentId(apt, yeniKayitId);
            }
        }

        private async void SchedulerDataStorage1_AppointmentsChanged(object sender, PersistentObjectsEventArgs e)
        {
            foreach (DevExpress.XtraScheduler.Appointment apt in e.Objects)
            {

                // 1. İŞİN SIRRI BURADA: DevExpress'in arkada gizlice güncellediği asıl Entity nesnemizi yakalıyoruz!
                var sourceObj = apt.GetSourceObject(schedulerDataStorage1) as DXBeauty.Entities.Appointment;

                // Eğer nesneyi bulamazsa güvenlice devam etsin
                if (sourceObj == null) continue;

                // 1. Güncellenen kaydın veritabanındaki ID'sini alıyoruz
                // Eğer ID null ise (yeni eklenmiş ama henüz veritabanından ID almamış bir kayıt olabilir), işlem yapma
                if (apt.Id == null || Convert.ToInt32(apt.Id) == 0) continue;

                int appointmentId = Convert.ToInt32(apt.Id);

                // 2. Formdan (veya sürükle-bırak ile) değişen GÜNCEL değerleri alıp Entity oluşturuyoruz.
                // Dikkat: Insert (Ekleme) koduyla birebir aynı, sadece ilk parametreye "0" değil, gerçek "appointmentId" veriyoruz.
                var updatedEntity = new DXBeauty.Entities.Appointment
                (
                    appointmentId,

                    apt.CustomFields["CustomerId"] != null ? Convert.ToInt32(apt.CustomFields["CustomerId"]) : (int?)null,
                    apt.CustomFields["CS_ID"] != null ? Convert.ToInt32(apt.CustomFields["CS_ID"]) : (int?)null,
                    apt.Start,

                    DateTime.Now, // Güncellenme tarihi olarak düşünebiliriz

                    apt.End,
                    (int)apt.Type,
                    apt.Subject,
                    apt.Location,
                    apt.Description,
                    apt.StatusKey != null ? Convert.ToInt32(apt.StatusKey) : (int?)null,
                    sourceObj.ReminderInfo, // Hatırlatıcı bilgisini kaybetmemek için orijinal nesneden alıyoruz
                    sourceObj.RecurrenceInfo,
                    apt.LabelKey != null ? Convert.ToInt32(apt.LabelKey) : (int?)null,
                    apt.ResourceId != null && apt.ResourceId != ResourceEmpty.Id ? Convert.ToInt32(apt.ResourceId) : (int?)null,
                    apt.AllDay,
                    apt.CustomFields["ServiceId"] != null ? Convert.ToInt32(apt.CustomFields["ServiceId"]) : (int?)null
                );

                // 3. Repository üzerinden veritabanında UPDATE işlemini yap
                await appointmentRepo.UpdateAsync(updatedEntity);
            }
        }

        private async void SchedulerDataStorage1_AppointmentsDeleted(object sender, PersistentObjectsEventArgs e)
        {
            foreach (DevExpress.XtraScheduler.Appointment apt in e.Objects)
            {
                if (apt.Id == null) continue;
                int id = Convert.ToInt32(apt.Id);
                await appointmentRepo.DeleteAsync(id);

                // 2. YETİM TEMİZLİĞİ (Sihirli Dokunuş)
                // Eğer silinen randevu bir Ana Şablon (Type 1 - Pattern) ise...
                if (apt.Type == DevExpress.XtraScheduler.AppointmentType.Pattern && apt.RecurrenceInfo != null)
                {
                    // Şablonun GUID kimliğini al
                    string patternGuid = apt.RecurrenceInfo.Id.ToString();

                    // Repository'e "Bu GUID'e sahip ne kadar istisna kopya varsa onları da sil" de!
                    await appointmentRepo.DeleteExceptionsAsync(patternGuid);
                }

            }

        }
        private void SchedulerControl2_AppointmentDrop(object sender, DevExpress.XtraScheduler.AppointmentDragEventArgs e)
        {
            // Kullanıcının randevuyu bırakmak (taşımak) istediği yeni tarih şu andan küçükse:
            if (e.EditedAppointment.Start < DateTime.Now)
            {
                XtraMessageBox.Show(
                    "Randevular geçmiş bir tarihe veya saate taşınamaz!",
                    "Geçersiz İşlem",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                e.Allow = false;   // Taşıma işlemini reddet
                
            }
        }

    }
}
