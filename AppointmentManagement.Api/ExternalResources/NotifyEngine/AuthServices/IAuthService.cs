namespace AppointmentManagement.Api.ExternalResources.SmsNotifyEngine.AuthServices
{
    public interface IAuthService
    {
        TokenResponse? TokenResponse { get; set; }
        Task AuthenticateAsync();
        Task RefreshTokenAsync();
    }
}
