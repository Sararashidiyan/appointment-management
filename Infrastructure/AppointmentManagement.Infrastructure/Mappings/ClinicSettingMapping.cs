using AppointmentManagement.Domain.Appointments;
using AppointmentManagement.Domain.ClinicSettings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentManagement.Infrastructure.Mappings
{
    public class ClinicSettingMapping : IEntityTypeConfiguration<ClinicSetting>
    {
        public void Configure(EntityTypeBuilder<ClinicSetting> builder)
        {
            builder.ToTable("ClinicSettings").HasKey(s => s.Id);
            builder.Property(s => s.VisitPeriodPerMinute).IsRequired();
            builder.Property(s => s.CreatedAt).IsRequired();
            builder.Property(s => s.CreatedUserId).IsRequired();
            builder.Property(s => s.UpdatedAt).IsRequired(false);
            builder.Property(s => s.UpdatedUserId).IsRequired(false);
            builder.HasMany(s => s.ClinicSchedules).WithOne().HasForeignKey(s=>s.ClinicSettingId).IsRequired();
        }
    }
}
