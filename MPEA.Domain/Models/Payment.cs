using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Domain.Models
{
    public class Payment
    {
        public Guid? Id { get; set; }
        public Guid? PurchaseId { get; set; }
        public Guid? ExchangeId { get; set; }
        public Guid? PayerId { get; set; }
        public Guid? MembershipId { get; set; }
        public string? Code { get; set; }
        public decimal Amount { get; set; }
        public string? PaymentMethod { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedDate { get; set; }


        // Realtionships
        public virtual User? Payer { get; set; }
        public virtual Purchase? Purchase { get; set; }
        public virtual Exchange? Exchange { get; set; }
        public virtual Membership? Membership { get; set; }
    }
}
