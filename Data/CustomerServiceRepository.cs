using Dapper;
using DXBeauty.Dtos;
using DXBeauty.Entities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DXBeauty.Data
{
    public class CustomerServiceRepository : DapperRepository
    {
        private readonly string _connectionString;

        public CustomerServiceRepository(string connectionString)
            : base(connectionString) 
        {
            _connectionString = connectionString;
        }

        //get remaing sessions

        public int GetRemainingSessions(int customerServiceId)
        {
            string sql = "SELECT remaining_sessions FROM customer_services WHERE customer_service_id = @CustomerServiceId";
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<int>(sql, new { CustomerServiceId = customerServiceId });
            }
        }

        public async Task<IEnumerable<CustomerServiceLookupDto>> GetCustomerActivePackagesAsync(int customerId)
        {
            // Efsanevi Blokaj Sorgumuz: (Kalan Seans - Takvimdeki Planlanmış Randevular)
            string sql = @"
        SELECT 
            cs.customer_service_id AS CustomerServiceId,
            sp.name AS PackageName,
            cs.remaining_sessions AS RemainingSessions,
            
            -- İşte Boşta olan seansı anında hesaplayan o matematik:
            (cs.remaining_sessions - (
                SELECT COUNT(*) 
                FROM appointments a 
                WHERE a.customer_service_id = cs.customer_service_id 
                  AND a.status IN (0, 1) -- 0: None(Bekliyor), 1: Planned(Planlandı)
            )) AS AvailableSessions

        FROM customer_services cs
        INNER JOIN service_packages sp ON cs.service_package_id = sp.service_package_id
        WHERE cs.customer_id = @CustomerId 
          AND cs.remaining_sessions > 0;  --Sadece seansı bitmemiş paketleri getir";

        using (var connection = new NpgsqlConnection(_connectionString))
            {
                return await connection.QueryAsync<CustomerServiceLookupDto>(sql, new { CustomerId = customerId });
            }
        }


        public List<CustomerService> GetAll() 
        {
            var sql = @"SELECT * FROM public.customer_services
                        JOIN public.service_packages 
                        ON public.customer_services.service_package_id = public.service_packages.service_package_id
                        ORDER BY start_date DESC";

            return Query<CustomerService>(sql).ToList();
        } 

        public List<CustomerService> GetByCustomer(int customerId)
        {
            var sql = @"SELECT * FROM public.customer_services
                        JOIN public.service_packages 
                        ON public.customer_services.service_package_id = public.service_packages.service_package_id
                        WHERE customer_id = @CustomerId
                        ORDER BY start_date DESC";

            return Query<CustomerService>(sql, new { CustomerId = customerId }).ToList();
        }

        public CustomerService GetById(int id)
        {
            var sql = @"SELECT * 
                        FROM customer_services
                        WHERE customer_service_id = @CustomerServiceId";

            return QueryFirstOrDefault<CustomerService>(sql, new { CustomerServiceId = id });
        }

        public int Insert(CustomerService cs)
        {
            var sql = @"INSERT INTO customer_services
                (customer_id, service_package_id, start_date, remaining_sessions, total_price, remaining_debt, paid_amount, status)
                VALUES
                (@CustomerId, @ServicePackageId, @StartDate, @RemainingSessions, @TotalPrice, @RemainingDebt, 0, @Status)
                RETURNING customer_service_id;";

            // Dapper'ın QuerySingle metodunu kullanarak PostgreSQL'in ürettiği ID'yi geri alıyoruz
            return Query<int>(sql, cs).Single();
        }

        public void Update(CustomerService cs)
        {
            var sql = @"UPDATE customer_services SET
                        remaining_sessions = @RemainingSessions,
                        status = @Status,
                        is_visible = @IsVisible
                        WHERE customer_service_id = @CustomerServiceId";

            Execute(sql, cs);
        }

        
    }
}
