using AutoMapper;
using MPEA.Application.IService;
using MPEA.Application.Model.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPEA.Application.Model.RequestModel.AccountRequest;
using MPEA.Application.Model.ViewModel.Chat;

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

        public async Task<UserResponse> UpdateAccount(Guid id, UpdateAccountRequest request)
        {
            var user = await _unitOfWork.UserRepository.GetUserById(id);
            user.PhoneNumber = request.PhoneNumber;
            user.FullName = request.FullName;
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            var respone = _mapper.Map<UserResponse>(user);
            return respone;
        }

        public async Task<UserResponse> GetUserById(Guid id)
        {
            var user = await _unitOfWork.UserRepository.GetUserById(id);
            var respone = _mapper.Map<UserResponse>(user);
            return respone;
        }

        public async Task<List<UserResponse>> GetExchangers(int pageNumber, int pageSize)
        {
            var list = await _unitOfWork.UserRepository.GetExchangers(pageNumber, pageSize);
            return _mapper.Map<List<UserResponse>>(list);
        }

        public async Task<List<UserResponse>> GetStaffs(int pageNumber, int pageSize)
        {
            var list = await _unitOfWork.UserRepository.GetStaffs(pageNumber, pageSize);
            return _mapper.Map<List<UserResponse>>(list);
        }

        public async Task<List<ChatSentResponse>> GetExchangerMessage(Guid userId, int pageNumber, int pageSize)
        {
            var list = await _unitOfWork.UserRepository.GetUserMessageById(userId, pageNumber, pageSize);
            return _mapper.Map<List<ChatSentResponse>>(list);
        }
    }
}
