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
    public class PurchaseConfig : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable(nameof(Purchase));
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(p => p.Status);
            builder.Property(p => p.CreatedDate).HasDefaultValueSql("now()");

            builder.HasOne(p => p.Seller).WithMany(s => s.Sold).HasForeignKey(p => p.SellerId);
            builder.HasOne(p => p.Buyer).WithMany(b => b.Bought).HasForeignKey(p => p.BuyerId);
        }
    }
}
