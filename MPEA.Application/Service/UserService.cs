using MPEA.Application.IService;
using MPEA.Application.Model.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Application.Service
{
    public class UserService : IUserSerevice
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<UserResponse>> GetAllAccount()
        {
            var userList = await _unitOfWork.UserRepository.GetAllAsync();
            var result = new List<UserResponse>();
            return result;
        }
    }
}
