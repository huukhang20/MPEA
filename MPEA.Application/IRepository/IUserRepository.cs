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
        Task<List<User>> GetAllUser();
        Task<User?> Register(User? user);
        Task<User?> UpdateUser(User? user);
        string? GetAdminAccount(string email, string password);
        Task<User?> GetUserById(int id);
        Task<List<User>> GetExchangers(int pageNumber, int pageSize);
        Task<List<User>> GetStaffs(int pageNumber, int pageSize);
    }
}
