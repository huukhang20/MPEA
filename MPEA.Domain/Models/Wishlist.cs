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

        public string? Id { get; set; }
        public string? UserId { get; set; }
        public string? SparePartId {  get; set; }   
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        // public string ImageUrl { get; set; } = string.Empty;

        // Relationships

        public virtual User User { get; set; }
        public virtual SparePart SparePart { get; set; }
        public string ImageUrl { get; set; }
    }
}
