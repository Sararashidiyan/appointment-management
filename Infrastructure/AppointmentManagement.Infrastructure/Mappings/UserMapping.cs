using AppointmentManagement.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentManagement.Infrastructure.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users").HasKey(s => s.Id);
            builder.Property(s => s.FirstName).IsRequired();
            builder.Property(s => s.LastName).IsRequired();
            builder.Ignore(s => s.FullName);
            builder.Property(s => s.Role).IsRequired();
            builder.Property(s => s.IsActive).IsRequired();
            builder.Property(s => s.CreatedAt).IsRequired();
            builder.Property(s => s.CreatedUserId).IsRequired();
            builder.Property(s => s.UpdatedAt).IsRequired(false);
            builder.Property(s => s.UpdatedUserId).IsRequired(false);
            builder.OwnsOne(d => d.Mobile, ff =>
            {
                ff.Property(h => h.Value)
                .HasColumnName("Mobile");
            });
            builder.OwnsOne(d => d.Email, ff =>
            {
                ff.Property(h => h.Value)
                .HasColumnName("Email").IsRequired(false);
            });
          
        }
    }
}
