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

        public Guid? Id { get; set; }
        public Guid? SenderId { get; set; }
        public Guid? ReceiverId { get; set; }
        public string? MessageText { get; set; }
        public DateTime? Time { get; set; }
        public bool? IsRead { get; set; }

        // Relationships

        public virtual User? Sender { get; set; }
        public virtual User? Receiver { get; set; }  
    }
}
