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
    public class WalletConfig : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.ToTable(nameof(Wallet));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(x => x.Balance);
            builder.Property(x => x.Status);
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("now()");

            builder.HasOne(x => x.User).WithOne(u => u.Wallet).HasForeignKey<Wallet>(x => x.UserId);
        }
    }
}
