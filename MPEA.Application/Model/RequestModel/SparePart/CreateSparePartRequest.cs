using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Application.Model.RequestModel.SparePart
{
    public class CreateSparePartRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsWarranty { get; set; }
        public string? WarrantyImage { get; set; }
        public string? UserId { get; set; }
        public string? Status { get; set; }


    }
}
