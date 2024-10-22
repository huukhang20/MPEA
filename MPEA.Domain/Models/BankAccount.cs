using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Domain.Models
{
    public class BankAccount
    {
        // Properties

        public string? Id { get; set; }
        public string? Bank {  get; set; }
        public string? BankAccountNumber { get; set; }
        public string? BankAccountName { get; set; }
        public bool IsDefault { get; set; }
        public string? WalletId { get; set; }

        // Realtionships

        public virtual Wallet Wallet { get; set; }
    }
}
