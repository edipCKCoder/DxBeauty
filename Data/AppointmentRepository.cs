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
                       (customer_id, service_id, appointment_date, duration_minutes, status)
                       VALUES (@CustomerId, @ServiceId, @AppointmentDate, @DurationMinutes, @Status)";
            Execute(sql, a);
        }

        public void Update(Appointment a)
        {
            var sql = @"UPDATE appointments SET
                        customer_id = @CustomerId,
                        service_id = @ServiceId,
                        appointment_date = @AppointmentDate,
                        duration_minutes = @DurationMinutes,
                        status = @Status
                        WHERE appointment_id = @AppointmentId";
            Execute(sql, a);
        }

        public void Delete(int id)
        {
            var sql = "DELETE FROM appointments WHERE appointment_id = @Id";
            Execute(sql, new { Id = id });
        }
    }
}
