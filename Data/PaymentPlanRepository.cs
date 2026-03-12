using Dapper;
using DXBeauty.Dtos;
using DXBeauty.Entities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXBeauty.Data
{
    public class PaymentPlanRepository : DapperRepository
    {
        private readonly string _connectionString;
        public PaymentPlanRepository(string connectionString) : base(connectionString) 
        {
            _connectionString = connectionString;

        }



        public async Task<IEnumerable<FinancialReportDto>> GetFinancialReportAsync()
        {
            string sql = @"
        SELECT 
            c.customer_id AS CustomerId,
            c.first_name || ' ' || c.last_name AS FullName,
            c.phone_number AS Phone,
            
            -- Satırın ne borcu olduğunu anlatan o şık vitrin yazısı
            CASE 
                WHEN pp.plan_type = 1 THEN 'Peşinat'
                WHEN pp.plan_type = 3 THEN 'Açık Hesap'
                ELSE COALESCE(pp.sequence_number::text, '') || '. Taksit'
            END AS PlanDescription,
            
            sp.name AS PackageName,
            pp.due_date AS DueDate,
            pp.amount AS TotalAmount,
            COALESCE(pp.paid_amount, 0) AS PaidAmount,
            (pp.amount - COALESCE(pp.paid_amount, 0)) AS RemainingDebt,
            pp.is_paid AS IsPaid

        FROM payment_plans pp
        INNER JOIN customer_services cs ON pp.customer_service_id = cs.customer_service_id
        INNER JOIN service_packages sp ON cs.service_package_id = sp.service_package_id
        INNER JOIN customers c ON cs.customer_id = c.customer_id
        
        -- Ödenmişleri de, ödenmemişleri de getiriyoruz (Tam Rapor). 
        -- UI tarafında kullanıcı DevExpress'in filtreleriyle istediği gibi oynayabilir.
        ORDER BY pp.due_date ASC;";

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                return await connection.QueryAsync<FinancialReportDto>(sql);
            }
        }



    }
}
