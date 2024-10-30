using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Domain.Models
{
    public class Feedback
    {
        // Properties
        public Guid? Id { get; set; } 
        public Guid? SenderId { get; set; }
        public Guid? ReceiverId { get; set; }
        public int Rating { get; set; }
        public string? Content { get; set; }
        public DateTime? CreatedDate{ get; set; }
        public string? Status { get; set; }

        // Realtionships

        public virtual User? Sender { get; set; }
        public virtual User? Receiver { get; set; }
    }
}
