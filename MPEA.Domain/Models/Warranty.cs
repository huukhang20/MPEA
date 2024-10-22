using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Domain.Models
{
    public class Warranty
    {
        // Properties

        public string? Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate {  get; set; }

        // Realtionships

        public virtual SparePart SparePart { get; set; }
    }
}
