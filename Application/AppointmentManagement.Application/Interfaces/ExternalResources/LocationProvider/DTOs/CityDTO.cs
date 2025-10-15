using System.Text.Json.Serialization;

namespace AppointmentManagement.Application.Interfaces.ExternalResources.LocationProvider.DTOs
{
    public class CityDTO
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("state")]
        public string Province { get; set; }
    }
}
