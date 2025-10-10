
using AppointmentManagement.Api.ExternalResources.SmsNotifyEngine.AuthServices;

namespace AppointmentManagement.Api.BackgroundServices
{
    public class NotifyEngineAuthenticateProcessor(IAuthService tokenService) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                //await tokenService.AuthenticateAsync();
                while (!stoppingToken.IsCancellationRequested)
                {
                    //await tokenService.RefreshTokenAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
            Task.Delay(30000000, stoppingToken).Wait();// wait for 30 min
        }
    }
}
