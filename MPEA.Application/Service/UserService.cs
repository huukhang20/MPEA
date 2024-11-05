using AutoMapper;
using MPEA.Application.IService;
using MPEA.Application.Model.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPEA.Application.Model.RequestModel.AccountRequest;

namespace MPEA.Application.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<UserResponse>> GetAllAccount()
        {
            var userList = await _unitOfWork.UserRepository.GetAllAsync();
            var result = _mapper.Map<List<UserResponse>>(userList);
            return result;
        }

        public async Task<UserResponse> UpdateAccount(int id, UpdateAccountRequest request)
        {
            var user = await _unitOfWork.UserRepository.GetUserById(id);
            user.PhoneNumber = request.PhoneNumber;
            user.FullName = request.FullName;
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            var respone = _mapper.Map<UserResponse>(user);
            return respone;
        }

        public async Task<UserResponse> GetUserById(int id)
        {
            var user = await _unitOfWork.UserRepository.GetUserById(id);
            var respone = _mapper.Map<UserResponse>(user);
            return respone;
        }

        public async Task<List<UserResponse>> GetExchangers()
        {
            var list = await _unitOfWork.UserRepository.GetExchangers();
            return _mapper.Map<List<UserResponse>>(list);
        }
    }
}
