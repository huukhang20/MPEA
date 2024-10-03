using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Application.Model.ViewModel.Authentication
{
    public class RefreshToken
    {
        private static readonly DateTime Current = DateTime.Now;
        public DateTime CreateTime = DateTime.Now;
        public DateTime Expired = Current.AddDays(10);
        public string Token { get; set; }
    }
}
