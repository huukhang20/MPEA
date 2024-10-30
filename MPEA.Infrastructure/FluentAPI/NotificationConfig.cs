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
            builder.Property(n => n.Title);
            builder.Property(n => n.Description);
            builder.Property(n => n.Status);
            builder.Property(n => n.CreatedDate).HasDefaultValueSql("now()");

            builder.HasOne(n => n.User).WithMany(u => u.Notifications).HasForeignKey(n => n.UserId);
        }
    }
}
