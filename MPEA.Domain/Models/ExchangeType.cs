using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Domain.Models
{
    public class ExchangeType
    {
        // Properties

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Relationships

        public virtual ICollection<Exchange> Exchange { get; set; }
    }
}
