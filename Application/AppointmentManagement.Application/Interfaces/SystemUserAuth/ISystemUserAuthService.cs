using AppointmentManagement.Application.Interfaces.SystemUserAuth.DTOs;

namespace AppointmentManagement.Application.Interfaces.SystemUserAuth
{
    public interface ISystemUserAuthService
    {
        Task<string> LoginAsync(LoginCMD cmd);
        Task ChangePasswordAsync(ChangePasswordCMD cmd);
    }
}
