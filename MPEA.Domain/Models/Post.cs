using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Domain.Models
{
    public class Post
    {
        public Guid? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Guid? UserId { get; set; }
        public Guid? PartId { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual User? User { get; set; }
        public virtual SparePart? SparePart { get; set; }
    }
}
