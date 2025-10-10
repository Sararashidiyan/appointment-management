using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagement.Application.Interfaces.Appointments;
using AppointmentManagement.Domain.Appointments;
using Microsoft.Extensions.DependencyInjection;

namespace AppointmentManagement.Application.Extensions
{
    public static class RegisterApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.Scan(scan => scan
    .FromAssemblyOf<IAppointmentService>()
    .AddClasses()
    .AsImplementedInterfaces()
    .WithScopedLifetime());
            services.AddScoped<AppointmentFactory>();
            services.AddScoped<AppointmentDomainService>();
            return services;
        }
    }
}
