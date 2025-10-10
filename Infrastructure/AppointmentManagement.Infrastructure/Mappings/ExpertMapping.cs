using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagement.Domain.Experts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentManagement.Infrastructure.Mappings
{
    public class ExpertMapping : IEntityTypeConfiguration<Expert>
    {
        public void Configure(EntityTypeBuilder<Expert> builder)
        {
            builder.ToTable("Experts").HasKey(s=>s.Id);
            builder.Property(s => s.Title).IsRequired();
            builder.Property(s => s.LatinTitle).IsRequired();
            builder.Property(s => s.IsActive).IsRequired();
            builder.Property(s => s.CreatedAt).IsRequired();
            builder.Property(s => s.CreatedUserId).IsRequired();
            builder.Property(s => s.UpdatedAt).IsRequired(false);
            builder.Property(s => s.UpdatedUserId).IsRequired(false);

        }
    }
}
