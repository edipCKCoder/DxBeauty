using Dapper;
using DXBeauty.Entities;
using Npgsql;
using System.Threading.Tasks;

namespace DXBeauty.Data
{
    public class WhatsAppMessageRepository : DapperRepository
    {
        private readonly string _connectionString;
        public WhatsAppMessageRepository(string connectionString) : base(connectionString) 
        {
            _connectionString = connectionString;
        }

        // İŞTE EKSİK OLAN O EFSANEVİ LOGLAMA METODU!
        public async Task LogMessageAsync(WhatsAppMessage message)
        {
            string sql = @"
                INSERT INTO whatsapp_messages (customer_id, appointment_id, message_text, sent_at, message_type, is_delivered)
                VALUES (@CustomerId, @AppointmentId, @MessageText, @SentAt, @MessageType, @IsDelivered);";

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(sql, message);
            }
        }
    }
}