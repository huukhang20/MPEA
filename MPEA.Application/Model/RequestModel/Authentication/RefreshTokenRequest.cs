using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Application.Model.RequestModel.Authentication
{
    public class RefreshTokenRequest
    {
        public Guid Id { get; set; }
        public string? Role { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime Expried { get; set; }
    }
}
