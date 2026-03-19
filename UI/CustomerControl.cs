using Dapper;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DXBeauty.Data;
using DXBeauty.Dtos;
using DXBeauty.Entities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

namespace DXBeauty.UI
{
    public partial class CustomerControl : DevExpress.XtraEditors.XtraUserControl
    {
        private readonly CustomerRepository repo;
        private readonly string connectionString;
        // Formun global değişkenleri (Üst kısım)
        private List<MessageTemplate> _ozelSablonlar = new List<MessageTemplate>();

        public CustomerControl()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            repo = new CustomerRepository(connectionString);

        }
        private async void CustomerControl_LoadAsync(object sender, EventArgs e)
        {

            var customers = repo.GetAll().ToList();
            customerGridControl.DataSource = customers;
            // Olayı (Event) koda elle bağlıyoruz
            repositoryItemButtonEdit1.ButtonClick += RepositoryItemButtonEdit1_ButtonClick;
           


            // Müşterinin kendi oluşturduğu (Özel) şablonları veritabanından çekip hafızaya alıyoruz
            using (var connection = new NpgsqlConnection(connectionString))
            {
                string sql = "SELECT template_content AS TemplateContent, template_name AS TemplateName FROM message_templates WHERE is_system = false AND is_active = true";
                _ozelSablonlar = (await connection.QueryAsync<MessageTemplate>(sql)).ToList();
            }
        }

        private void RepositoryItemButtonEdit1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            var seciliMusteri = gridViewMusteriler.GetFocusedRow() as Customer;
            if (seciliMusteri == null) return;

