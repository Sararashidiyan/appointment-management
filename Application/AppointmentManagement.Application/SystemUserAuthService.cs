using AppointmentManagement.Application.Interfaces.SystemUserAuth;
using AppointmentManagement.Application.Interfaces.SystemUserAuth.DTOs;
using AppointmentManagement.Domain.JwtTokenGenerator;
using AppointmentManagement.Domain.SystemUsers;

namespace AppointmentManagement.Application
{
    public class SystemUserAuthService(ISystemUserRepository _repository,IJwtTokenGenerator _jwtTokenGenerator) : ISystemUserAuthService
    {
        public async Task ChangePasswordAsync(ChangePasswordCMD cmd)
        {
            var user = await _repository.FindByEmail(cmd.Email);
            if (user == null)
                throw new DirectoryNotFoundException();
            if (!user.VerifyPassword(cmd.CurrentPassword))
                throw new UnauthorizedAccessException();
            user.CreatePasswordHash(cmd.NewPassword);
        }

        public async Task<string> LoginAsync(LoginCMD cmd)
        {
            var user =await _repository.FindByEmail(cmd.Email);
            if (user == null)
                throw new DirectoryNotFoundException();
            var isVerified=  user.VerifyPassword(cmd.Password);
            if (!isVerified)
                throw new UnauthorizedAccessException();
            return _jwtTokenGenerator.GenerateUserToken(user);
        }
    }
}
