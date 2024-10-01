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
    public class WarrantyConfig : IEntityTypeConfiguration<Warranty>
    {
        public void Configure(EntityTypeBuilder<Warranty> builder)
        {
            builder.ToTable("Warranty");

            builder.HasKey(x => x.Id);
            builder.Property(w => w.Id).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(w => w.StartDate);
            builder.Property(w => w.EndDate);

            // Relationship

            builder.HasOne(w => w.SparePart).WithOne(p => p.Warranty).HasForeignKey<SparePart>(p => p.WarrantyId);
        }
    }
}
