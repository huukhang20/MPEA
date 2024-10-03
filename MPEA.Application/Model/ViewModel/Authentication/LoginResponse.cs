using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Application.Model.ViewModel.Authentication
{
    public class LoginResponse
    {
        public string? JwtToken { get; set; }
        public RefreshToken? RefreshToken { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
}
