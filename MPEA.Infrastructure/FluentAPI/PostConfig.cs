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
    public class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable(nameof(Post));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(x => x.Title);
            builder.Property(x => x.Description);
            builder.Property(x => x.Status);

            builder.HasOne(x => x.User).WithMany(u => u.Posts).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.SparePart).WithMany(p => p.Posts).HasForeignKey(p => p.PartId);   
        }
    }
}
