using DXBeauty.Entities;
using System.Collections.Generic;
using System.Linq;
using System;


namespace DXBeauty.Data
{
    public class CustomerServiceRepository : DapperRepository
    {
        public CustomerServiceRepository(string connectionString)
            : base(connectionString) { }

        public List<CustomerService> GetByCustomer(int customerId)
        {
            var sql = @"SELECT * 
                        FROM customer_services
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

        public void Insert(CustomerService cs)
        {
            var sql = @"INSERT INTO customer_services
                        (customer_id, service_package_id, start_date, remaining_sessions, total_price, status)
                        VALUES
                        (@CustomerId, @ServicePackageId, @StartDate, @RemainingSessions, @TotalPrice, @Status)";

            Execute(sql, cs);
        }

        public void Update(CustomerService cs)
        {
            var sql = @"UPDATE customer_services SET
                        remaining_sessions = @RemainingSessions,
                        status = @Status
                        WHERE customer_service_id = @CustomerServiceId";

            Execute(sql, cs);
        }

        public void Complete(int id)
        {
            var sql = @"UPDATE customer_services
                        SET status = 'completed'
                        WHERE customer_service_id = @CustomerServiceId";

            Execute(sql, new { CustomerServiceId = id });
        }

        public void Cancel(int id)
        {
            var sql = @"UPDATE customer_services
                        SET status = 'cancelled'
                        WHERE customer_service_id = @CustomerServiceId";

            Execute(sql, new { CustomerServiceId = id });
        }
    }
}
