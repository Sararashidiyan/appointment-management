using AppointmentManagement.Domain.OTPGenerator;
using Microsoft.Extensions.DependencyInjection;

namespace AppointmentManagement.Infrastructure.DependencyInjections
{
    public static class RegisterOtpGenerator
    {
        public static IServiceCollection AddOtpGenerator(this IServiceCollection services)
        {
            services.AddScoped<IOtpGenerator, OTPGenerator.OtpGenerator>();
            return services;
        }
    }
}
