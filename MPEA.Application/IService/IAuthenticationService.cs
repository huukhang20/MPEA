using MPEA.Application.Model.RequestModel.Authentication;
using MPEA.Application.Model.ViewModel.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Application.IService
{
    public interface IAuthenticationService
    {
        public Task<LoginResponse> Login(LoginRequest accountLogin);
        public Task<RegisterResponse> CreateUser(CreateUserRequest account);
        //public Task<RegisterResponse> AdminCreateAccount(CreateAccountV2Request account);
        public Task<string> ReGenerateJwtToken(RefreshTokenRequest refreshToken);
        public Task<bool?> VerifyEmail(Guid id);
        public Task<bool> ForgotPassword(string userName);
    }
}
