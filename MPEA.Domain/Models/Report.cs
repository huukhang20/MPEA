using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Domain.Models
{
    public class Report
    {
        // Properties

        public string? Id { get; set; }
        public string? UserId { get; set; }
        public string? Content {  get; set; }
        public string? Type { get; set; }
        public DateTime? CreatedAt {  get; set; } 

        // Relationships

        public User User { get; set; }
    }
}
