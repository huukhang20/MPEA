using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Domain.Models
{
    public class Wallet
    {
        // Properties
        public Guid? Id { get; set; }  
        public int? Balance { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? UserId { get; set; }

        // Relationships

        public virtual User? User { get; set; }
    }
}
