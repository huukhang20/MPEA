using MPEA.Application.Model.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Application.IService
{
    public interface IUserSerevice
    {
        Task<List<UserResponse>> GetAllAccount();
    }
}
