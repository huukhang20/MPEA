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
    public class ReportConfig : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.ToTable("Report");

            builder.HasKey(x => x.Id);
            builder.Property(r => r.Id).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(r => r.Content).IsRequired().HasMaxLength(150);
            builder.Property(r => r.Type).IsRequired();
            builder.Property(r => r.CreatedAt);
        }
    }
}
