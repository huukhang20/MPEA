using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Domain.Models
{
    public class Payment
    {
        public string? PaymentId { get; set; }
        public string? ExchangeId { get; set; }

        // Realtionships

        public virtual Wallet Wallet { get; set; }
        public virtual Wallet Exchagne { get; set; }
    }
}
