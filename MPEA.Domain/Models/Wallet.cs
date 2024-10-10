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
        public string? Id { get; set; }  
        public int? Balance { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UserId { get; set; }

        // Relationships

        public User User { get; set; }
        public ICollection<Payment> Payments { get; set; }  
        public ICollection<BankAccount> BankAccount { get; set; }

    }
}
