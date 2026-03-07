using DXBeauty.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DXBeauty.Data
{
    public class ServicePackageRepository : DapperRepository
    {
        public ServicePackageRepository(string connectionString)
            : base(connectionString) { }


        public  List<ServicePackage> GetAll()
        {
            var sql = @"SELECT * 
                        FROM service_packages
                        ORDER BY name";

            return Query<ServicePackage>(sql).ToList();
        }
        public List<ServicePackage> GetByService(int serviceId)
        {
            var sql = @"SELECT * 
                        FROM service_packages
                        WHERE service_id = @ServiceId
                        ORDER BY name";

            return Query<ServicePackage>(sql, new { ServiceId = serviceId }).ToList();
        }

        public ServicePackage GetById(int id)
        {
            var sql = @"SELECT * 
                        FROM service_packages
                        WHERE service_package_id = @ServicePackageId";

            return QueryFirstOrDefault<ServicePackage>(sql, new { ServicePackageId = id });
        }

        public void Insert(ServicePackage p)
        {
            var sql = @"INSERT INTO service_packages
                        (service_id, name, session_count, total_price, is_installment_allowed, is_active)
                        VALUES
                        (@ServiceId, @Name, @SessionCount, @TotalPrice, @IsInstallmentAllowed, @IsActive)";

            Execute(sql, p);
        }

        public void Update(ServicePackage p)
        {
            var sql = @"UPDATE service_packages SET
                        name = @Name,
                        session_count = @SessionCount,
                        total_price = @TotalPrice,
                        is_installment_allowed = @IsInstallmentAllowed,
                        is_active = @IsActive
                        WHERE service_package_id = @ServicePackageId";

            Execute(sql, p);
        }

        public void Delete(int id)
        {
            // HARD DELETE yerine pasifleştiriyoruz (önerilen)
            var sql = @"UPDATE service_packages 
                        SET is_active = false
                        WHERE service_package_id = @ServicePackageId";

            Execute(sql, new { ServicePackageId = id });
        }
    }
}
