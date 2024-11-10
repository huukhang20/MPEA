using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Application.Model.RequestModel.ExchangeItemRequest
{
    public class CreateExItemRequest
    {
        public Guid? ExchangeId { get; set; }
        public Guid? SparePartId { get; set; }
        public int? Quantity { get; set; }
    }
}
