using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Domain.Models
{
    public class Purchase
    {
        public Guid? Id { get; set; }
        public Guid? SellerId { get; set; }
        public Guid? BuyerId { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual User? Seller { get; set; }
        public virtual User? Buyer { get; set; }
        public virtual Payment? Payment { get; set; }
        public virtual ICollection<PurchaseItem>? PurchaseItems { get; set; }
    }
}
