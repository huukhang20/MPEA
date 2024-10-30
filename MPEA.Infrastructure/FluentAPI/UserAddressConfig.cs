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
    public class UserAddressConfig : IEntityTypeConfiguration<UserAddress>
    {
        public void Configure(EntityTypeBuilder<UserAddress> builder)
        {
            builder.ToTable("Address");

            builder.HasKey(x => x.Id);
            builder.Property(a => a.Id).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(a => a.Street);
            builder.Property(a => a.City);
            builder.Property(a => a.Country);
            builder.Property(a => a.PostalCode);
            builder.Property(a => a.CreatedDate).HasDefaultValueSql("now()");
            builder.Property(a => a.DeletedDate);

            builder.HasOne(a => a.User).WithMany(u => u.Addresses).HasForeignKey(a => a.UserId);
        }
    }
}
