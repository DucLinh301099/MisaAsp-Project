using MisaAsp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MisaAsp.Services
{
    public interface IRegistrationService
    {
        Task<bool> IsEmailUniqueAsync(string email);
        Task<bool> IsPhoneUniqueAsync(string phone);
        Task<int> RegisterUserAsync(RegistrationRequest request);
        Task<string> AuthenticateUserAsync(LoginRequest request);
        Task<IEnumerable<UserRequest>> GetAllUsersAsync();
        Task<bool> ForgotPasswordAsync(ForgotPasswordRequest request);
    }
}
