using AppointmentManagement.Domain.DoctorSchedules;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentManagement.Infrastructure.Mappings
{
    public class WeeklyScheduleMapping : IEntityTypeConfiguration<WeeklySchedule>
    {
        public void Configure(EntityTypeBuilder<WeeklySchedule> builder)
        {
            builder.ToTable("WeeklySchedules").HasKey(s => s.Id);
            builder.Property(s => s.DayOfWeek).IsRequired();
            builder.OwnsMany(s => s.TimeSlot, nb =>
            {
                nb.ToJson();
            });
        }
    }
}
