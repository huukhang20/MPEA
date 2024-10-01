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
    public class ExchangePartConfig : IEntityTypeConfiguration<ExchangePart>
    {
        public void Configure(EntityTypeBuilder<ExchangePart> builder)
        {
            builder.ToTable("ExchangePart");

            builder.HasKey(ep => ep.Id);
            builder.Property(ep => ep.Id).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(ep => ep.Quantity).IsRequired();
            builder.Property(ep => ep.CreatedAt);
            builder.Property(ep => ep.UpdatedAt);
        }
    }
}
