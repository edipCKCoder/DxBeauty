using Dapper;
using DevExpress.XtraCharts.Designer.Native;
using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Localization;
using DevExpress.XtraScheduler.Xml;
using DXBeauty.Data;
using DXBeauty.Dtos;
using DXBeauty.Entities;
using DXBeauty.Enums;
using DXBeauty.Services;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
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
        private CustomerServiceRepository customerServiceRepo;
      
      
        public AppScheduler()
        {
            InitializeComponent();
            SchedulerLocalizer.Active = new TurkishSchedulerLocalizer();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            personnelRepo = new PersonnelRepository(connectionString);
            appointmentRepo = new AppointmentRepository(connectionString);
            customerServiceRepo = new CustomerServiceRepository(connectionString);

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

            // 1. DevExpress'in varsayılan statülerini temizle
            schedulerDataStorage1.Appointments.Statuses.Clear();

            // 2. Yardımcı metodumuzu Color yerine Brush alacak şekilde güncelliyoruz
            void AddAppointmentStatus(DXBeauty.Enums.AppointmentStatusType type, string name, string description, Brush brush)
            {
                // Dördüncü parametre olarak Brush isteyen overload'u (aşırı yüklemeyi) kullanıyoruz
                var status = schedulerDataStorage1.Appointments.Statuses.CreateNewStatus((int)type, name, description, brush);
                schedulerDataStorage1.Appointments.Statuses.Add(status);
            }

            // 3. Kendi net statülerimizi "Brushes" sınıfı ile ekliyoruz
            AddAppointmentStatus(DXBeauty.Enums.AppointmentStatusType.Planned, "Planlandı", "Müşteri Bekleniyor", Brushes.Orange);
            AddAppointmentStatus(DXBeauty.Enums.AppointmentStatusType.Completed, "Tamamlandı", "İşlem Başarıyla Bitti", Brushes.LimeGreen);
            AddAppointmentStatus(DXBeauty.Enums.AppointmentStatusType.Cancelled, "İptal (Haberli)", "Müşteri Haber Verdi", Brushes.Gray);
            AddAppointmentStatus(DXBeauty.Enums.AppointmentStatusType.NoShow, "Gelmedi (No-Show)", "Habersiz Gelmedi", Brushes.Red);

        }

        private void schedulerControl2_EditAppointmentFormShowing(object sender, AppointmentFormEventArgs e)
        {
            CustomAppointmentForm form = new CustomAppointmentForm(schedulerControl2, e.Appointment, e.OpenRecurrenceForm);
            form.ShowDialog();
            e.Handled = true; // DevExpress'in varsayılan formunu göstermesini engelle
        }

        private async void AppScheduler_Load(object sender, EventArgs e)
        {
       
            // Load metodunun içine ekle:
            schedulerDataStorage1.AppointmentInserting += SchedulerDataStorage1_AppointmentInserting;
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

      

  
        private void SchedulerDataStorage1_AppointmentInserting(object sender, PersistentObjectCancelEventArgs e)
        {
            DevExpress.XtraScheduler.Appointment apt = (DevExpress.XtraScheduler.Appointment)e.Object;

            // 1. Sadece paketli (seanslı) randevuları kontrol et. (Boş randevu veya toplantıysa karışma)
            if (apt.CustomFields["CS_ID"] == null || apt.CustomFields["CS_ID"] == DBNull.Value) return;

            int customerServiceId = Convert.ToInt32(apt.CustomFields["CS_ID"]);

            // 2. Müşterinin "Planlanabilir Seans" sayısını bul
            // (Burada veritabanından 'gercekKalanSeans'ı dapper ile çekip, az önce yazdığımız GetPlanlanabilirSeans metoduna vermelisin)
            int gercekKalanSeans = customerServiceRepo.GetRemainingSessions(customerServiceId); // Temsili veritabanı okuma metodun
            int planlanabilirSeans = GetPlanlanabilirSeans(customerServiceId, gercekKalanSeans);

            // 3. Kullanıcının eklemeye çalıştığı randevu kaç seans yiyecek?
            int harcanacakSeans = 1; // Eğer normal (tekli) bir randevuysa 1 seans harcar.

            // Eğer bu bir TEKRARLI RANDEVU şablonuysa (Type == Pattern)
            if (apt.IsRecurring && apt.Type == DevExpress.XtraScheduler.AppointmentType.Pattern)
            {
                // GÜVENLİK 1: Sonsuz Döngü Kontrolü
                if (apt.RecurrenceInfo.Range == DevExpress.XtraScheduler.RecurrenceRange.NoEndDate)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                        "Paketli (Seanslı) işlemlerde 'Bitiş Yok' (Sonsuz) tekrarlı randevu oluşturamazsınız!\nLütfen belirli bir tekrar sayısı veya bitiş tarihi seçin.",
                        "Hatalı Kural", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    e.Cancel = true; // İŞLEMİ İPTAL ET
                    return;
                }

                // GÜVENLİK 2: Gelecekte Kaç Randevu Doğuracağını Hesapla
                try
                {
                    DevExpress.XtraScheduler.OccurrenceCalculator calc = DevExpress.XtraScheduler.OccurrenceCalculator.CreateInstance(apt.RecurrenceInfo);

                    // Şablonun başlangıcından bitişine kadar olan zaman dilimini hesapla
                    DevExpress.XtraScheduler.TimeInterval interval = new DevExpress.XtraScheduler.TimeInterval(apt.RecurrenceInfo.Start, apt.RecurrenceInfo.End + TimeSpan.FromDays(1));

                    // Bu zaman diliminde kaç tane randevu oluşacağını say!
                    DevExpress.XtraScheduler.AppointmentBaseCollection occurrences = calc.CalcOccurrences(interval, apt);

                    harcanacakSeans = occurrences.Count;
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Tekrarlı randevu hesaplanırken bir sorun oluştu: " + ex.Message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }
            }

            // 4. FİNAL KONTROLÜ (OVERBOOKING ENGELLEME)
            if (harcanacakSeans > planlanabilirSeans)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    $"Yetersiz Seans!\n\nMüşterinin planlanabilir {planlanabilirSeans} seansı kalmış, ancak siz {harcanacakSeans} adet randevu oluşturmaya çalışıyorsunuz.\n\nLütfen tekrar sayısını azaltın.",
                    "Kapasite Aşımı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                e.Cancel = true; // Takvime eklenmesini FİZİKSEL OLARAK ENGELLER. Form açık kalır, müşteri hatasını düzeltir.
            }
        }

        public int GetPlanlanabilirSeans(int customerServiceId, int gercekKalanSeans)
        {
            var futureAppointments = schedulerDataStorage1.GetAppointments(DateTime.Now, DateTime.Now.AddYears(2));
            int gelecektekiPlanliRandevuSayisi = 0;

            foreach (var apt in futureAppointments)
            {
                int? aptCsId = apt.CustomFields["CS_ID"] != null ? Convert.ToInt32(apt.CustomFields["CS_ID"]) : (int?)null;
                int status = apt.StatusKey != null ? Convert.ToInt32(apt.StatusKey) : 0;

                if (aptCsId == customerServiceId && status == 1) // 1 = Planned
                {
                    gelecektekiPlanliRandevuSayisi++;
                }
            }

            int planlanabilirSeans = gercekKalanSeans - gelecektekiPlanliRandevuSayisi;
            return planlanabilirSeans < 0 ? 0 : planlanabilirSeans;
        }

        private void SchedulerControl2_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            // Sadece "Randevu" üzerine sağ tıklandığında menüye ekleme yap
            if (e.Menu.Id == DevExpress.XtraScheduler.SchedulerMenuItemId.AppointmentMenu)
            {
                // 1. Kendi "Tahsilat Al" butonumuzu oluşturuyoruz
                DevExpress.Utils.Menu.DXMenuItem tahsilatButonu = new DevExpress.Utils.Menu.DXMenuItem("Tahsilat Al");
                tahsilatButonu.ImageOptions.SvgImage = svgImageCollection1[4];
                // Üstüne şık bir çizgi (ayraç) koysun ki DevExpress'in kendi menüsünden ayrı dursun
                tahsilatButonu.BeginGroup = true;

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

                // 2. Butona Tıklanma (Click) Olayını Tanımlıyoruz
                tahsilatButonu.Click += (s, args) =>
                {
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

                // =========================================================
                // 2. YENİ WHATSAPP ALT MENÜSÜ (SUB-MENU)
                // =========================================================
                if (musteriId > 0 && randevuId.HasValue) // Müşterisi belli bir randevuysa WhatsApp menüsünü göster
                {

                    DevExpress.Utils.Menu.DXSubMenuItem whatsappMenu = new DevExpress.Utils.Menu.DXSubMenuItem("WhatsApp İle Bildir");
                    whatsappMenu.ImageOptions.SvgImage = Properties.Resources.GoToMessage;
                    whatsappMenu.BeginGroup = true;

                    // Alt Buton 1: Hatırlatma
                    DevExpress.Utils.Menu.DXMenuItem btnHatirlat = new DevExpress.Utils.Menu.DXMenuItem("Randevu Hatırlat");
                    btnHatirlat.ImageOptions.SvgImage = svgImageCollection1[0];
                    btnHatirlat.Click += async (s, args) => await SendWhatsAppFromCalendarAsync((int)musteriId, randevuId.Value, seciliRandevu, "REMINDER");

                    // Alt Buton 2: No-Show
                    DevExpress.Utils.Menu.DXMenuItem btnGelmedi = new DevExpress.Utils.Menu.DXMenuItem("Gelmedi (No-Show)");
                    btnGelmedi.ImageOptions.SvgImage = svgImageCollection1[2];
                    btnGelmedi.Click += async (s, args) => await SendWhatsAppFromCalendarAsync((int)musteriId, randevuId.Value, seciliRandevu, "NO_SHOW");

                    // Alt Buton 3: İptal
                    DevExpress.Utils.Menu.DXMenuItem btnIptal = new DevExpress.Utils.Menu.DXMenuItem("İptal Onayı Gönder");
                    btnIptal.ImageOptions.SvgImage = svgImageCollection1[3];
                    btnIptal.Click += async (s, args) => await SendWhatsAppFromCalendarAsync((int)musteriId, randevuId.Value, seciliRandevu, "CANCEL");

                    // Butonları Alt Menüye Ekle
                    whatsappMenu.Items.Add(btnHatirlat);
                    whatsappMenu.Items.Add(btnGelmedi);
                    whatsappMenu.Items.Add(btnIptal);

                    // Alt Menüyü Ana Menüye (Tahsilatın Altına) Ekle
                    e.Menu.Items.Insert(1, whatsappMenu);
                }
            }
        }
       

        private async Task SendWhatsAppFromCalendarAsync(int customerId, int appointmentId, DevExpress.XtraScheduler.Appointment apt, string templateCode)
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString)) // Kendi bağlantı cümleni yaz
                {
                    // 1. Müşterinin Adını ve Telefonunu Veritabanından Çek
                    string musteriSql = "SELECT first_name || ' ' || last_name AS fullname, phone_number AS phone FROM customers WHERE customer_id = @Id";
                    var musteri = await connection.QuerySingleOrDefaultAsync(musteriSql, new { Id = customerId });

                    if (musteri == null || string.IsNullOrWhiteSpace(musteri.phone))
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Bu müşterinin kayıtlı bir telefon numarası bulunamadı!", "Eksik Bilgi", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                        return;
                    }

                    // 2. İlgili Şablonu Veritabanından Çek (Örn: 'REMINDER')
                    string sablonSql = "SELECT template_content FROM message_templates WHERE template_code = @Code AND is_active = true LIMIT 1";
                    string sablonIcerik = await connection.QuerySingleOrDefaultAsync<string>(sablonSql, new { Code = templateCode });

                    if (string.IsNullOrWhiteSpace(sablonIcerik))
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Bu işlem için aktif bir mesaj şablonu bulunamadı. Lütfen ayarlardan şablonlarınızı kontrol edin.", "Şablon Bulunamadı", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                        return;
                    }

                    // 3. Şablonu Dinamik Verilerle Doldur (Hizmet adını Subject'ten veya DB'den alıyoruz)
                    WhatsAppService waService = new WhatsAppService(connectionString);
                    string hizmetAdi = apt.Subject; // Veya CustomFields["ServiceId"] üzerinden DB'den gerçek hizmet adını da çekebilirsin.

                    string hazirMesaj = waService.GenerateMessageFromTemplate(
                        templateContent: sablonIcerik,
                        customerName: musteri.fullname,
                        date: apt.Start,
                        serviceName: hizmetAdi
                    );

                    // 4. BUM! Mesajı Gönder ve Logla!
                    int messageType = 1; // Loglama için tip (Örn: 1 Hatırlatma, 4 No-Show)
                    if (templateCode == "NO_SHOW") messageType = 4;

                    await waService.SendMessageAsync(customerId, appointmentId, musteri.phone, hazirMesaj, messageType);
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("WhatsApp yönlendirmesi sırasında hata oluştu: " + ex.Message, "Hata", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
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
                    apt.AllDay = false,

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
                // 1. GÜVENLİK: Randevu ID'si yoksa hiç bulaşma
                if (apt.Id == null || Convert.ToInt32(apt.Id) == 0) continue;
                int appointmentId = Convert.ToInt32(apt.Id);

                // =========================================================================
                // KİLİT HAMLE 1: STATÜ GÜNCELLEMEYİ SOURCEOBJ KONTROLÜNDEN ÖNCE YAPIYORUZ!
                // Çünkü sağ tık menüsünde GetSourceObject anlık olarak null dönebilir.
                // =========================================================================
                int newStatus = (int)apt.StatusKey; // Enum'daki int değerini verir (1, 2, 3, 4)

                // Önce efsanevi seans düşme/iade etme metodunu çalıştırıp BİTMESİNİ BEKLİYORUZ (await)
                await appointmentRepo.UpdateAppointmentStatusAsync(appointmentId, newStatus);

                // 1. İŞİN SIRRI BURADA: DevExpress'in arkada gizlice güncellediği asıl Entity nesnemizi yakalıyoruz!
                var sourceObj = apt.GetSourceObject(schedulerDataStorage1) as DXBeauty.Entities.Appointment;

                // Eğer nesneyi bulamazsa güvenlice devam etsin
                if (sourceObj == null) continue;
       

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
                    apt.AllDay = false,
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
                // YENİ AKILLI SİLME METODUMUZU ÇAĞIRIYORUZ
                await appointmentRepo.DeleteAppointmentSafeAsync(id);

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


        public class TurkishSchedulerLocalizer : SchedulerLocalizer
        {
            public override string GetLocalizedString(SchedulerStringId id)
            {
                // 1. Sağ tık menüsündeki "Zaman Gösterimi" başlığı için:
                if (id == SchedulerStringId.MenuCmd_ShowTimeAs)
                {
                    return "Randevu Durumu";
                }
                if (id == SchedulerStringId.MenuCmd_LabelAs)
                {
                    return "Randevu Rengi";
                }
                if (id == SchedulerStringId.MenuCmd_NewAppointment)
                {
                    return "Yeni Randevu Oluştur";
                }

                return base.GetLocalizedString(id);
            }
        }
    }



}
