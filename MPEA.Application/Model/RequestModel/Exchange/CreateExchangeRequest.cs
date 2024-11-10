using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Application.Model.RequestModel.Exchange
{
    public class CreateExchangeRequest
    {
        public Guid? ProviderId { get; set; }
        public Guid? OffererId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? Status { get; set; }
    }
}
