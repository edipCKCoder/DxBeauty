using DXBeauty.Data;
using DXBeauty.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DXBeauty.Services
{
    
    public class WhatsAppService
    {
        private readonly WhatsAppMessageRepository _repository;

        public WhatsAppService(string connectionString)
        {
            _repository = new WhatsAppMessageRepository(connectionString);
        }

        // --- 1. ŞABLON ÜRETİCİLERİ ---
        public string GenerateMessageFromTemplate(string templateContent, string customerName, DateTime? date = null, string serviceName = "", decimal? amount = null, string packageName = "")
        {
            string message = templateContent;

            // Her zaman var olan değişkenler
            message = message.Replace("{MusteriAdi}", customerName ?? "");

            // Tarih/Saat varsa değiştir
            if (date.HasValue)
            {
                message = message.Replace("{Tarih}", date.Value.ToString("dd.MM.yyyy"));
                message = message.Replace("{Saat}", date.Value.ToString("HH:mm"));
            }

            // Hizmet/Paket/Tutar varsa değiştir
            message = message.Replace("{HizmetAdi}", serviceName ?? "");
            message = message.Replace("{PaketAdi}", packageName ?? "");
            message = message.Replace("{Tutar}", amount.HasValue ? amount.Value.ToString("N2") : "");

            message = message.Replace("\\n", "\n");
            return message;
        }

        //public string GenerateAppointmentReminder(string customerName, string serviceName, DateTime appointmentDate)
        //{
        //    // Örn: "Merhaba Ayşe Yılmaz, 12.03.2026 saat 14:00'te Lazer Epilasyon randevunuz bulunmaktadır..."
        //    return $"Merhaba {customerName},\n\n" +
        //           $"{appointmentDate:dd.MM.yyyy} tarihinde saat {appointmentDate:HH:mm}'te " +
        //           $"{serviceName} randevunuz bulunmaktadır. Lütfen katılım durumunuzu bize bildiriniz.\n\n" +
        //           $"Sağlıklı ve güzellik dolu günler dileriz.";
        //}

        //public string GenerateDebtReminder(string customerName, decimal amount, string packageName)
        //{
        //    return $"Merhaba {customerName},\n\n" +
        //           $"{packageName} paketinize ait {amount:N2} TL tutarındaki ödemenizin zamanı gelmiştir/yaklaşmıştır. " +
        //           $"Ödeme yaptıysanız bu mesajı dikkate almayınız.\n\nİyi günler dileriz.";
        //}
        ////Müşteri masadan kalkıp paketi satın aldığında atılacak güven verici mesaj.
        //public string GenerateNewPackageMessage(string customerName, string packageName, int sessionCount)
        //{
        //    return $"Merhaba {customerName} Hanım/Bey,\n\n" +
        //           $"Güzellik merkezimizi tercih ettiğiniz için teşekkür ederiz. " +
        //           $"{sessionCount} seanslık '{packageName}' paketiniz hesabınıza başarıyla tanımlanmıştır.\n\n" +
        //           $"İlk seansınızda görüşmek dileğiyle, ışıltılı günler dileriz! ✨";
        //}
        ////Müşteri arayıp "Gelemeyeceğim" dediğinde, randevunun iptal edildiğini teyit eden resmi mesaj.
        //public string GenerateCancellationMessage(string customerName, DateTime appointmentDate, string serviceName)
        //{
        //    return $"Sayın {customerName},\n\n" +
        //           $"{appointmentDate:dd.MM.yyyy} - {appointmentDate:HH:mm} tarihindeki {serviceName} randevunuz " +
        //           $"talebiniz üzerine iptal edilmiştir. Yeni bir randevu oluşturmak isterseniz bizimle iletişime geçebilirsiniz.\n\n" +
        //           $"İyi günler dileriz.";
        //}

        ////Randevuya gelmeyen müşteriye, seansının yandığını veya durumun fark edildiğini kibarca bildiren mesaj.
        //public string GenerateNoShowMessage(string customerName, DateTime appointmentDate)
        //{
        //    return $"Merhaba {customerName},\n\n" +
        //           $"Bugün saat {appointmentDate:HH:mm}'teki randevunuza katılım sağlamadığınızı görüntülüyoruz. " +
        //           $"Planlamalarımızda aksaklık yaşamamak adına, bir sonraki randevularınızda değişiklik olması durumunda " +
        //           $"bize önceden bilgi vermenizi rica ederiz.\n\n" +
        //           $"Sağlıklı günler dileriz.";
        //}


        ////Müşteri Lazer veya Cilt Bakımından çıktıktan (Statüsü Tamamlandı olduktan) hemen sonra atılabilecek bilgilendirme mesajı.
        //public string GeneratePostCareMessage(string customerName, string serviceName)
        //{
        //    return $"Merhaba {customerName},\n\n" +
        //           $"Umarız bugünkü {serviceName} işleminizden memnun kalmışsınızdır. 🌸\n" +
        //           $"İşlem sonrası cildinizi korumak için 24 saat boyunca sıcak sudan kaçınmanızı ve " +
        //           $"güneş kreminizi düzenli kullanmanızı hatırlatmak isteriz.\n\n" +
        //           $"Bir sonraki seansınızda görüşmek üzere!";
        //}

        ////. Doğum Günü Kutlaması (Pazarlama)
        //public string GenerateBirthdayMessage(string customerName)
        //{
        //    return $"İyi ki doğdunuz {customerName}! 🎂\n\n" +
        //           $"Yeni yaşınızda da güzelliğinize güzellik katmak için yanınızdayız. " +
        //           $"Doğum gününüze özel bu hafta yapacağınız tüm işlemlerde %15 indiriminiz tanımlanmıştır.\n\n" +
        //           $"Mutlu yıllar dileriz! 🎁";
        //}

        // --- 2. GÖNDERİM VE LOGLAMA MOTORU ---

        public async Task SendMessageAsync(int customerId, int? appointmentId, string phoneNumber, string message, int messageType)
        {
            // 1. Telefon Numarasını WhatsApp Formatına Çevir
            string cleanNumber = CleanPhoneNumber(phoneNumber);
            if (string.IsNullOrEmpty(cleanNumber))
                throw new Exception("Geçersiz telefon numarası formatı!");

            // 2. WhatsApp URL'sini Oluştur (Metni internet diline - URL Encode - çevirmeliyiz)
            string urlEncodedMessage = Uri.EscapeDataString(message);
            string whatsappUrl = $"https://wa.me/{cleanNumber}?text={urlEncodedMessage}";

            try
            {
                // 3. Bilgisayardaki Varsayılan Tarayıcıyı veya WhatsApp Uygulamasını Aç
                Process.Start(new ProcessStartInfo
                {
                    FileName = whatsappUrl,
                    UseShellExecute = true // Modern C# (Core/5+) sürümlerinde URL açmak için şarttır!
                });

                // 4. Veritabanına Log At! (Asistan görevini yaptı)
                var log = new WhatsAppMessage
                {
                    CustomerId = customerId,
                    AppointmentId = appointmentId,
                    MessageText = message,
                    SentAt = DateTime.Now,
                    MessageType = messageType,
                    IsDelivered = true
                };
                await _repository.LogMessageAsync(log);
            }
            catch (Exception ex)
            {
                throw new Exception("WhatsApp başlatılamadı veya loglanamadı: " + ex.Message);
            }
        }

        // --- YARDIMCI METOT ---
        private string CleanPhoneNumber(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return string.Empty;

            // İçindeki boşluk, tire, parantez gibi gereksiz karakterleri at (Regex ile sadece rakamlar kalır)
            string numericPhone = Regex.Replace(phone, "[^0-9]", "");

            // Türkiye numarası ise (Örn: 0532 veya 532 ile başlıyorsa) WhatsApp'ın sevdiği "905" formatına getir
            if (numericPhone.StartsWith("05") && numericPhone.Length == 11)
            {
                return "90" + numericPhone.Substring(1); // 90532...
            }
            if (numericPhone.StartsWith("5") && numericPhone.Length == 10)
            {
                return "90" + numericPhone; // 90532...
            }

            // Zaten +90 veya 90 ile yazılmışsa
            return numericPhone;
        }
    }
}
