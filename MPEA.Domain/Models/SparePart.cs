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
        public string? TechnicalSpecifications { get; set; }
        public string? WarrantyId {  get; set; }
        public string? UserId { get; set; }
        public string? Status { get; set; }

        // Relationships 

        public User User { get; set; }
        public Warranty Warranty { get; set; }
        public ICollection<Wishlist> Wishlist { get; set; }
        public ICollection<Feedback> Feedback {  get; set; }
        public ICollection<ExchangePart> ExchangePart { get; set; }

    }
}
