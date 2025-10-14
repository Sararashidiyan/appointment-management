using System.Text.Json.Serialization;

namespace AppointmentManagement.Application.Interfaces.ExternalResources.LocationProvider.DTOs
{
    public class CityDTO
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("province")]
        public string Province { get; set; }
        [JsonPropertyName("english_name")]
        public string EnglishName { get; set; }
    }
}
