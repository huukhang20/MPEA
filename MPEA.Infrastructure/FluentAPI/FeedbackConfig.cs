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
            builder.Property(f => f.Id).HasDefaultValueSql("NEWID()");
            builder.Property(f => f.Rating).IsRequired();
            builder.Property(f => f.Content).IsRequired().HasMaxLength(100);
            builder.Property(f => f.CreatedAt);
        }
    }
}
