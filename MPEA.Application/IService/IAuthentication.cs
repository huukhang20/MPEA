using MPEA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Application.IService
{
    public interface IAuthentication
    {
        public bool VerifyPassword(string HashPassword, string InputPassword);
        public string Hash(string password);
        public string GenerateToken(User user);
    }
}
