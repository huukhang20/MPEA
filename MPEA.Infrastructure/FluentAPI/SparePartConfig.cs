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
    public class SparePartConfig : IEntityTypeConfiguration<SparePart>
    {
        public void Configure(EntityTypeBuilder<SparePart> builder)
        {
            builder.ToTable("SparePart");
            
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Id).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(p => p.Name).HasMaxLength(50);
            builder.Property(p => p.Price);
            builder.Property(p => p.Description).HasMaxLength(150);
            builder.Property(p => p.Status);
            builder.Property(p => p.Image);
            builder.Property(p => p.IsWarranty);
            builder.Property(p => p.WarrntyImage);
            builder.Property(p => p.Image);
            builder.Property(p => p.CreatedDate).HasDefaultValueSql("now()");
            builder.Property(p => p.UserId);
            // Relationships

            builder.HasMany(p => p.Wishlist).WithOne(w => w.SparePart).HasForeignKey(w => w.SparePartId);
            builder.HasMany(p => p.ExchangePart).WithOne(ep => ep.SparePart).HasForeignKey(ep => ep.SparePartId);
        }
    }
}
