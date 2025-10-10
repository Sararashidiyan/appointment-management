using AppointmentManagement.Domain.Patients;
using AppointmentManagement.Domain.SystemUsers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentManagement.Infrastructure.Mappings
{
    public class PatientMapping : IEntityTypeConfiguration<Patient>
    { 
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patients");
            builder.OwnsOne(d => d.NationalCode, ff =>
            {
                ff.Property(h => h.Value)
                 .HasColumnName("NationalCode");
            });
        }
    }
}
