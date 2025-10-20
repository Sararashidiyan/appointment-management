using AppointmentManagement.Application.Interfaces.Notify;
using AppointmentManagement.Application.Interfaces.PatientAuth;
using AppointmentManagement.Application.Interfaces.Patients;
using AppointmentManagement.Application.Interfaces.Patients.DTOs;
using AppointmentManagement.Domain.JwtTokenGenerator;
using AppointmentManagement.Domain.SystemUsers;

namespace AppointmentManagement.Application
{
    public class PatientAuthService(INotifyService _notifyService, ISystemUserRepository _repository,
        IJwtTokenGenerator _jwtTokenGenerator, IPatientService _patientService) : IPatientAuthService
    {
        public async Task SendOtp(string mobile)
        {
            var otp = OtpManager.GenerateOtp(mobile);
            await _notifyService.SendOtpAsync(otp, mobile);
        }

        public async Task<string> AuthAsync(string mobile, string otpCode)
        {
            var isOtpValid = OtpManager.ValidateOtp(mobile, otpCode);
            if (!isOtpValid) throw new UnauthorizedAccessException();
            var user = await _repository.FindByMobile(mobile);
            if (user == null)
                return "";
            return _jwtTokenGenerator.GeneratePatientToken(user);
        }

        public async Task<string> Register(CreatePatientCMD item)
        {
            await _patientService.Create(item);
            var user = await _repository.FindByMobile(item.Mobile);
            return _jwtTokenGenerator.GeneratePatientToken(user);
        }
    }

}
