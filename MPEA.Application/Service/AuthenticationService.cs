using AutoMapper;
using Microsoft.Extensions.Configuration;
using MPEA.Application.BaseModel;
using MPEA.Application.IService;
using MPEA.Application.Model.RequestModel.Authentication;
using MPEA.Application.Model.ViewModel.Authentication;
using MPEA.Domain.Enum;
using MPEA.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Application.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthentication _authentication;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMailService _mailService;

        public AuthenticationService(IAuthentication authentication, IMapper mapper, IUnitOfWork unitOfWork, IMailService mailService)
        {
            _authentication = authentication;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _mailService = mailService;
        }



        #region Login

        public async Task<LoginResponse> Login(LoginRequest userLogin)
        {
            var response = new LoginResponse();
            var account = await _unitOfWork.UserRepository.FindUserByUsername(userLogin.Username);
            //check null
            if (account != null)
            {
                //Verify Password
                var check = _authentication.VerifyPassword(account.Password, userLogin.Password);
                if (check is true)
                {
                    response.Success = true;
                    response.Message = "Login successfully";
                    response.JwtToken =
                        _authentication.GenerateToken(account);
                    _unitOfWork.UserRepository.Update(account);
                    await _unitOfWork.SaveChangesAsync();

                    return response;
                }

                response.Success = false;
                response.Message = "Failed";
                return response;
            }

            response.Success = false;
            response.Message = "Failed";
            return response;
        }

        private static User GetDefaultMember()
        {
            User? Default = null;
            using (StreamReader r = new StreamReader("appsettings.json"))
            {
                string json = r.ReadToEnd();
                var config = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", true, true)
                                .Build();
                string? email = config["DefaultAccount:Email"];
                string? password = config["DefaultAccount:Password"];
                Default = new User
                {
                    Email = email!,
                    Password = password,
                };
            }
            return Default;
        }

        #endregion

        #region ReGenerate JwtToken Account

        public async Task<string> ReGenerateJwtToken(RefreshTokenRequest refreshToken)
        {
            var account = await _unitOfWork.UserRepository.GetByIdAsync(refreshToken.Id);
            if (account != null)
                return _authentication.GenerateToken(account);
            return "";
        }

        #endregion

        #region Verify Email

        public async Task<bool?> VerifyEmail(Guid id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (user == null) return false;
            user.Status = UserStatus.Active.ToString();
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        #endregion

        #region Refresh Token

        public string RefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }

        #endregion

        #region Generate Account Code

        private async Task<string> GenerateAccountCode(Role role)
        {
            var prefix = role switch
            {
                Role.Exchanger => "EX",
                Role.Staff => "ST",
                Role.Admin => "AD",
                _ => throw new ArgumentException("Vai trờ không hợp lệ")
            };

            var number = await _unitOfWork.UserRepository.CreateNumberOfUserCode(prefix);
            return $"{prefix}-{number:D6}";
        }

        #endregion

        #region Forgot Password

        public async Task<bool> ForgotPassword(string userName)
        {
            var user = await _unitOfWork.UserRepository.FindUserByUsername(userName);
            if (user != null)
            {
                var newPass = RandomPassword();
                user!.Password = _authentication.Hash(newPass);
                await _unitOfWork.SaveChangesAsync();
                MailModel mail = new MailModel();
                mail.To = user!.Email!;
                mail.Body = newPass;
                mail.Subject = "New passWord";
                await _mailService.SendEmail(mail);
                return true;
            }
            return false;
        }
        public string RandomPassword()
        {
            var random = new Random();
            var length = 16; // Length of the random string
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()";
            var randomString = new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            return randomString;
        }

        #endregion

        #region Create Account

        public async Task<RegisterResponse> CreateUser(CreateUserRequest createUser)
        {
            var response = new RegisterResponse();

            var account = _mapper.Map<User>(createUser);
            //if not exist
            account.Password = _authentication.Hash(createUser.Password);
            account.Status = UserStatus.Active.ToString();

            //Generate Code
            account.Code = await GenerateAccountCode((Role)Enum.Parse(typeof(Role), account.Role));

            await _unitOfWork.UserRepository.AddAsync(account);
            var check = await _unitOfWork.SaveChangesAsync() > 0;

            if (check is false)
            {
                response.Message = "Failed";
                response.Success = true;
                return response;
            }

            response.Message = "Succefully";
            response.Success = true;

            //await _mailService.SendConfirmRegistration(account);

            return response;
        }


        #endregion

        //public async Task<ValidationResult> ValidateCreateAccountRequest(CreateAccountRequest painting)
        //{
        //    return await _validatorFactory.CreateAccountRequestValidator.ValidateAsync(painting);
        //}
    }
}
