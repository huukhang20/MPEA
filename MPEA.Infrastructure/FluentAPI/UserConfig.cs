using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MPEA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Infrastructure.FluentAPI
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(u => u.Username).HasMaxLength(50);
            builder.Property(u => u.FullName).HasMaxLength(50);
            builder.Property(u => u.Password).HasMaxLength(100);
            builder.Property(u => u.Email).HasMaxLength(50);
            builder.HasIndex(u => u.Email);
            builder.Property(u => u.PhoneNumber).HasMaxLength(11);
            builder.Property(u => u.Role);
            builder.Property(u => u.Birthday);
            builder.Property(u => u.CreatedDate);
            builder.Property(u => u.UpdatedDate);
            builder.Property(u => u.AvatarURL);

            // Relationships

            builder.HasOne<Membership>(u => u.Membership).WithMany(m => m.Users).HasForeignKey(u => u.MembershipId);  
        }
    }
}
