using System.Text.Json.Serialization;

namespace AppointmentManagement.Api.ExternalResources.SmsNotifyEngine.AuthServices
{
    public class TokenResponse
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }

    }
}
