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
    public class MembershipConfig : IEntityTypeConfiguration<Membership>
    {
        public void Configure(EntityTypeBuilder<Membership> builder)
        {
            builder.ToTable(nameof(Membership));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(x => x.Name);
            builder.Property(x => x.Description);
            builder.Property(x => x.Price);
            builder.Property(x => x.Duration);
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("now()");
        }
    }
}
