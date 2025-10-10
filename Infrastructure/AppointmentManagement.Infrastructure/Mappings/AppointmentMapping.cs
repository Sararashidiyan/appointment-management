using AppointmentManagement.Domain.Appointments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentManagement.Infrastructure.Mappings
{
    public class AppointmentMapping : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointments").HasKey(s => s.Id);

            builder.OwnsOne(a => a.DueDateTime, dd =>
            {
                dd.Property(d => d.Value)
                  .HasColumnName("DueDateTime")   
                  .IsRequired();
                //dd.Ignore(d => d.IsExpire);
            });
            builder.Property(s => s.CustomerFullName).IsRequired();
            builder.Property(s => s.CustomerId).IsRequired();
            builder.Property(s => s.DoctorExpertId).IsRequired();
            builder.Property(s => s.DayOfWeek).IsRequired();
            builder.Property(s => s.StateId).IsRequired();
            builder.Ignore(s => s.IsExpire);
            builder.Ignore(s => s.State);
            builder.Property(s => s.CreatedAt).IsRequired();
            builder.Property(s => s.CreatedUserId).IsRequired();
            builder.Property(s => s.UpdatedAt).IsRequired(false);
            builder.Property(s => s.UpdatedUserId).IsRequired(false);
        }
    } 
}
