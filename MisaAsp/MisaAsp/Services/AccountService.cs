using Microsoft.IdentityModel.Tokens;
using MisaAsp.Models.ViewModel;
using MisaAsp.Repositories;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Claims;

namespace MisaAsp.Services
{
    public interface IAccountService
    {
        Task<bool> IsEmailUniqueAsync(string email);
        Task<bool> IsPhoneUniqueAsync(string phone);
        Task<int> RegisterUserAsync(RegistrationRequest request);
        Task<string> AuthenticateUserAsync(LoginRequest request);
        Task<IEnumerable<UserRequest>> GetAllUsersAsync();
        Task<bool> ForgotPasswordAsync(ForgotPasswordRequest request);
        Task<bool> DeleteUserAsync(int userId);
        Task<bool> UpdateUserAsync(UpdateUser user);
        Task<string> GetRoleAsync(string token);
    }

    public class AccountService : IAccountService
    {
        private readonly IConfiguration _configuration;
        private readonly IAccountRepository _accountRepo;

        public AccountService(IAccountRepository accountRepo, IConfiguration configuration)
        {
            _accountRepo = accountRepo;
            _configuration = configuration;
        }

        public async Task<bool> UpdateUserAsync(UpdateUser user)
        {
            return await _accountRepo.UpdateUserAsync(user);
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            return await _accountRepo.DeleteUserAsync(userId);
        }

        public async Task<IEnumerable<UserRequest>> GetAllUsersAsync()
        {
            return await _accountRepo.GetAllUsersAsync();
        }

        public async Task<bool> IsEmailUniqueAsync(string email)
        {
            return await _accountRepo.IsEmailUniqueAsync(email);
        }

        public async Task<bool> IsPhoneUniqueAsync(string phoneNumber)
        {
            return await _accountRepo.IsPhoneUniqueAsync(phoneNumber);
        }

        public async Task<int> RegisterUserAsync(RegistrationRequest request)
        {
            if (!await IsEmailUniqueAsync(request.Email))
            {
                throw new Exception("Email is already in use.");
            }

            if (!await IsPhoneUniqueAsync(request.PhoneNumber))
            {
                throw new Exception("Phone number is already in use.");
            }

            request.Password = GetMd5Hash(request.Password);

            return await _accountRepo.RegisterUserAsync(request);
        }

        public async Task<string> AuthenticateUserAsync(LoginRequest request)
        {
            request.Password = GetMd5Hash(request.Password);

            if (await _accountRepo.AuthenticateUserAsync(request))
            {
                var jwtTokenHandler = new JwtSecurityTokenHandler();
                var secretKey = _configuration.GetSection("Jwt").GetSection("SecretKey").Value;
                if (string.IsNullOrEmpty(secretKey))
                    throw new ArgumentNullException(nameof(secretKey));

                var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
                var tokenDescription = new SecurityTokenDescriptor
                {
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha256),
                    Expires = DateTime.UtcNow.AddHours(1)
                };
                //if (listRole != null && listRole.Count() > 0)
                //{
                //    foreach (var role in listRole)
                //    {
                //        if (role != null && !string.IsNullOrEmpty(role.RoleName))
                //        {
                //            tokenDescription?.Subject.AddClaim(new Claim(Role, role.RoleName));

                //        }
                //    }
                //}


                var token = jwtTokenHandler.CreateToken(tokenDescription);
                return jwtTokenHandler.WriteToken(token);
            }

            return null;
        }

        public async Task<bool> ForgotPasswordAsync(ForgotPasswordRequest request)
        {
            return await _accountRepo.ForgotPasswordAsync(request);
        }

        public async Task<string> GetRoleAsync(string token)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKey = _configuration.GetSection("Jwt").GetSection("SecretKey").Value;
            if (string.IsNullOrEmpty(secretKey))
                throw new ArgumentNullException(nameof(secretKey));

            var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),
                ValidateIssuer = false,
                ValidateAudience = false
            };

            try
            {
                jwtTokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;
                return jwtToken.Claims.First(x => x.Type == "role").Value;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private string GetMd5Hash(string input)
        {
            using (var md5 = MD5.Create())
            {
                var inputBytes = Encoding.ASCII.GetBytes(input);
                var hashBytes = md5.ComputeHash(inputBytes);
                var sb = new StringBuilder();
                foreach (var t in hashBytes)
                {
                    sb.Append(t.ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
