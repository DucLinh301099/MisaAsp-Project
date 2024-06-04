using Dapper;
using Npgsql;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using MisaAsp.Models;

namespace MisaAsp.Repositories
{
    public class ServiceRepository
    {
        private readonly IConfiguration _configuration;
        private readonly DatabaseHelper _databaseHelper;

        public ServiceRepository(DatabaseHelper databaseHelper, IConfiguration configuration)
        {
            _databaseHelper = databaseHelper;
            _configuration = configuration;
        }

        public async Task<IEnumerable<Service>> GetServicesAsync()
        {
            var sql = "SELECT * FROM services";
            return await _databaseHelper.QueryAsync<Service>(sql);
        }
    }
}
