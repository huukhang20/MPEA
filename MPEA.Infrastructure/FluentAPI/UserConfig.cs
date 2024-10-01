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
            builder.ToTable("user");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(u => u.UserName).IsRequired().HasMaxLength(50);
            builder.Property(u => u.FullName).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Password).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(50);
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.PhoneNumber).IsRequired().HasMaxLength(11);
            builder.Property(u => u.Role).IsRequired();
            builder.Property(u => u.Birthday);
            builder.Property(u => u.CreatedDate);
            builder.Property(u => u.UpdatedDate);

            // Relationships

            builder.HasMany(u => u.Addresses).WithOne(a => a.User).HasForeignKey(a => a.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(u => u.SpareParts).WithOne(a => a.User).HasForeignKey(a => a.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(u => u.Wishlists).WithOne(a => a.User).HasForeignKey(a => a.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(u => u.Feedbacks).WithOne(a => a.User).HasForeignKey(a => a.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(u => u.ExchangeProviders).WithOne(a => a.Provider).HasForeignKey(a => a.ProviderId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(u => u.ExchangeOffers).WithOne(a => a.Offerer).HasForeignKey(a => a.OffererId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(u => u.ChatSents).WithOne(a => a.Sender).HasForeignKey(a => a.SenderId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(u => u.ChatReceiveds).WithOne(a => a.Receiver).HasForeignKey(a => a.ReceiverId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(u => u.Notifications).WithOne(a => a.User).HasForeignKey(a => a.UserId);
            builder.HasMany(u => u.Reports).WithOne(a => a.User).HasForeignKey(a => a.UserId);
            builder.HasMany(u => u.ExchangeParts).WithOne(a => a.Exchager).HasForeignKey(a => a.ExchangerId);
        }
    }
}
