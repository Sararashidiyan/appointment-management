using System.Text.Json;
using System.Text;
using Microsoft.Extensions.Options;
using Azure;
using Microsoft.Extensions.Logging;

namespace AppointmentManagement.Infrastructure.ExternalResources.NotifyEngine.AuthServices
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
            await GetTokenAsync(formData, "auth");
        }

        public async Task RefreshTokenAsync()
        {
            var formData = new Dictionary<string, string>
             {
              { "ClientId", settings.Value.client_id },
              { "grant_type", settings.Value.grant_type }
             };
            await GetTokenAsync(formData,"refresh-token");
        }
        private async Task GetTokenAsync(Dictionary<string, string> formData, string path)
        {
            try
            {
                var requestUri = $"/Auth/{path}";
                var client = httpClientFactory.CreateClient("NotifyEngine");
                var formDataJson = JsonSerializer.Serialize(formData);
                var content = new StringContent(formDataJson, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(requestUri, content);
                if (!response.IsSuccessStatusCode)
                {
                    logger.LogError(response.Content.ToString());
                }
                else
                {
                    var serializedJson = await response.Content.ReadAsStringAsync();
                    TokenResponse = JsonSerializer.Deserialize<TokenResponse>(serializedJson);
                }
                
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
           
        }
    }
}
