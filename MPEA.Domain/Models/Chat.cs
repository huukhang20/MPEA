using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Domain.Models
{
    public class Chat
    {
        // Properties

        public string? Id { get; set; }
        public string? SenderId { get; set; }
        public string? ReceiverId { get; set; }
        public string? MessageText { get; set; }
        public DateTime? Time { get; set; }
        public string? Status { get; set; }

        // Relationships

        public virtual User Sender { get; set; }
        public virtual User Receiver { get; set; }  
    }
}
