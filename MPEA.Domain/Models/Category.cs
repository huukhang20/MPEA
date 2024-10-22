using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Domain.Models
{
    public class Category
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Level { get; set; }
        public string? Status { get; set; }
        public string? ParentCateId { get; set; }

        public virtual Category ParentCate { get; set; }
        public virtual ICollection<Category> ChildCategories { get; set; }
        public virtual ICollection<SparePart> SpareParts { get; set; }
    }
}
