using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagement.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AppointmentManagement.Infrastructure.DependencyInjections
{
    public static class RegisterRepositories
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.Scan(scan => scan
     .FromAssemblies(
        //typeof(IAppointmentRepository).Assembly,
        typeof(AppointmentRepository).Assembly
    )
    .AddClasses()
    .AsImplementedInterfaces()
    .WithScopedLifetime());
            return services;
        }
    }
}
