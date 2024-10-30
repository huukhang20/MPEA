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
    public class PurchaseItemConfig : IEntityTypeConfiguration<PurchaseItem>
    {
        public void Configure(EntityTypeBuilder<PurchaseItem> builder)
        {
            builder.ToTable(nameof(PurchaseItem));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(x => x.Quantity);
            builder.Property(x => x.Price);

            builder.HasOne(x => x.Purchase).WithMany(p => p.PurchaseItems).HasForeignKey(x => x.PurchaseId);
            builder.HasOne(x => x.SparePart).WithMany(p => p.PurchaseItems).HasForeignKey(x => x.PartId);
        }
    }
}
