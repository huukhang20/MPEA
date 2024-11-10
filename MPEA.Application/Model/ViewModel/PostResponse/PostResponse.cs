using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Application.Model.ViewModel.PostResponse
{
    public class PostResponse
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public string? UserCode { get; set; }
        public Guid? PartId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
