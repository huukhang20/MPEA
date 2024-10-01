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
    public class ChatConfig : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder.ToTable("Chat");

            builder.HasKey(x => x.Id);
            builder.Property(c => c.Id).HasDefaultValue("NEWID()");
            builder.Property(c => c.MessageText).IsRequired().HasMaxLength(1000);
            builder.Property(c => c.Time);
            builder.Property(c => c.Status);
        }
    }
}
