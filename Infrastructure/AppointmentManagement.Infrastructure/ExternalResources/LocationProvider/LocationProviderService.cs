using System.Text.Json;
using Microsoft.Extensions.Logging;
using AppointmentManagement.Application.Interfaces.ExternalResources.LocationProvider.DTOs;
using AppointmentManagement.Application.Interfaces.ExternalResources.LocationProvider;

namespace AppointmentManagement.Infrastructure.LocationProviders.LocationProvider
{
    public class LocationProviderService(IHttpClientFactory httpClientFactory, ILogger<LocationProviderService> logger) : ILocationProviderService
    {
        public List<CityDTO> Cities { get; set; }
        public async Task GetAllCitiesAsync()
        {
            var requestUri = $"/cities";
            var client = httpClientFactory.CreateClient("LocationProvider");
            var response = await client.GetAsync(requestUri);
            if (!response.IsSuccessStatusCode)
            {
                logger.LogError(response.Content.ToString());
            }
            var serializedJson = await response.Content.ReadAsStringAsync();
            Cities= JsonSerializer.Deserialize<List<CityDTO>>(serializedJson);
        }
    }
}
