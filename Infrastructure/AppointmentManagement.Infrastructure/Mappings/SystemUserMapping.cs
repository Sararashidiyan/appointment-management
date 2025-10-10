using AppointmentManagement.Domain.SystemUsers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentManagement.Infrastructure.Mappings
{
    public class SystemUserMapping : IEntityTypeConfiguration<SystemUser>
    {
        public void Configure(EntityTypeBuilder<SystemUser> builder)
        {
            builder.ToTable("SystemUsers");
            builder.Property(s => s.PasswordHash).IsRequired();
            builder.Property(s => s.PasswordSalt).IsRequired();
            builder.Property(s => s.IsSupperAdmin).IsRequired();
        }
    }
}
