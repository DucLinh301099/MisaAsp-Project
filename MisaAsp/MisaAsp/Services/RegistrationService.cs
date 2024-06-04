using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MisaAsp.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MisaAsp.Repositories;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace MisaAsp.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IConfiguration _configuration;
        private readonly DatabaseHelper _databaseHelper;

        public RegistrationService(DatabaseHelper databaseHelper, IConfiguration configuration)
        {
            _databaseHelper = databaseHelper;
            _configuration = configuration;
        }

        public async Task<IEnumerable<UserRequest>> GetAllUsersAsync()
        {
            var sql = "SELECT * FROM GetAllUsers()";
            return await _databaseHelper.QueryAsync<UserRequest>(sql);
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

            var hashedPassword = GetMd5Hash(request.Password);

            var parameters = new 
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Password = hashedPassword,
            };

            return await _databaseHelper.ExecuteProcScalarAsync<int>("registeruser", parameters);
        }

        public async Task<bool> IsEmailUniqueAsync(string email)
        {
            var query = "SELECT COUNT(1) FROM Registrations WHERE Email = @Email";
            var count = await _databaseHelper.ExecuteScalarAsync<int>(query, new { Email = email });
            return count == 0;
        }

        public async Task<bool> IsPhoneUniqueAsync(string phoneNumber)
        {
            var query = "SELECT COUNT(1) FROM Registrations WHERE PhoneNumber = @PhoneNumber";
            var count = await _databaseHelper.ExecuteScalarAsync<int>(query, new { PhoneNumber = phoneNumber });
            return count == 0;
        }

        public async Task<string> AuthenticateUserAsync(LoginRequest request)
        {
            var hashedPassword = GetMd5Hash(request.Password);

            var parameters = new
            {
                EmailOrPhoneNumber = request.EmailOrPhoneNumber,
                Password = hashedPassword,
            };

            var loginResult = await _databaseHelper.ExecuteProcScalarAsync<bool>("authenticateuser", parameters);

            if (loginResult)
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

                var token = jwtTokenHandler.CreateToken(tokenDescription);
                return jwtTokenHandler.WriteToken(token);
            }

            return null;
        }

        public async Task<bool> ForgotPasswordAsync(ForgotPasswordRequest request)
        {
            // Check if the email exists
            var sql = "SELECT CheckEmailExists(@Email)";
            var parameters = new { request.Email };

            var emailExists = await _databaseHelper.ExecuteScalarAsync<bool>(sql, parameters);

            if (!emailExists)
            {
                return false;
            }

            // Logic để tạo token đặt lại mật khẩu và gửi email chứa liên kết đặt lại mật khẩu
            // Ví dụ: tạo token và lưu vào cơ sở dữ liệu hoặc gửi email với liên kết đặt lại mật khẩu

            // Giả sử logic thành công, trả về true
            return true;
        }
    }
}
