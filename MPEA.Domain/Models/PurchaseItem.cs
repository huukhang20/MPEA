using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Domain.Models
{
    public class PurchaseItem
    {
        public Guid Id { get; set; }
        public Guid PurchaseId { get; set; }
        public Guid PartId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public virtual Purchase? Purchase { get; set; }
        public virtual SparePart? SparePart { get; set; }
    }
}
