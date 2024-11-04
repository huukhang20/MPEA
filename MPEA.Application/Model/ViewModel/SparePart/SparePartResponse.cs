using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Application.Model.ViewModel.SparePart
{
    public class SparePartResponse
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? CategoryName { get; set; }
        public string? Price { get; set; }
        public string? Description { get; set; }
        public string? UserId { get; set; }
        public string? Status { get; set; }
        public string? Image { get; set; }
        public string? CreatedDate { get; set; }
    }
}
