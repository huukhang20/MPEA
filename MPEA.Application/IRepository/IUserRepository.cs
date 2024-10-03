using MPEA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Application.IRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> FindUserByUsername(string username);
        Task<int> CreateNumberOfUserCode(string roleCode);
    }
}
