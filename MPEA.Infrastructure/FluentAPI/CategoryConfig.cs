using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MPEA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Infrastructure.FluentAPI
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasDefaultValue("gen_random_uuid()");
            builder.Property(c => c.Name);
            builder.Property(c => c.Level);
            builder.Property(c => c.Status);

            builder.HasOne(c => c.ParentCate).WithMany(p => p.ChildCategories).HasForeignKey(c => c.ParentCateId);
            builder.HasMany(c => c.SpareParts).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);
        }
    }
}
