using AppointmentManagement.Domain.Doctors.DoctorExperts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentManagement.Infrastructure.Mappings
{
    public class DoctorExpertMapping : IEntityTypeConfiguration<DoctorExpert>
    {
        public void Configure(EntityTypeBuilder<DoctorExpert> builder)
        {
            builder.ToTable("DoctorExperts");
            builder.HasKey(de => new { de.DoctorId, de.ExpertId });

            builder.HasOne(de => de.Doctor)
                   .WithMany(d => d.DoctorExperts)
                   .HasForeignKey(de => de.DoctorId);

            builder.HasOne(de => de.Expert)
                   .WithMany(e => e.DoctorExperts)
                   .HasForeignKey(de => de.ExpertId);
            builder.Property(de => de.IsActive);
        }
    }

}
