using MPEA.Application.Model.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPEA.Application.Model.RequestModel.AccountRequest;
using MPEA.Application.Model.ViewModel.Chat;

namespace MPEA.Application.IService
{
    public interface IUserService
    {
        Task<List<UserResponse>> GetAllAccount();
        Task<UserResponse> UpdateAccount(Guid id, UpdateAccountRequest request);
        Task<UserResponse> GetUserById(Guid id);
        Task<List<UserResponse>> GetExchangers(int pageNumber, int pageSize);
        Task<List<UserResponse>> GetStaffs(int pageNumber, int pageSize);
        Task<List<ChatSentResponse>> GetExchangerMessage(Guid userId, int pageNumber, int pageSize);
    }
}
