using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Domain.Models
{
    public class ExchangeTerm
    {
        public Guid? Id { get; set; }
        public string? Description { get; set; }
        public bool? IsDefault { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<ExchangeAgreement>? Agreement { get; set; }
    }
}
