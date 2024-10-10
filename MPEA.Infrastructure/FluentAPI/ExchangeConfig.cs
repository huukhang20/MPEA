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
    public class ExchangeConfig : IEntityTypeConfiguration<Exchange>
    {
        public void Configure(EntityTypeBuilder<Exchange> builder)
        {
            builder.ToTable("Exchange");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.Status);
            builder.Property(e => e.AgreementTerm);
            builder.Property(e => e.CreatedDate);
            builder.Property(e => e.UpdatedDate);

            // Relationships

            builder.HasMany(e => e.ExchangeParts).WithOne(ep => ep.Exchange).HasForeignKey(ep => ep.ExchangeId);

        }
    }
}
