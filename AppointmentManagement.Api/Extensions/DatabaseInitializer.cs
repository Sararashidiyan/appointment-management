using AppointmentManagement.Domain.SystemUsers;
using AppointmentManagement.Domain.Users;
using AppointmentManagement.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagement.Api.Extensions
{
    public static class DatabaseInitializer
    {
        public static async Task InitializeDatabase(this IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppointmentManagementContext>();
                dbContext.Database.Migrate();
                await SeedDate(dbContext);
            }
        }

        private static async Task SeedDate(AppointmentManagementContext dbContext)
        {
            if (!dbContext.SystemUsers.Any())
            {
                var userInAdminRole = SystemUser.CraeteSupperAdmin("سارا", "رشیدی یان", new Email("sararashidiyann@gmail.com"), new Mobile("09126717325"));
                    dbContext.SystemUsers.Add(userInAdminRole);
                await dbContext.SaveChangesAsync();
            }
        }
    }

}
