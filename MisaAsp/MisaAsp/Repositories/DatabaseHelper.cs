using Dapper;
using Npgsql;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using MisaAsp.Models;

namespace MisaAsp.Repositories
{
    public class DatabaseHelper
    {
        private readonly IConfiguration _configuration;

        public DatabaseHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters = null)
        {
            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (connection.State == ConnectionState.Closed)
                    await connection.OpenAsync();

                return await connection.QueryAsync<T>(sql, parameters);
            }
        }

        public async Task<T> ExecuteScalarAsync<T>(string sql, object parameters = null)
        {
            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (connection.State == ConnectionState.Closed)
                    await connection.OpenAsync();

                return await connection.ExecuteScalarAsync<T>(sql, parameters);
            }
        }

        public async Task<T> ExecuteProcScalarAsync<T>(string procedureName, object parameters)
        {
            var listParam = new List<string>();
            var sql = string.Empty;
            var listProp = parameters.GetType().GetProperties().ToList();
            foreach (var item in listProp)
            {
                listParam.Add($"@{item.Name}");
            }
            if (listParam.Count > 0)
            {
                sql = $"SELECT {procedureName}({string.Join(',', listParam)})";
            }
            else
            {
                sql = $"SELECT {procedureName}()";
            }
            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (connection.State == ConnectionState.Closed)
                    await connection.OpenAsync();

                return await connection.ExecuteScalarAsync<T>(sql, parameters);
            }
        }
    }
}
