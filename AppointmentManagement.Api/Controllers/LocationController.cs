using AppointmentManagement.Application.Interfaces.ExternalResources.LocationProvider;
using AppointmentManagement.Application.Interfaces.ExternalResources.LocationProvider.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController(ILocationProviderService _service) : ControllerBase
    {
        [HttpGet("cities")]
        public async Task<List<CityDTO>> GetAllCitiesAsync(int id)
        {
            return await _service.GetAllCitiesAsync();
        }
    }
}
