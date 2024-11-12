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
    public class PaymentConfig : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable(nameof(Payment));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(x => x.Amount);
            builder.Property(x => x.PaymentMethod);
            builder.Property(x => x.Status);
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("now()");
            builder.Property(x => x.Code);

            builder.HasOne(x => x.Payer).WithMany(p => p.Payments).HasForeignKey(x => x.PayerId);
            builder.HasOne(x => x.Purchase).WithOne(p => p.Payment).HasForeignKey<Payment>(x => x.PurchaseId);
            builder.HasOne(x => x.Exchange).WithOne(e => e.Payment).HasForeignKey<Payment>(x => x.ExchangeId);
            builder.HasOne(x => x.Membership).WithMany(m => m.Payments).HasForeignKey(x => x.MembershipId);
        }
    }
}
