using AppointmentManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentManagement.Infrastructure.Mappings
{
    public class ScheduleTemplateMapping : IEntityTypeConfiguration<ScheduleTemplate>
    {
        public void Configure(EntityTypeBuilder<ScheduleTemplate> builder)
        {
            builder.ToTable("ScheduleTemplates").HasKey(s => s.Id);
            builder.OwnsOne(s => s.SchaduleStartDate, ss =>
            {
                ss.Property(d => d.Value)
                 .HasColumnName("SchaduleStartDate")
                 .IsRequired();
            });
            builder.Property(s => s.IsPublish).IsRequired();
            builder.Property(s => s.IsActive).IsRequired();
            builder.Property(s => s.CreatedAt).IsRequired();
            builder.Property(s => s.CreatedUserId).IsRequired();
            builder.Property(s => s.UpdatedAt).IsRequired(false);
            builder.Property(s => s.UpdatedUserId).IsRequired(false);
            builder.HasMany(s => s.WeeklySchedules).WithOne().HasForeignKey(s => s.ScheduleTemplateId);
        }
    }
}
