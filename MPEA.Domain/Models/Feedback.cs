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
        public string? Id { get; set; } 
        public string? UserId { get; set; }
        public string? ExchangeId { get; set; }
        public string? Rating { get; set; }
        public string? Content { get; set; }
        public DateTime? CreatedAt { get; set; }

        // Realtionships

        public User User { get; set; }
        public Exchange Exchange { get; set; }
    }
}
