using MisaAsp.Models.DTO;
using MisaAsp.Repositories;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MisaAsp.Services
{
    public interface IAccountantService
    {
        Task<IEnumerable<AccountantGeneric>> GetServicesAsync();
    }

    public class AccountantService : IAccountantService
    {
        private readonly IAccountantRepository _accountantRepo;

        public AccountantService(IAccountantRepository accountantRepo)
        {
            _accountantRepo = accountantRepo;
        }

        public async Task<IEnumerable<AccountantGeneric>> GetServicesAsync()
        {
            return await _accountantRepo.GetServicesAsync();
        }
    }
}
