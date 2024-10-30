using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Domain.Models
{
    public class Wishlist
    {
        // Properties

        public Guid? Id { get; set; }
        public Guid? UserId { get; set; }
        public Guid? SparePartId {  get; set; }   
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        // public string ImageUrl { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }

        // Relationships

        public virtual User? User { get; set; }
        public virtual SparePart? SparePart { get; set; }

    }
}
