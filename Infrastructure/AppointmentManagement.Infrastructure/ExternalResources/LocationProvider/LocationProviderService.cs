using System.Text.Json;
using Microsoft.Extensions.Logging;
using AppointmentManagement.Application.Interfaces.ExternalResources.LocationProvider.DTOs;
using AppointmentManagement.Application.Interfaces.ExternalResources.LocationProvider;
using System.Net.Http;

namespace AppointmentManagement.Infrastructure.LocationProviders.LocationProvider
{
    public class LocationProviderService(IHttpClientFactory httpClientFactory, ILogger<LocationProviderService> logger) : ILocationProviderService
    {
        private List<CityDTO>? _cachedCities;
        private readonly SemaphoreSlim _lock = new(1, 1);
        public async Task<List<CityDTO>> GetAllCitiesAsync()
        {
            if (_cachedCities != null)
                return _cachedCities;

            await _lock.WaitAsync();
            try
            {
                if (_cachedCities == null)
                {
                    var requestUri = $"/cities";
                    var client = httpClientFactory.CreateClient("LocationProvider");
                    var response = await client.GetAsync(requestUri);
                    if (!response.IsSuccessStatusCode)
                    {
                        logger.LogError(response.Content.ToString());
                        return _cachedCities; 
                    }
                    var serializedJson = await response.Content.ReadAsStringAsync();
                    _cachedCities = JsonSerializer.Deserialize<List<CityDTO>>(serializedJson);
                }
            }
            finally
            {
                _lock.Release();
            }

            return _cachedCities;
        }
    }
}
