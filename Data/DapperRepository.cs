using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXBeauty.Data
{
    public class DapperRepository
    {
        private readonly string _connectionString;

        public DapperRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }

        protected IEnumerable<T> Query<T>(string sql, object parameters = null)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                return conn.Query<T>(sql, parameters);
            }
        }

        protected int Execute(string sql, object parameters = null)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                return conn.Execute(sql, parameters);
            }
        }

        protected T QueryFirstOrDefault<T>(string sql, object param = null)
        {
            using var conn = GetConnection();
            return conn.QueryFirstOrDefault<T>(sql, param);
        }

    }
}
