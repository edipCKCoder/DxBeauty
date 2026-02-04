using DXBeauty.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXBeauty.Data
{
    public class PaymentRepository : DapperRepository
    {
        public PaymentRepository(string connectionString) : base(connectionString) { }

        public List<Payment> GetAll()
        {
            var sql = "SELECT * FROM payments ORDER BY payment_date DESC";
            return Query<Payment>(sql).ToList();
        }

        public void Insert(Payment p)
        {
            var sql = @"INSERT INTO payments 
                        (customer_id, appointment_id, amount, payment_date, payment_method)
                        VALUES (@CustomerId, @AppointmentId, @Amount, @PaymentDate, @PaymentMethod)";
            Execute(sql, p);
        }

        public void Delete(int id)
        {
            var sql = "DELETE FROM payments WHERE payment_id = @Id";
            Execute(sql, new { Id = id });
        }
    }
}
