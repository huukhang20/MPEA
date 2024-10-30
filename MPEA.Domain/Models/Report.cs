using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPEA.Domain.Models.BaseModel;

namespace MPEA.Domain.Models
{
    public class Report : BaseModel.BaseModel
    {
        // Properties

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid PartId { get; set; }
        public string? Title { get; set; }
        public string? Reason { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ResolvedDate { get; set; }

        // Relationships
        public User? User { get; set; }
        public SparePart? SparePart { get; set; }
    }
}
