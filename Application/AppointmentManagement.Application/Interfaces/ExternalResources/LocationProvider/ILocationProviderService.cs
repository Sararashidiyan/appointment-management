using System.Text.Json;
using System.Text;
using AppointmentManagement.Application.Interfaces.ExternalResources.LocationProvider.DTOs;

namespace AppointmentManagement.Application.Interfaces.ExternalResources.LocationProvider
{
    public interface ILocationProviderService
    {
       Task<List<CityDTO>> GetAllCitiesAsync();
    }
}
