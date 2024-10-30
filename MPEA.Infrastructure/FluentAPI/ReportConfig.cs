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
            builder.Property(r => r.Title);
            builder.Property(r => r.Reason);
            builder.Property(r => r.Status);
            builder.Property(r => r.CreatedDate).HasDefaultValueSql("now()");
            builder.Property(r => r.ResolvedDate);

            builder.HasOne(r => r.User).WithMany(u => u.Reports).HasForeignKey(r => r.UserId);
            builder.HasOne(r => r.SparePart).WithMany(p => p.Reports).HasForeignKey(r => r.PartId);
        }
    }
}
