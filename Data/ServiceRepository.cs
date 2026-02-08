using DXBeauty.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXBeauty.Data
{
    public class ServiceRepository : DapperRepository
    {
        public ServiceRepository(string connectionString) : base(connectionString) { }

        public List<Service> GetAll()
        {
            var sql = "SELECT" +
                " service_id," +
                " name, " +
                " description," +
                " is_active AS " +
                " IsActive FROM services;";
            return Query<Service>(sql).ToList();
        }

        public Service GetById(int id)
        {
            var sql = "SELECT * FROM services WHERE service_id = @Id";
            return Query<Service>(sql, new { Id = id }).FirstOrDefault();
        }

        public void Insert(Service service)
        {
            var sql = @"INSERT INTO services (name, description, is_active )
                        VALUES (@Name, @Description, @IsActive)";
            Execute(sql, service);
        }

        public void Update(Service service)
        {
            var sql = @"UPDATE services 
                        SET name = @Name, 
                            description = @Description, 
                            isActive = @IsActive
                        WHERE service_id = @ServiceId";
            Execute(sql, service);
        }

        public void Delete(int id)
        {
            var sql = "DELETE FROM services WHERE service_id = @Id";
            Execute(sql, new { Id = id });
        }
    }
}
