using AutoMapper;
using MPEA.Application.IService;
using MPEA.Application.Model.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
