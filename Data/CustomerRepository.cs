using DXBeauty.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXBeauty.Data
{
    public class CustomerRepository : DapperRepository
    {
        private readonly string _connectionString;
        public CustomerRepository(string connectionString) : base(connectionString) 
        {
            _connectionString = connectionString;
        }

        public List<Customer> GetAll()
        {
            var sql = "SELECT * FROM customers ORDER BY customer_id DESC";
            return Query<Customer>(sql).ToList();
        }

        public Customer GetById(int id)
        {
            var sql = "SELECT * FROM customers WHERE customer_id = @Id";
            return Query<Customer>(sql, new { Id = id }).FirstOrDefault();
        }

        public void Insert(Customer customer)
        {
            var sql = @"INSERT INTO customers (first_name, last_name, phone_number, email, address,birthday)
                        VALUES (@FirstName, @LastName, @PhoneNumber, @Email, @Address, @Birthday)";
            Execute(sql, customer);
        }

        public void Update(Customer customer)
        {
            var sql = @"UPDATE customers SET 
                        first_name = @FirstName, 
                        last_name = @LastName, 
                        phone_number = @PhoneNumber, 
                        email = @Email,
                        address = @Address,
                        birthday = @Birthday
                        WHERE customer_id = @CustomerId";
            Execute(sql, customer);
        }

        public void Delete(int id)
        {
            var sql = "DELETE FROM customers WHERE customer_id = @Id";
            Execute(sql, new { Id = id });
        }
    }
}
