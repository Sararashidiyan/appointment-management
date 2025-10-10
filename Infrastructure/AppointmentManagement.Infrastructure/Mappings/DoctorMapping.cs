using AppointmentManagement.Domain.Doctors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentManagement.Infrastructure.Mappings
{
    public class DoctorMapping : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("Doctors");
            builder.HasMany(s=>s.DefaultSchedules).WithOne().HasForeignKey(s => s.DoctorId);
            builder.HasMany(s=>s.OverrideSchedules).WithOne().HasForeignKey(s => s.DoctorId);
            builder.Property(s => s.PasswordHash).IsRequired();
            builder.Property(s => s.PasswordSalt).IsRequired();
        }
    }

}
