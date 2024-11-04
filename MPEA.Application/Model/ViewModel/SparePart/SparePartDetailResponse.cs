using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Application.Model.ViewModel.SparePart
{
    public class SparePartDetailResponse
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public double? Price { get; set; }
        public string? Description { get; set; }
        public bool? IsWarranty { get; set; }
        public string? WarrntyImage { get; set; }
        public string? UserCode { get; set; }
    }
}
