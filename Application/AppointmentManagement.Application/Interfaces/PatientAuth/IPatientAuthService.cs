namespace AppointmentManagement.Application.Interfaces.PatientAuth
{
    public interface IPatientAuthService
    {
        Task<string> AuthAsync(string mobile, string otpCode);
        Task SendOtp(string mobile);
    }
}
