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
    public class ExchangeAgreementConfig : IEntityTypeConfiguration<ExchangeAgreement>
    {
        public void Configure(EntityTypeBuilder<ExchangeAgreement> builder)
        {
            builder.ToTable(nameof(ExchangeAgreement));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(x => x.Status);
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("now()");

            builder.HasOne(x => x.Exchange).WithMany(e => e.Agreement).HasForeignKey(x => x.ExchangeId);
            builder.HasOne(x => x.ExchangeTerm).WithMany(e => e.Agreement).HasForeignKey(x => x.TermId);
            builder.HasOne(x => x.User).WithMany(u => u.ExchangeAgreements).HasForeignKey(x => x.UserId);
        }
    }
}
