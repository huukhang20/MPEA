using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Domain.Models
{
    public class ExchangeItem
    {
        // Properties

        public Guid? Id { get; set; }
        public Guid? ExchangeId {  get; set; }
        public Guid? SparePartId { get; set; }
        public int? Quantity { get; set; }

        // Relationships
        public virtual SparePart? SparePart { get; set; }
        public virtual Exchange? Exchange { get; set; }  
    }
}
