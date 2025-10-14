using AppointmentManagement.Application.Interfaces.ExternalResources.LocationProvider;
using AppointmentManagement.Infrastructure.LocationProviders.LocationProvider;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppointmentManagement.Infrastructure.Extensions
{
    public static class RegisterLocationProvider
    {
        public static IServiceCollection AddLocationProviderServices(this IServiceCollection services,IConfiguration configuration)
        { 
            var locationSettingsSection = configuration.GetSection("LocationSettings");
            var locationSetting = locationSettingsSection?.Get<LocationSetting>();
            if (locationSetting == null)
            {
                //logger.LogInformation("LocationService feature is not available.");
                return services;
            }
            services.AddSingleton<ILocationProviderService, LocationProviderService>();
            var baseAddress = locationSetting.base_address;
            services.AddHttpClient("LocationProvider", client => client.BaseAddress = new Uri(baseAddress));
            return services;
        }
    }
}
