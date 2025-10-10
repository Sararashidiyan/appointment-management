using AppointmentManagement.Domain.DoctorSchedules;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentManagement.Infrastructure.Mappings
{
    public class DoctorDefaultScheduleMapping : IEntityTypeConfiguration<DoctorDefaultSchedule>
    {
        public void Configure(EntityTypeBuilder<DoctorDefaultSchedule> builder)
        {
            builder.ToTable("DoctorDefaultSchedules");
            
        }
    }
}
