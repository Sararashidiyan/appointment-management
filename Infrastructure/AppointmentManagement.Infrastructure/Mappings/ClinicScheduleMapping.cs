using AppointmentManagement.Domain.ClinicSettings.ClinicSchedules;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentManagement.Infrastructure.Mappings
{
    public class ClinicScheduleMapping : IEntityTypeConfiguration<ClinicSchedule>
    {
        public void Configure(EntityTypeBuilder<ClinicSchedule> builder)
        {
            builder.ToTable("ClinicSchedules");
            
        }
    }
}
