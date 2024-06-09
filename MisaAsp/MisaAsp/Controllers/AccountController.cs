using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MisaAsp.Models.Ulti;
using MisaAsp.Models.ViewModel;
using MisaAsp.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MisaAsp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        [AllowAnonymous] // Cho phép truy cập không cần xác thực
        public async Task<IActionResult> Register([FromBody] RegistrationRequest request)
        {
            var res = new ResOutput();

            try
            {
                if (!ModelState.IsValid)
                {
                    res.HandleError("Thất bại");
                }
                else
                {
                    var userId = await _accountService.RegisterUserAsync(request);
                    
                    if (userId > 0)
                    {
                        res.HandleSuccess("Đăng kí thành công", new { UserId = userId });
                    }
                    else
                    {
                        res.HandleError("Đăng kí thất bại", new { UserId = userId });
                    }
                }

                return Ok(res);
            }
            catch (Exception ex)
            {
                res.HandleError(ex.Message);
                return BadRequest(res);
            }
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var res = new ResOutput();

            try
            {
                if (!ModelState.IsValid)
                {
                    res.HandleError("Thất bại");
                }
                else
                {
                    var token = await _accountService.AuthenticateUserAsync(request);
                    if (!string.IsNullOrEmpty(token))
                    {
                        res.HandleSuccess("Đăng nhập thành công", new { Token = token });
                    }
                    else
                    {
                        res.HandleError("Thông tin đăng nhập không hợp lệ");
                    }
                }

                return Ok(res);
            }
            catch (Exception ex)
            {
                res.HandleError(ex.Message);
                return BadRequest(res);
            }
        }

        [HttpGet("users")]
        //[Authorize(Roles = "admin")] // Chỉ admin mới được truy cập
        public async Task<IActionResult> GetUsers()
        {
            var users = await _accountService.GetAllUsersAsync();
            var res = new ResOutput();

            if (users != null && users.Any())
            {
                res.HandleSuccess("Lấy thông tin người dùng thành công", users);
                return Ok(res);
            }
            else
            {
                res.HandleError("Lấy thông tin người dùng thất bại");
                return BadRequest(res);
            }
        }

        [HttpPut("users/{id}")]
        //[Authorize(Roles = "user")] // Chỉ admin mới được truy cập
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUser user)
        {
            var res = new ResOutput();

            try
            {
                if (id != user.Id)
                {
                    res.HandleError("User ID không khớp");
                }
                else
                {
                    var result = await _accountService.UpdateUserAsync(user);
                    if (result)
                    {
                        res.HandleSuccess("Cập nhật người dùng thành công");
                    }
                    else
                    {
                        res.HandleError("Cập nhật người dùng thất bại");
                    }
                }

                return Ok(res);
            }
            catch (Exception ex)
            {
                res.HandleError($"Có lỗi xảy ra khi cập nhật người dùng: {ex.Message}");
                return BadRequest(res);
            }
        }

        [HttpDelete("users/{id}")]
       // [Authorize(Roles = "admin")] // Chỉ admin mới được truy cập
        public async Task<IActionResult> DeleteUser(int id)
        {
            var res = new ResOutput();

            try
            {
                var deleted = await _accountService.DeleteUserAsync(id);
                if (deleted)
                {
                    res.HandleSuccess("Xóa người dùng thành công");
                }
                else
                {
                    res.HandleError("Xóa người dùng thất bại");
                }

                return Ok(res);
            }
            catch (Exception ex)
            {
                res.HandleError(ex.Message);
                return BadRequest(res);
            }
        }

        [HttpPost("forgot-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            var res = new ResOutput();

            try
            {
                if (!ModelState.IsValid)
                {
                    res.HandleError("Thất bại");
                }
                else
                {
                    var result = await _accountService.ForgotPasswordAsync(request);
                    if (result)
                    {
                        res.HandleSuccess("Liên kết đặt lại mật khẩu đã được gửi đến email của bạn");
                    }
                    else
                    {
                        res.HandleError("Không tìm thấy email");
                    }
                }

                return Ok(res);
            }
            catch (Exception ex)
            {
                res.HandleError(ex.Message);
                return BadRequest(res);
            }
        }
    }
}
