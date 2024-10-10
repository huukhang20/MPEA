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

        public Wallet Wallet { get; set; }
        public Wallet Exchagne { get; set; }+
    }
}
