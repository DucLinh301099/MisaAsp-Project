using MisaAsp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MisaAsp.Services
{
    public interface IRegistrationService
    {
        Task<int> RegisterUserAsync(RegistrationRequest request);
        Task<string> AuthenticateUserAsync(LoginRequest request);
        Task<IEnumerable<UserRequest>> GetAllUsersAsync();
        Task<bool> ForgotPasswordAsync(ForgotPasswordRequest request);
    }
}
