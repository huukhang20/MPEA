using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Application.BaseModel
{
    public class BaseFailedModel
    {
        public int Status { get; set; }
        public string? Message { get; set; }
        public object? Result { get; set; }
        public object? Errors { get; set; }
    }
}
