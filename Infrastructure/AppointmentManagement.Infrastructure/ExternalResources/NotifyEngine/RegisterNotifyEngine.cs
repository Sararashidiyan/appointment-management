using AppointmentManagement.Application.Interfaces.Notify;
using AppointmentManagement.Infrastructure.ExternalResources.NotifyEngine.AuthServices;
using AppointmentManagement.Infrastructure.ExternalResources.NotifyEngine.SendServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppointmentManagement.Infrastructure.ExternalResources.NotifyEngine
{
    public static class RegisterNotifyEngine
    {
        public static IServiceCollection AddNotifyEngineServices(this IServiceCollection services,IConfiguration configuration)
        { 
            services.AddScoped<INotifyService, SmsNotifyService>();
            var notifyEngineSettingsSection = configuration.GetSection("NotifyEngineSettings");
            var notifyEngineSetting = notifyEngineSettingsSection?.Get<NotifyEngineSetting>();
            if (notifyEngineSetting == null)
            {
                //logger.LogInformation("NotifyEngine feature is not available.");
                return services;
            }
            services.Configure<NotifyEngineSetting>(notifyEngineSettingsSection);
            services.AddSingleton<IAuthService, AuthService>();
            var baseAddress = notifyEngineSetting.base_address;
            services.AddHttpClient("NotifyEngine", client => client.BaseAddress = new Uri(baseAddress));
            return services;
        }
    }
}
