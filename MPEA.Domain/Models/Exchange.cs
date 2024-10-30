using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Domain.Models
{
    public class Exchange
    {
        // Properties

        public Guid? Id { get; set; }
        public Guid? ProviderId { get; set; }   
        public Guid? OffererId { get; set; }
        public string? Status {  get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string? ExchangeType { get; set; }

        // Relationships

        public virtual User? Provider { get; set; }
        public virtual User? Offerer { get; set; }
        public virtual Payment? Payment { get; set; }
        public ICollection<ExchangeAgreement>? Agreement { get; set; }
        public ICollection<ExchangeItem>? Items { get; set; }
    }
}
