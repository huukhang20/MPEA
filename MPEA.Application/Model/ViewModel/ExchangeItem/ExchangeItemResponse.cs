using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Application.Model.ViewModel.ExchangeItem
{
    public class ExchangeItemResponse
    {
        public Guid? Id { get; set; }
        public Guid? ExchangeId { get; set; }
        public Guid? SparePartId { get; set; }
        public int? Quantity { get; set; }
    }
}
