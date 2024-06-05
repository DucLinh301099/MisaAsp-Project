using Microsoft.AspNetCore.Mvc;
using MisaAsp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using MisaAsp.Models.DTO;

namespace MisaAsp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountantController : ControllerBase
    {
        private readonly IAccountantService _accountantService;

        public AccountantController(IAccountantService accountantService)
        {
            _accountantService = accountantService;
        }

        [HttpGet("list")]
        public async Task<IEnumerable<AccountantGeneric>> GetServices()
        {
            return await _accountantService.GetServicesAsync();
        }
    }
}
