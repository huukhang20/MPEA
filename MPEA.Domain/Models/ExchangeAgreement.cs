using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Domain.Models
{
    public class ExchangeAgreement
    {
        public Guid? Id { get; set; }
        public Guid? ExchangeId { get; set; }
        public Guid? TermId { get; set; }
        public Guid? UserId { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual Exchange? Exchange { get; set; }
        public virtual ExchangeTerm? ExchangeTerm { get; set; }
        public virtual User? User { get; set; }
    }
}
