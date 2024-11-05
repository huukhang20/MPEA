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
using Microsoft.Extensions.Configuration;

namespace MPEA.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> CreateNumberOfUserCode(string roleCode)
        {
            var listUser = await DbSet.ToListAsync();

            if (listUser == null || !listUser.Any()) return 1;

            var filteredAccounts = listUser.Where(a => a.Code != null && a.Code.StartsWith(roleCode)).ToList();

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

        public async Task<List<User>> GetAllUser()
        {
            var list = await DbSet.ToListAsync();
            return list;
        }

        public async Task<User?> Register(User? user)
        {
            var result = await DbSet.AddAsync(user);
            return result.Entity;
        }

        public async Task<User?> UpdateUser(User? user)
        {
            if (user == null)
            {
                return null; 
            }
            DbSet.Update(user);
            await _context.SaveChangesAsync();
            return user; 
        }

        public string? GetAdminAccount(string email, string password)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            // Check if the configuration key exists
            if (config.GetSection("AdminAccount").Exists())
            {
                string emailJson = config["AdminAccount:adminemail"];
                string passwordJson = config["AdminAccount:adminpassword"];

                // Check if both email and password match
                if (emailJson == email && passwordJson == password)
                {
                    return emailJson;
                }
            }

            return null;
        }

        public async Task<User?> GetUserById(int id)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.Id.ToString() == id.ToString());

        }

        public async Task<User?> FindUserByUsername(string username)
        {
            return await DbSet.FirstOrDefaultAsync(a =>
            a.Username == username && a.Status == UserStatus.Active.ToString());
        }

        public async Task<List<User>> GetExchangers()
        {
            var list = await DbSet.Where(u => u.Role.Equals(Role.Exchanger.ToString())).ToListAsync();
            return list;
        }
    }
}
