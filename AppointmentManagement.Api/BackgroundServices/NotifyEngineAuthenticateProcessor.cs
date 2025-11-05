using AppointmentManagement.Infrastructure.ExternalResources.NotifyEngine.AuthServices;

namespace AppointmentManagement.Api.BackgroundServices
{
    public class NotifyEngineAuthenticateProcessor(IAuthService tokenService) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await tokenService.AuthenticateAsync();
            Task.Delay(30000000, stoppingToken).Wait();// wait for 30 min
            while (!stoppingToken.IsCancellationRequested)
            {
                await tokenService.RefreshTokenAsync();
                Task.Delay(30000000, stoppingToken).Wait();// wait for 30 min
            }

            
        }
    }
}
