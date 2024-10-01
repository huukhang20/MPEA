using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MPEA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Infrastructure.FluentAPI
{
    public class NotificationConfig : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("Notification");

            builder.HasKey(x => x.Id);
            builder.Property(n => n.Id).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(n => n.Title).IsRequired().HasMaxLength(50);
            builder.Property(n => n.Description).IsRequired().HasMaxLength(150);
            builder.Property(n => n.Status);
            builder.Property(n => n.CreatedAt);

        }
    }
}
