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
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 1. YENİ RANDEVUYU VERİTABANINA EKLE
                        string insertSql = @"
                    INSERT INTO appointments (
                        customer_id, customer_service_id, appointment_start_date, created_at, 
                        appointment_end_date, type, subject, location, description, status, 
                        reminder_info, recurrence_info, label, resource_id, all_day, service_id
                    ) 
                    VALUES (
                        @CustomerId, @CustomerServiceId, @AppointmentStartDate, @CreatedAt, 
                        @AppointmentEndDate, @Type, @Subject, @Location, @Description, @Status, 
                        @ReminderInfo, @RecurrenceInfo, @Label, @ResourceId, @AllDay, @ServiceId
                    ) 
                    RETURNING appointment_id;";

                        // Nesnemizdeki özellikleri Dapper ile veritabanına yollayıp oluşan ID'yi alıyoruz
                        int newAppointmentId = await connection.ExecuteScalarAsync<int>(insertSql, appointment, transaction);

                        // 2. İŞTE O SİHİRLİ KONTROL: DOĞUŞTAN SEANS YAKAN (Status = 2 veya 4) RANDEVU MU?
                        // Not: Senin Entity sınıfındaki property isimleri farklıysa (Örn: customerServiceId, status) onlara göre düzelt.
                        if (appointment.CustomerServiceId.HasValue && (appointment.Status == 2 || appointment.Status == 4))
                        {
                            // Randevu 4 (Gelmedi) veya 2 (Tamamlandı) olarak doğdu, anında paketinden 1 seans düş!
                            string decSql = "UPDATE customer_services SET remaining_sessions = remaining_sessions - 1 WHERE customer_service_id = @CsId";
                            await connection.ExecuteAsync(decSql, new { CsId = appointment.CustomerServiceId.Value }, transaction);
                        }

                        // Her şey başarılıysa onayla!
                        transaction.Commit();

                        return newAppointmentId; // DevExpress'e atamak üzere ID'yi UI'a geri döndür
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Randevu eklenirken hata oluştu: " + ex.Message);
                    }
                }
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

        public async Task UpdateAppointmentStatusAsync(int appointmentId, int newStatus)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 1. Önce Randevunun MEVCUT durumunu ve Paket ID'sini öğrenelim
                        string getAppSql = "SELECT status, customer_service_id FROM appointments WHERE appointment_id = @Id";
                        var app = await connection.QuerySingleOrDefaultAsync(getAppSql, new { Id = appointmentId }, transaction);

                        if (app == null) return;

                        int oldStatus = app.status ?? 0;
                        int? customerServiceId = app.customer_service_id;

                        // 2. Sadece paketten düşülecek bir randevuysa (Tek seans/Paketsiz değilse) seans hesabı yap
                        if (customerServiceId.HasValue && oldStatus != newStatus)
                        {
                            // Hangi durumlar seans yakar? (2: Completed, 4: NoShow)
                            bool wasConsumed = (oldStatus == 2 || oldStatus == 4);
                            bool willBeConsumed = (newStatus == 2 || newStatus == 4);

                            // planned/Cannelled -> Completed/NoShow (SEANS DÜŞ)
                            if (!wasConsumed && willBeConsumed)
                            {
                                // SENARYO A: Normalden -> Tamamlandı/NoShow'a geçti (SEANS DÜŞ)
                                string decSql = "UPDATE customer_services SET remaining_sessions = remaining_sessions - 1 WHERE customer_service_id = @CsId";
                                await connection.ExecuteAsync(decSql, new { CsId = customerServiceId.Value }, transaction);
                            }
                            // Completed/NoShow -> planned/Cannelled (SEANS İADE ET)
                            else if (wasConsumed && !willBeConsumed)
                            {
                                // SENARYO B: Veznedar hata yaptı! Tamamlandı'dan -> Planlandı/İptal'e geri çekti (SEANS İADE ET)
                                string incSql = "UPDATE customer_services SET remaining_sessions = remaining_sessions + 1 WHERE customer_service_id = @CsId";
                                await connection.ExecuteAsync(incSql, new { CsId = customerServiceId.Value }, transaction);
                            }
                            // Not: Eğer Tamamlandı(2)'den NoShow(4)'a geçerse her iki taraf da "consumed" olduğu için if'lere girmez, seans sayısı bozulmaz! Kusursuz!
                        }

                        // 3. Son olarak randevunun kendi statüsünü güncelle
                        string updateAppSql = "UPDATE appointments SET status = @NewStatus WHERE appointment_id = @Id";
                        await connection.ExecuteAsync(updateAppSql, new { NewStatus = newStatus, Id = appointmentId }, transaction);

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Statü güncellenirken kritik bir hata oluştu: " + ex.Message);
                    }
                }
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

        public async Task DeleteAppointmentSafeAsync(int appointmentId)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 1. SİLMEDEN ÖNCE: Randevunun mevcut durumunu ve Paketini öğren
                        string getAppSql = "SELECT status, customer_service_id FROM appointments WHERE appointment_id = @Id";
                        var app = await connection.QuerySingleOrDefaultAsync(getAppSql, new { Id = appointmentId }, transaction);

                        if (app != null)
                        {
                            int status = app.status ?? 0;
                            int? customerServiceId = app.customer_service_id;

                            // 2. EĞER BU RANDEVU SEANS YAKMIŞ BİR RANDEVUYSA (2 veya 4) İADE ET!
                            if (customerServiceId.HasValue && (status == 2 || status == 4))
                            {
                                string restoreSql = "UPDATE customer_services SET remaining_sessions = remaining_sessions + 1 WHERE customer_service_id = @CsId";
                                await connection.ExecuteAsync(restoreSql, new { CsId = customerServiceId.Value }, transaction);
                            }

                            // 3. İade işlemi bittiyse (veya zaten seans yakmamış bir randevuysa) artık güvenle silebilirsin.
                            string delSql = "DELETE FROM appointments WHERE appointment_id = @Id";
                            await connection.ExecuteAsync(delSql, new { Id = appointmentId }, transaction);
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Randevu silinirken bir hata oluştu ve işlem geri alındı: " + ex.Message);
                    }
                }
            }
        }     

    }
}
