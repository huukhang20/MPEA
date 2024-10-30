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
    public class FeedbackConfig : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.ToTable("Feedback");

            builder.HasKey(x => x.Id);
            builder.Property(f => f.Id).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(f => f.Rating);
            builder.Property(f => f.Content);
            builder.Property(f => f.CreatedDate).HasDefaultValueSql("now()");
            builder.Property(f => f.Status);

            builder.HasOne(f => f.Sender).WithMany(s => s.FeedbackSents).HasForeignKey(s => s.SenderId);
            builder.HasOne(f => f.Receiver).WithMany(s => s.FeedbackReceiveds).HasForeignKey(s => s.ReceiverId);    
        }
    }
}
