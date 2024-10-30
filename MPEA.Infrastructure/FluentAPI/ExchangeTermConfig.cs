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
    public class ExchangeTermConfig : IEntityTypeConfiguration<ExchangeTerm>
    {
        public void Configure(EntityTypeBuilder<ExchangeTerm> builder)
        {
            builder.ToTable(nameof(ExchangeTerm));
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(t => t.Description);
            builder.Property(t => t.IsDefault);
            builder.Property(t => t.CreatedDate).HasDefaultValueSql("now()");
        }
    }
}
