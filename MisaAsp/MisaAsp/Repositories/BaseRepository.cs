using Dapper;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace MisaAsp.Repositories
{
    public interface IBaseRepository
    {

        Task<int> ExecuteAsync(string sql, object parameters = null);
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters = null);
        Task<T> ExecuteScalarAsync<T>(string sql, object parameters = null);
        Task<T> ExecuteProcScalarAsync<T>(string procedureName, object parameters);
    }

    public class BaseRepository : IBaseRepository
    {
        private readonly IDbConnection _connection;

        public BaseRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> ExecuteAsync(string sql, object parameters = null)
        {
            try
            {
                _connection.Open();
                return await _connection.ExecuteAsync(sql, parameters);
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters = null)
        {
            try
            {
                _connection.Open();
                return await _connection.QueryAsync<T>(sql, parameters);
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }

        public async Task<T> ExecuteScalarAsync<T>(string sql, object parameters = null)
        {
            try
            {
                _connection.Open();
                return await _connection.ExecuteScalarAsync<T>(sql, parameters);
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
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

            try
            {
                _connection.Open();
                return await _connection.ExecuteScalarAsync<T>(sql, parameters);
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }
    }
}
