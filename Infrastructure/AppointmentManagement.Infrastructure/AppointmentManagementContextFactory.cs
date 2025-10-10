using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AppointmentManagement.Infrastructure
{
    public class AppointmentManagementContextFactory : IDesignTimeDbContextFactory<AppointmentManagementContext>
    {
        public AppointmentManagementContext CreateDbContext(string[] args)
        {
            //var configuration = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory()) // points to your startup project
            //    .AddJsonFile("appsettings.json")
            //    .Build();

           // var connectionString = configuration.GetConnectionString("DefaultConnection");
            var connectionString = "Server=.;Database=AppointmentManagement;User Id=sa;Password=123456789;Trusted_Connection=False;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";

            var optionsBuilder = new DbContextOptionsBuilder<AppointmentManagementContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new AppointmentManagementContext(optionsBuilder.Options);
        }
    }

}
