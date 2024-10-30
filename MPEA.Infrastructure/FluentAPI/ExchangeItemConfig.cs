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
    public class ExchangeItemConfig : IEntityTypeConfiguration<ExchangeItem>
    {
        public void Configure(EntityTypeBuilder<ExchangeItem> builder)
        {
            builder.ToTable(nameof(ExchangeItem));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(x => x.Quantity);

            builder.HasOne(x => x.Exchange).WithMany(x => x.Items).HasForeignKey(x => x.ExchangeId);
            builder.HasOne(x => x.SparePart).WithMany(x => x.ExchangeItems).HasForeignKey(x => x.SparePartId);

        }
    }
}
