using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Domain.Models
{
    public class SparePart
    {
        // Properties

        public Guid? Id {  get; set; }
        public string? Name { get; set; }
        public double? Price { get; set; }
        public string? CategoryId { get; set; }
        public string? Description { get; set; }
        public bool? IsWarranty { get; set; }
        public string? WarrntyImage { get; set; }
        public Guid? UserId { get; set; }
        public string? Status { get; set; }
        public string? Image { get; set; }
        public DateTime? CreatedDate { get; set; }

        // Relationships 

        public virtual User? User { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<Wishlist>? Wishlist { get; set; }
        public virtual ICollection<Report>? Reports { get; set; }
        public virtual ICollection<ExchangeItem>? ExchangeItems { get; set; }
        public virtual ICollection<PurchaseItem>? PurchaseItems { get; set; }

    }
}
