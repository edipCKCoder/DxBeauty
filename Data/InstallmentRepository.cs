using DXBeauty.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXBeauty.Data
{
    public class InstallmentRepository : DapperRepository
    {
        public InstallmentRepository(string connectionString) : base(connectionString) { }

        public void InsertInstallments(List<Installment> installments)
        {
            var sql = @"INSERT INTO installments 
                        (customer_service_id, installment_number, amount, due_date, is_paid, paid_amount)
                        VALUES 
                        (@CustomerServiceId, @InstallmentNumber, @Amount, @DueDate, false, 0);";

            // Dapper'a bir liste verirsek, foreach yazmadan tüm listeyi tek seferde veritabanına basar!
            Execute(sql, installments);
        }
    }
}
