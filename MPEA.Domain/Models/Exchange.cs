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

        public string? Id { get; set; }
        public string? ExchangeTypeId { get; set; }
        public string? Status {  get; set; }
        public bool AgreementTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set;}
        public string? ProviderId { get; set; }
        public string? OffererId { get; set; }

        // Relationships

        public virtual User Provider { get; set; }
        public virtual User Offerer { get; set; }
        public virtual ExchangeType ExchangeType { get; set; }
        public virtual ICollection<ExchangePart> ExchangeParts { get; set; }
    }
}
