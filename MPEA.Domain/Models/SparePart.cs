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

        public string? Id {  get; set; }
        public string? Name { get; set; }
        public string? CategoryId { get; set; }
        public string? Description { get; set; }
        public bool? IsWarranty { get; set; }
        public string? WarrntyImage { get; set; }
        public string? UserId { get; set; }
        public string? Status { get; set; }
        public string? Image { get; set; }

        // Relationships 

        public User User { get; set; }
        public Category Category { get; set; }
        public ICollection<Wishlist> Wishlist { get; set; }
        public ICollection<ExchangePart> ExchangePart { get; set; }

    }
}
