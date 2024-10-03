using Microsoft.EntityFrameworkCore;
using MPEA.Application.IRepository;
using MPEA.Domain.Enum;
using MPEA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MPEA.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<int> CreateNumberOfUserCode(string roleCode)
        {
            var listUser = await DbSet.ToListAsync();

            if (listUser == null || !listUser.Any()) return 1;

            // Lọc danh sách các tài khoản có code và bắt đầu với roleCode
            var filteredAccounts = listUser.Where(a => a.Code != null && a.Code.StartsWith(roleCode)).ToList();

            // Kiểm tra xem danh sách filteredAccounts có phần tử nào không
            if (!filteredAccounts.Any()) return 1;

            var maxNumber = filteredAccounts
                .Select(a =>
                {
                    // Dùng biểu thức chính quy để lấy phần số từ mã
                    var match = Regex.Match(a.Code, @"\d+$");
                    return match.Success ? int.Parse(match.Value) : 0;
                })
                .DefaultIfEmpty(0)
                .Max();

            return maxNumber + 1;
        }

        public async Task<User?> FindUserByUsername(string username)
        {
            return await DbSet.FirstOrDefaultAsync(a =>
            a.Username == username && a.Status == UserStatus.Active.ToString());
        }
    }
}
