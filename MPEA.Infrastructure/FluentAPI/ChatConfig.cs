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
            builder.Property(c => c.Id).HasDefaultValue("gen_random_uuid()");
            builder.Property(c => c.MessageText);
            builder.Property(c => c.Time);
            builder.Property(c => c.IsRead);

            builder.HasOne(c => c.Sender).WithMany(s => s.ChatSents).HasForeignKey(c => c.SenderId);
            builder.HasOne(c => c.Receiver).WithMany(r => r.ChatReceiveds).HasForeignKey(c => c.ReceiverId);
        }
    }
}
