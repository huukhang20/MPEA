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
    public class ExchangeTypeConfig : IEntityTypeConfiguration<ExchangeType>
    {
        public void Configure(EntityTypeBuilder<ExchangeType> builder)
        {
            builder.ToTable("ExchangeType");

            builder.HasKey(x => x.Id);
            builder.Property(et =>  et.Id).HasDefaultValueSql("NEWID()");
            builder.Property(et => et.Name).IsRequired().HasMaxLength(50);
            builder.Property(et => et.Description).IsRequired().HasMaxLength(200);

            // Relationships

            builder.HasMany(et => et.Exchange).WithOne(e => e.ExchangeType).HasForeignKey(e => e.ExchangeTypeId);

        }
    }
}
