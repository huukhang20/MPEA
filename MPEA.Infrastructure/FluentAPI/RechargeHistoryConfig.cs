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
    public class RechargeHistoryConfig : IEntityTypeConfiguration<RechargeHistory>
    {
        public void Configure(EntityTypeBuilder<RechargeHistory> builder)
        {
            builder.ToTable(nameof(RechargeHistory));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(x => x.Amount);
            builder.Property(x => x.PaymentMethod);
            builder.Property(x => x.Status);
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("now()");

            builder.HasOne(x => x.User).WithMany(u => u.RechargeHistories).HasForeignKey(u => u.UserId);
        }
    }
}
