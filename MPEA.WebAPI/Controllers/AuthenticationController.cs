using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MPEA.Application.BaseModel;
using MPEA.Application.IService;
using MPEA.Application.Model.RequestModel.Authentication;
using MPEA.Application.Model.ViewModel.Authentication;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace MPEA.WebAPI.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        #region Login

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<LoginResponse> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
                return new LoginResponse
                {
                    Success = false,
                    Message = "Invalid input data. " + string.Join("; ",
                        ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)),
                    RefreshToken = null,
                    JwtToken = ""
                };
            var result = await _authenticationService.Login(request);
            return result;
        }

        #endregion

        #region Create user

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserRequest user)
        {
            try
            {
                var result = await _authenticationService.CreateUser(user);
                return Ok(new BaseResponseModel
                {
                    Status = Ok().StatusCode,
                    Message = "Tạo tài khoản thành công",
                    Response = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseFailedModel
                {
                    Status = BadRequest().StatusCode,
                    Message = ex.Message,
                    Result = false,
                    Errors = ex
                });
            }
        }

        #endregion

        #region ResetPass
        [AllowAnonymous]
        [HttpPost("/forgot-password")]
        [SwaggerOperation(Tags = new[] { "Authentication" })]
        public async Task<IActionResult> ForgotPassword([FromBody] string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return BadRequest(new BaseFailedModel
                {
                    Status = BadRequest().StatusCode,
                    Message = "Bắt buộc phải nhập địa chỉ email.",
                    Result = false
                });
            }

            var result = await _authenticationService.ForgotPassword(email);

            if (!result)
            {
                return BadRequest(new BaseFailedModel
                {
                    Status = BadRequest().StatusCode,
                    Message = "Email không tồn tại trong hệ thống",
                    Result = false
                });
            }

            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Mật khẩu đã được gửi tới địa chỉ email. Vui lòng check email.",
                Response = true
            });
        }

        #endregion
    }
}
