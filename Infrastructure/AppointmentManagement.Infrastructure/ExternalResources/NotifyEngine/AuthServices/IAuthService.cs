namespace AppointmentManagement.Infrastructure.ExternalResources.NotifyEngine.AuthServices
{
    public interface IAuthService
    {
        TokenResponse? TokenResponse { get; set; }
        Task AuthenticateAsync();
        Task RefreshTokenAsync();
    }
}
