using System.Text.Json;
using System.Text;
using Microsoft.Extensions.Options;

namespace AppointmentManagement.Api.ExternalResources.SmsNotifyEngine.AuthServices
{
    public class AuthService
        (IHttpClientFactory httpClientFactory, IOptions<NotifyEngineSetting> settings, ILogger<AuthService> logger) 
        : IAuthService
    {
        public TokenResponse? TokenResponse { get; set; }
        public async Task AuthenticateAsync()
        {
            var formData = new Dictionary<string, string>
        {
            { "ClientId", settings.Value.client_id },
            { "ClientSecret", settings.Value.client_secret },
            { "grant_type", settings.Value.grant_type }
        };
            TokenResponse = await PostAsync(formData, "auth");
        }

        public async Task RefreshTokenAsync()
        {
            var formData = new Dictionary<string, string>
             {
              { "ClientId", settings.Value.client_id },
              { "grant_type", settings.Value.grant_type }
             };
           TokenResponse= await PostAsync(formData,"refresh-token");
        }
        private async Task<TokenResponse?> PostAsync(Dictionary<string, string> formData, string path)
        {
            var requestUri = $"/Auth/{path}";
            var client = httpClientFactory.CreateClient("NotifyEngine");
            var formDataJson = JsonSerializer.Serialize(formData);
            var content = new StringContent(formDataJson, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(requestUri, content);
            if (!response.IsSuccessStatusCode)
            {
                logger.LogError(response.Content.ToString());
                return null;
            }
            var serializedJson = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TokenResponse>(serializedJson);
        }
    }
}
