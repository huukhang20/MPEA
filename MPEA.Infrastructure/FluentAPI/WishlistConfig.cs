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
    public class WishlistConfig : IEntityTypeConfiguration<Wishlist>
    {
        public void Configure(EntityTypeBuilder<Wishlist> builder)
        {
            builder.ToTable("Wishlist");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(x => x.CreatedAt);
            builder.Property(x => x.UpdatedAt);
            builder.Property(x => x.DeletedAt);
            builder.Property(x => x.ImageUrl);

            builder.HasOne(x => x.User).WithMany(u => u.Wishlists).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.SparePart).WithMany(p => p.Wishlist).HasForeignKey(x => x.SparePartId);
        }
    }
}
