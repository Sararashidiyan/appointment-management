using AppointmentManagement.Domain.Users.RolePermission;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentManagement.Infrastructure.Mappings
{
    public class RolePermissionMapping : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.ToTable("RolePermissions");
            builder.Property(s => s.Role).IsRequired();
            builder.Property(s => s.Permission).IsRequired();
        }
    }
}
