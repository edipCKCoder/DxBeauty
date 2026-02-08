using System;
using System.Collections.Generic;
using System.Linq;
using DXBeauty.Entities;
using System.Text;
using System.Threading.Tasks;

namespace DXBeauty.Data
{
    public class AppointmentRepository : DapperRepository
    {
        public AppointmentRepository(string connectionString) : base(connectionString) { }

        public List<Appointment> GetAll()
        {
            var sql = "SELECT * FROM appointments ORDER BY appointment_date DESC";
            return Query<Appointment>(sql).ToList();
        }

        public void Insert(Appointment a)
        {
            var sql = @"INSERT INTO appointments 
                       (customer_service_id, appointment_date, duration_minutes, status, notes,created_at)
                       VALUES (@CustomerServiceId, @AppointmentDate, @DurationMinutes, @Status, @Notes,@CreatedAt)";
            Execute(sql, a);
        }

        public void Update(Appointment a)
        {
            var sql = @"UPDATE appointments SET
                        customer_service_id = @CustomerServiceId,
                        appointment_date = @AppointmentDate,
                        duration_minutes = @DurationMinutes,
                        status = @Status,
                        notes = @Notes
                        WHERE appointment_id = @AppointmentId";
            Execute(sql, a);
        }

        public void Delete(int id)
        {
            var sql = "DELETE FROM appointments WHERE appointment_id = @AppointmentId";
            Execute(sql, new { AppointmentId = id });
        }
    }
}
