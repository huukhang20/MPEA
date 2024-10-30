using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Domain.Models
{
    public class Notification
    {
        // Properties

        public Guid? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? UserId { get; set; }
        public bool IsRead { get; set; }

        // Relationships

        public virtual User? User { get; set; }
        
    }
}
