using DevExpress.XtraEditors;
using DXBeauty.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DXBeauty.Dtos;
namespace DXBeauty.UI
{
    public partial class MessageTemplateControl : DevExpress.XtraEditors.XtraUserControl
    {
        private readonly MessageTemplateRepository _templateRepo;
        private int _currentTemplateId = 0; // 0 ise Yeni Kayıt, 0'dan büyükse Güncelleme
        private bool _isCurrentTemplateSystem = false;

        public MessageTemplateControl()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _templateRepo = new MessageTemplateRepository(connectionString);
        }


        private async void MessageTemplateControl_Load(object sender, EventArgs e)
        {
            // Grid'i sadece okunabilir yapıyoruz, düzenlemeler sağ panelden yapılacak
            gridViewTemplates.OptionsBehavior.Editable = false;

            await LoadTemplatesAsync();
        }

        // --- 1. VERİLERİ YÜKLEME ---
        private async Task LoadTemplatesAsync()
        {
            var templates = await _templateRepo.GetAllActiveAsync();
            gridTemplates.DataSource = templates;
            gridViewTemplates.BestFitColumns();
        }

        private void gridViewTemplates_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var selectedTemplate = gridViewTemplates.GetFocusedRow() as MessageTemplate;
            if (selectedTemplate == null) return;

            // Seçilen şablonun verilerini sağ panele aktar
            _currentTemplateId = selectedTemplate.TemplateId;
            _isCurrentTemplateSystem = selectedTemplate.IsSystem;

            txtName.Text = selectedTemplate.TemplateName;
            memoContent.Text = selectedTemplate.TemplateContent;

            // SİSTEM ŞABLONUYSA (Randevu Hatırlatma, No-Show vb.) KORUMAYA AL!
            if (selectedTemplate.IsSystem)
            {
                txtName.ReadOnly = true;        // Adını değiştiremez (Çünkü biz kodda 'REMINDER' diye arayacağız)
                btnDelete.Enabled = false;       // Silemez
                lblWarning.Text = "Bu bir sistem şablonudur. Sadece içeriğini düzenleyebilirsiniz.";
                
            }
            else // Müşterinin kendi oluşturduğu özel şablonsa (Örn: Kadınlar Günü)
            {
                txtName.ReadOnly = false;
                btnDelete.Enabled = true;
                lblWarning.Text = "";


            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            _currentTemplateId = 0; // Yeni kayıt moduna geç
            _isCurrentTemplateSystem = false;

            txtName.Text = "";
            memoContent.Text = "";

            txtName.ReadOnly = false;
            btnDelete.Enabled = false; // Ortada silinecek bir şey yok
            lblWarning.Visible = false;

            txtName.Focus();
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(memoContent.Text))
            {
                XtraMessageBox.Show("Lütfen şablon adı ve içeriğini boş bırakmayınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var template = new MessageTemplate
            {
                TemplateId = _currentTemplateId,
                TemplateName = txtName.Text.Trim(),
                TemplateContent = memoContent.Text.Trim()
            };

            try
            {
                if (_currentTemplateId == 0) // YENİ EKLE
                {
                    await _templateRepo.AddAsync(template);
                    XtraMessageBox.Show("Yeni şablon başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // GÜNCELLE
                {
                    await _templateRepo.UpdateAsync(template);
                    XtraMessageBox.Show("Şablon başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                await LoadTemplatesAsync(); // Listeyi yenile
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Kaydetme sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_currentTemplateId == 0 || _isCurrentTemplateSystem) return;

            var result = XtraMessageBox.Show("Bu özel şablonu silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    await _templateRepo.DeleteAsync(_currentTemplateId);
                    XtraMessageBox.Show("Şablon başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnNew_Click(null, null); // Ekranı temizle
                    await LoadTemplatesAsync(); // Listeyi yenile
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnInsertMusteriAdi_Click(object sender, EventArgs e) => InsertPlaceholder("{MusteriAdi}");
        private void btnInsertHizmetAdi_Click_1(object sender, EventArgs e) => InsertPlaceholder("{HizmetAdi}");
        private void btnInsertTarih_Click(object sender, EventArgs e) => InsertPlaceholder("{Tarih}");
        private void btnInsertSaat_Click_1(object sender, EventArgs e) => InsertPlaceholder("{Saat}");
        private void btnInsertTutar_Click(object sender, EventArgs e) => InsertPlaceholder("{Tutar}");
        private void btnInsertPaketAdi_Click(object sender, EventArgs e) => InsertPlaceholder("{PaketAdi}");



        private void InsertPlaceholder(string placeholder)
        {
            memoContent.Focus(); // İmleci MemoEdit'e al

            // Eğer müşteri içeride bir yazıyı seçip (tarayıp) butona basarsa, o yazıyı silip yerine etiket koyar.
            // Eğer hiçbir şey seçmediyse, sadece imlecin yanıp söndüğü yere etiketi şak diye yapıştırır!
            memoContent.SelectedText = placeholder;

            // İmleci yapıştırılan etiketin hemen sonuna al ki müşteri yazmaya devam edebilsin.
            memoContent.SelectionLength = 0;
        }
    }
}
