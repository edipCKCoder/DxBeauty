using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXBeauty.Dtos
{
    public class CustomerDebtDto
    {
        [DisplayName("Borç Tipi")] // Grid'de bu isim görünür 
        public string DebtType { get; set; } // "Paket Taksidi" veya "Tek Seans"
        [DisplayName("Açıklama")] 
        public string Description { get; set; } // Örn: "Lazer Epilasyon - 1. Taksit"
        [DisplayName("Vade Tarihi")] 
        public DateTime DueDate { get; set; } // Son Ödeme Tarihi
        [DisplayName("Tutar")] 
        public decimal Amount { get; set; } // Tutar

        // Arka planda tutacağımız (Kullanıcının görmeyeceği) gizli ID'ler
        public int? PaymentPlanId { get; set; }
        public int? CustomerServiceId { get; set; }
        public int? AppointmentId { get; set; }
    }
}
