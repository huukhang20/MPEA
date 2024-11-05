using MPEA.Application.Model.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPEA.Application.Model.RequestModel.AccountRequest;

namespace MPEA.Application.IService
{
    public interface IUserService
    {
        Task<List<UserResponse>> GetAllAccount();
        Task<UserResponse> UpdateAccount(int id, UpdateAccountRequest request);
        Task<UserResponse> GetUserById(int id);
        Task<List<UserResponse>> GetExchangers();
    }
}
