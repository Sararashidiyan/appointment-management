namespace AppointmentManagement.Domain.JwtTokenGenerator
{
    public interface IRefreshTokenStore
    {
        bool IsValid(string refreshToken);
        void Save(string clientId, string refreshToken, DateTime expiresAt);
        void Revoke(string refreshToken);
    }
}
