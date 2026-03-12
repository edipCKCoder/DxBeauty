using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXBeauty.Entities
{
    public class WhatsAppMessage
    {
        private int _messageId;
        private int _customerId;
        private int? _appointmentId;
        private string _messageText;
        private string _status;
        private DateTime? _sentAt;
        private int _messageType;
        public bool _isDelivered; // 1: Randevu Hatırlatma, 2: Paket Bilgilendirme, 3: Genel Duyuru

        public int MessageId
        {
            get => _messageId;
            private set => _messageId = value;
        }

        public int CustomerId
        {
            get => _customerId;
            set => _customerId = value;
        }

        public int? AppointmentId
        {
            get => _appointmentId;
            set => _appointmentId = value;
        }

        public string MessageText
        {
            get => _messageText;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Mesaj boş olamaz.");
                _messageText = value;
            }
        }
        public string Status
        {
            get => _status;
            set => _status = value ?? "pending";
        }

        public DateTime? SentAt
        {
            get => _sentAt;
            set => _sentAt = value;
        }

        public int MessageType
        {
            get => _messageType;
            set
            {
                _messageType = value;
            }
        }

            public bool IsDelivered
            {
                get => _isDelivered;
                set => _isDelivered = value;
        }

    }

}
