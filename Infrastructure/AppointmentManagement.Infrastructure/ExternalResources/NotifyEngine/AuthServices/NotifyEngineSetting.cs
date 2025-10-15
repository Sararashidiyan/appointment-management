using System.Text.Json.Serialization;

namespace AppointmentManagement.Infrastructure.ExternalResources.NotifyEngine.AuthServices
{
    public class NotifyEngineSetting
    {
        public string base_address { get; set; }
        public string client_id { get; set; }
        public string client_secret { get; set; } 
        public string grant_type { get; set; }
    }
    public class LocationSetting
    {
        public string base_address { get; set; }
    }
}
