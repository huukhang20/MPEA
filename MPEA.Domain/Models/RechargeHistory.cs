using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Domain.Models
{
    public class RechargeHistory
    {
        public Guid? Id { get; set; }
        public Guid? UserId { get; set; }
        public decimal? Amount { get; set; }
        public string? PaymentMethod { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual User? User { get; set; }
    }
}
