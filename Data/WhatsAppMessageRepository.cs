using DXBeauty.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXBeauty.Data
{
    public class WhatsAppMessageRepository : DapperRepository
    {
        public WhatsAppMessageRepository(string connectionString) : base(connectionString) { }

        public List<WhatsAppMessage> GetAll()
        {
            var sql = "SELECT * FROM whatsapp_messages ORDER BY sent_at DESC NULLS LAST";
            return Query<WhatsAppMessage>(sql).ToList();
        }

        public WhatsAppMessage GetById(int id)
        {
            var sql = "SELECT * FROM whatsapp_messages WHERE message_id = @Id";
            return Query<WhatsAppMessage>(sql, new { Id = id }).FirstOrDefault();
        }

        public void Insert(WhatsAppMessage message)
        {
            var sql = @"INSERT INTO whatsapp_messages 
                        (customer_id, appointment_id, message_text, status, sent_at)
                        VALUES (@CustomerId, @AppointmentId, @MessageText, @Status, @SentAt)";
            Execute(sql, message);
        }

        public void UpdateStatus(int id, string status)
        {
            var sql = @"UPDATE whatsapp_messages 
                        SET status = @Status, sent_at = NOW() 
                        WHERE message_id = @Id";
            Execute(sql, new { Id = id, Status = status });
        }

        public List<WhatsAppMessage> GetPendingMessages()
        {
            var sql = "SELECT * FROM whatsapp_messages WHERE status = 'pending'";
            return Query<WhatsAppMessage>(sql).ToList();
        }

        public void Delete(int id)
        {
            var sql = "DELETE FROM whatsapp_messages WHERE message_id = @Id";
            Execute(sql, new { Id = id });
        }
    }
}
