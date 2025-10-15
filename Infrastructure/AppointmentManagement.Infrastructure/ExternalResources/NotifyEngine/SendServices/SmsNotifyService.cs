using System.Text.Json;
using System.Text;
using System.Runtime;
using AppointmentManagement.Application.Interfaces.Notify;
using AppointmentManagement.Infrastructure.ExternalResources.NotifyEngine.AuthServices;

namespace AppointmentManagement.Infrastructure.ExternalResources.NotifyEngine.SendServices
{

    public class SmsNotifyService(IHttpClientFactory httpClientFactory, IAuthService authService) : INotifyService
    {
        public async Task SendAsync(string type, string to)
        {
            var payload = new NotifyMessage() { Type = type, To = to };
            await PostAsync(payload);
        }

        public async Task SendOtpAsync(string code, string to)
        {
            var payload = new NotifyMessage() { Type = "OTP", Body = code, To = to };
            await PostAsync(payload);
        }

        private async Task PostAsync(NotifyMessage payload)
        {
            if (authService.TokenResponse == null) return;
            var client = httpClientFactory.CreateClient("NotifyEngine");
            var json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            content.Headers.Add("Authorization", $"Bearer {authService.TokenResponse.AccessToken}");
            await client.PostAsync("/SmsNotify/push-to-sms-queue", content);
        }
    }
}
