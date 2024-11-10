using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Application.Model.RequestModel.PostRequest
{
    public class UpdatePostRequest
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Guid? PartId { get; set; }
        public string? Status { get; set; }
    }
}