            // EĞER SİSTEMDE HİÇ ÖZEL ŞABLON VARSA, ALT MENÜYÜ OLUŞTUR
            if (_ozelSablonlar != null && _ozelSablonlar.Count > 0)
            {
                // 1. Ana Popup Menüsünü oluştur (Kapsayıcı) 
                DevExpress.Utils.Menu.DXPopupMenu anaMenu = new DevExpress.Utils.Menu.DXPopupMenu();

                DevExpress.Utils.Menu.DXSubMenuItem ozelMesajMenu = new DevExpress.Utils.Menu.DXSubMenuItem("💬 Özel Mesaj Gönder");
                ozelMesajMenu.BeginGroup = true; // Üstüne şık bir ayraç çizgisi koy

                // Hafızadaki özel şablonları tek tek alt menüye buton olarak ekle
                foreach (var sablon in _ozelSablonlar)
                {
                    DevExpress.Utils.Menu.DXMenuItem sablonButonu = new DevExpress.Utils.Menu.DXMenuItem("✨ " + sablon.TemplateName);

                    // Butona tıklandığında WhatsApp fırlatıcıyı çağır
                    sablonButonu.Click += async (s, args) =>
                    {
                        await SendCustomWhatsAppAsync(seciliMusteri, sablon.TemplateContent);
                    };

                    ozelMesajMenu.Items.Add(sablonButonu);
                }

                // 2. Alt menüyü ana popup menüsüne ekle ✅
                anaMenu.Items.Add(ozelMesajMenu);

                // 3. Menüyü FARE KOORDİNATLARINDA göster ❗
                // PointToClient: Ekran koordinatını Grid üzerindeki koordinata çevirir.
                anaMenu.ShowPopup(customerGridControl, customerGridControl.PointToClient(Control.MousePosition));
            }

        }
        

        private void NewRegister_Click(object sender, EventArgs e)
        {
            using (var popup = new XtraForm())
            {

                var registerControl = new CustomerRegisterControl
                {
                    Dock = DockStyle.Fill
                };


                registerControl.CustomerSaved += (customer) =>
                {
                    repo.Insert(customer);
                    customerGridControl.DataSource = repo.GetAll().ToList();
                    popup.Close();
                };
                popup.ClientSize = registerControl.Size;
                popup.StartPosition = FormStartPosition.CenterScreen;
                popup.Controls.Add(registerControl);
                popup.ShowDialog();
            }

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var customer = gridViewMusteriler.GetFocusedRow() as Customer;

            if (customer == null)
            {
                return;
            }
            var result = XtraMessageBox.Show(
                $"'{customer.FirstName} {customer.LastName}' silinsin mi?",
                "Onay",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            var repo = new CustomerRepository(connectionString);
            repo.Delete(customer.CustomerId);

            customerGridControl.DataSource = repo.GetAll().ToList();

        }

        private void editButton_Click(object sender, EventArgs e)
        {
            var customer = gridViewMusteriler.GetFocusedRow() as Customer;
            if (customer == null) return;

            var popup = new XtraForm();
            var registerControl = new CustomerRegisterControl();
            registerControl.Dock = DockStyle.Fill;

            registerControl.LoadCustomer(customer);

            registerControl.CustomerSaved += (updatedCustomer) =>
            {
                var repo = new CustomerRepository(connectionString);
                repo.Update(updatedCustomer);

                customerGridControl.DataSource = repo.GetAll().ToList(); // grid refresh
                popup.Close();
            };
            popup.ClientSize = registerControl.Size;
            popup.StartPosition = FormStartPosition.CenterScreen;
            popup.Controls.Add(registerControl);

            popup.ShowDialog();
        }

        private void gridViewMusteriler_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                // Sağ tıklanan müşteriyi yakala (DTO adın neyse ona göre değiştir, örn: CustomerDto)
                var seciliMusteri = gridViewMusteriler.GetRow(e.HitInfo.RowHandle) as Customer;

                if (seciliMusteri == null) return;

                // EĞER SİSTEMDE HİÇ ÖZEL ŞABLON VARSA, ALT MENÜYÜ OLUŞTUR
                if (_ozelSablonlar != null && _ozelSablonlar.Count > 0)
                {
                    DevExpress.Utils.Menu.DXSubMenuItem ozelMesajMenu = new DevExpress.Utils.Menu.DXSubMenuItem("💬 Özel Mesaj Gönder");
                    ozelMesajMenu.BeginGroup = true; // Üstüne şık bir ayraç çizgisi koy

                    // Hafızadaki özel şablonları tek tek alt menüye buton olarak ekle
                    foreach (var sablon in _ozelSablonlar)
                    {
                        DevExpress.Utils.Menu.DXMenuItem sablonButonu = new DevExpress.Utils.Menu.DXMenuItem("✨ " + sablon.TemplateName);

                        // Butona tıklandığında WhatsApp fırlatıcıyı çağır
                        sablonButonu.Click += async (s, args) =>
                        {
                            await SendCustomWhatsAppAsync(seciliMusteri, sablon.TemplateContent);
                        };

                        ozelMesajMenu.Items.Add(sablonButonu);
                    }

                    // Oluşturulan Alt Menüyü Ana Menüye Ekle
                    e.Menu.Items.Add(ozelMesajMenu);
                }
            }
        }

        private async Task SendCustomWhatsAppAsync(Customer musteri, string sablonIcerik)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(musteri.PhoneNumber)) // Müşteri DTO'ndaki telefon kolonunun adı
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Bu müşterinin telefon numarası eksik!", "Uyarı", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                    return;
                }

                DXBeauty.Services.WhatsAppService waService = new DXBeauty.Services.WhatsAppService(connectionString);

                // Dinamik şablonu doldur (Bu tür özel mesajlarda genelde sadece İsim kullanılır, tarih/tutar null geçilir)
                string hazirMesaj = waService.GenerateMessageFromTemplate(
                    templateContent: sablonIcerik,
                    customerName: musteri.FullName, // Müşteri DTO'ndaki İsim kolonunun adı
                    date: null,
                    serviceName: null,
                    amount: null,
                    packageName: null
                );

                // Alt satır (\n) düzeltmemiz
                hazirMesaj = hazirMesaj.Replace("\\n", "\n");

                // Gönder ve Logla! (MessageType = 3 olarak "Özel/Kampanya Mesajı" logluyoruz)
                await waService.SendMessageAsync(musteri.CustomerId, null, musteri.PhoneNumber, hazirMesaj, 3);
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Mesaj gönderilirken hata oluştu: " + ex.Message, "Hata", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
    }
}
