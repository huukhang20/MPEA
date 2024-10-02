using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Application.BaseModel
{
    public class BaseResponseModel
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public object? Response { get; set; }
    }
}
