using AppointmentManagement.Domain.DoctorSchedules;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentManagement.Infrastructure.Mappings
{
    public class DoctorOverrideScheduleMapping : IEntityTypeConfiguration<DoctorOverrideSchedule>
    {
        public void Configure(EntityTypeBuilder<DoctorOverrideSchedule> builder)
        {
            builder.ToTable("DoctorOverrideSchedules");
            builder.Property(s => s.Reason).IsRequired();
        }
    }
  
}
