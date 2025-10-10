using System.Runtime;
using System.Runtime.CompilerServices;
using AppointmentManagement.Api.BackgroundServices;
using AppointmentManagement.Api.ExternalResources.NotifyEngine.SendServices;
using AppointmentManagement.Api.ExternalResources.SmsNotifyEngine.AuthServices;
using AppointmentManagement.Application.Interfaces.Notify;

namespace AppointmentManagement.Api.ExternalResourceApis.SmsNotifyEngine
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
            services.AddHostedService<NotifyEngineAuthenticateProcessor>();
            var baseAddress = notifyEngineSetting.base_address;
            services.AddHttpClient("NotifyEngine", client => client.BaseAddress = new Uri(baseAddress));
            return services;
        }
    }
}
