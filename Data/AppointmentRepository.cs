using Dapper;
using DXBeauty.Entities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXBeauty.Data
{
    public class AppointmentRepository : DapperRepository
    {

        private readonly string _connectionString;

        public AppointmentRepository(string connectionString) : base(connectionString)
        {

            _connectionString = connectionString;
            

        }
        private IDbConnection CreateConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }

        // Tümü Listele
        public async Task<IEnumerable<Appointment>> GetAllAsync()
        {
            using (var db = CreateConnection())
            {
                string sql = "SELECT * FROM appointments";
                return await db.QueryAsync<Appointment>(sql);
            }
        }

        // ID'ye Göre Getir
        public async Task<Appointment> GetByIdAsync(int appointmentId)
        {
            using (var db = CreateConnection())
            {
                string sql = "SELECT * FROM appointments WHERE appointment_id = @AppointmentId";
                return await db.QueryFirstOrDefaultAsync<Appointment>(sql, new { AppointmentId = appointmentId });
            }
        }

        // Yeni Kayıt Ekle (Eklenen ID'yi geri döner)
        public async Task<int> AddAsync(Appointment appointment)
        {
            using (var db = CreateConnection())
            {
                string sql = @"
                INSERT INTO appointments (
                    customer_service_id, customer_id, appointment_start_date,
                    created_at,
                    appointment_end_date,
                    type, subject, location, description, 
                    status, reminder_info, recurrence_info, label, resource_id, all_day, service_id
                ) 
                VALUES (
                    @CustomerServiceId, @CustomerId, @AppointmentStartDate,
                    @CreatedAt,
                    @AppointmentEndDate, @Type, @Subject, @Location, @Description, 
                    @Status, @ReminderInfo, @RecurrenceInfo, @Label, @ResourceId, @AllDay, @ServiceId
                ) 
                RETURNING appointment_id;"; // PostgreSQL'de ID böyle geri alınır

                return await db.ExecuteScalarAsync<int>(sql, appointment);
            }
        }

        // Kayıt Güncelle
        public async Task<bool> UpdateAsync(Appointment appointment)
        {
            using (var db = CreateConnection())
            {
                string sql = @"
                UPDATE appointments SET 
                    customer_service_id = @CustomerServiceId, 
                    customer_id = @CustomerId,
                    appointment_start_date = @AppointmentStartDate, 
                    created_at = @CreatedAt,
                    appointment_end_date = @AppointmentEndDate, 
                    type = @Type, 
                    subject = @Subject, 
                    location = @Location, 
                    description = @Description, 
                    status = @Status, 
                    reminder_info = @ReminderInfo, 
                    recurrence_info = @RecurrenceInfo, 
                    label = @Label, 
                    resource_id = @ResourceId, 
                    all_day = @AllDay,
                    service_id = @ServiceId
                WHERE appointment_id = @AppointmentId;";

                var affectedRows = await db.ExecuteAsync(sql, appointment);
                return affectedRows > 0;
            }
        }

        // Kayıt Sil
        public async Task<bool> DeleteAsync(int appointmentId)
        {
            using (var db = CreateConnection())
            {
                string sql = "DELETE FROM appointments WHERE appointment_id = @AppointmentId";
                var affectedRows = await db.ExecuteAsync(sql, new { AppointmentId = appointmentId });
                return affectedRows > 0;
            }
        }


        // Ana şablon silindiğinde ona bağlı "Yetim" kopyaları siler
        public async Task DeleteExceptionsAsync(string patternGuid)
        {

            using (var db = CreateConnection())
            {
                // recurrence_info kolonunda bu GUID geçen ve Type'ı 3 veya 4 olan kayıtları bul ve sil
                string sql = @"DELETE FROM appointments 
                   WHERE type IN (3, 4) 
                   AND recurrence_info LIKE '%' || @Guid || '%'";

                await db.ExecuteAsync(sql, new { Guid = patternGuid });
            }

        }
    }
}
