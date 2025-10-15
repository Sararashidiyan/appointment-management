using System.Text.Json;
using System.Text;
using AppointmentManagement.Application.Interfaces.Notify;
using AppointmentManagement.Infrastructure.ExternalResources.NotifyEngine.AuthServices;

namespace AppointmentManagement.Infrastructure.ExternalResources.NotifyEngine.SendServices
{
    public class EmailNotifyService(IHttpClientFactory httpClientFactory, IAuthService authService) : INotifyService
    {
        public async Task SendAsync(string type, string to)
        {
            if (authService.TokenResponse == null) return;
            var client = httpClientFactory.CreateClient("NotifyEngine");
            var payload = new NotifyMessage() { Type = type, To = to };
            var json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            content.Headers.Add("Authorization", $"Bearer {authService.TokenResponse.AccessToken}");
            await client.PostAsync("/EmailNotify/push-to-email-queue", content);
        }

        public async Task SendOtpAsync(string code, string to)
        {
            if (authService.TokenResponse == null) return;
            var client = httpClientFactory.CreateClient("NotifyEngine");
            var payload = new NotifyMessage() { Type = "OTP", Body = code, To = to };

            var json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            content.Headers.Add("Authorization", $"Bearer {authService.TokenResponse.AccessToken}");
            await client.PostAsync("/EmailNotify/push-to-email-queue", content);
        }
    }
}
