using Dapper;
using DXBeauty.Entities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXBeauty.Data
{
    public class PersonnelRepository
    {
        private readonly string _connectionString;

        public PersonnelRepository(string connectionString)
        {
            _connectionString = connectionString;
           
        }

        private IDbConnection CreateConnection() => new NpgsqlConnection(_connectionString);

        // Sadece aktif personelleri getir (Takvimde görünmesi için genelde bu kullanılır)
        public async Task<IEnumerable<Personnel>> GetActivePersonnelsAsync()
        {
            using (var db = CreateConnection())
            {
                string sql = "SELECT * FROM personnels WHERE is_active = true ORDER BY full_name ASC";
                return await db.QueryAsync<Personnel>(sql);
            }
        }

        public async Task<IEnumerable<Personnel>> GetAllAsync()
        {
            using (var db = CreateConnection())
            {
                string sql = "SELECT * FROM personnels ORDER BY full_name ASC";
                return await db.QueryAsync<Personnel>(sql);
            }
        }

        public async Task<int> AddAsync(Personnel personnel)
        {
            using (var db = CreateConnection())
            {
                string sql = @"
                INSERT INTO personnels (full_name, color_id, is_active, phone_number) 
                VALUES (@FullName, @ColorId, @IsActive, @PhoneNumber) 
                RETURNING personnel_id;";

                return await db.ExecuteScalarAsync<int>(sql, personnel);
            }
        }

        public async Task<bool> UpdateAsync(Personnel personnel)
        {
            using (var db = CreateConnection())
            {
                string sql = @"
                UPDATE personnels SET 
                    full_name = @FullName, 
                    color_id = @ColorId, 
                    is_active = @IsActive, 
                    phone_number = @PhoneNumber
                WHERE personnel_id = @PersonnelId;";

                var affectedRows = await db.ExecuteAsync(sql, personnel);
                return affectedRows > 0;
            }
        }
    }
}
