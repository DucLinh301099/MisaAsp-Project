using MisaAsp.Models.DTO;
using System.Data;

namespace MisaAsp.Repositories
{
    public interface IAccountantRepository : IBaseRepository
    {
        Task<IEnumerable<AccountantGeneric>> GetServicesAsync();
    }

    public class AccountantRepository : BaseRepository, IAccountantRepository
    {
        public AccountantRepository(IDbConnection connection) : base(connection) { }

        public async Task<IEnumerable<AccountantGeneric>> GetServicesAsync()
        {
            var sql = "SELECT * FROM services";
            return await QueryAsync<AccountantGeneric>(sql);
        }
    }
}
