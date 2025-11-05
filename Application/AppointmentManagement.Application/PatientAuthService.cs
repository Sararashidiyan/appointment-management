using AppointmentManagement.Application.Interfaces.Notify;
using AppointmentManagement.Application.Interfaces.PatientAuth;
using AppointmentManagement.Domain.JwtTokenGenerator;
using AppointmentManagement.Domain.OTPGenerator;
using AppointmentManagement.Domain.Patients;

namespace AppointmentManagement.Application
{
    public class PatientAuthService(INotifyService _notifyService, IPatientRepository _repository,
        IJwtTokenGenerator _jwtTokenGenerator,IOtpGenerator _otpGenerator) : IPatientAuthService
    {
        public async Task SendOtp(string mobile)
        {
            var otp = _otpGenerator.GenerateOtp(mobile);
            await _notifyService.SendOtpAsync(otp, mobile);
        }

        public async Task<string> AuthAsync(string mobile, string otpCode)
        {
            bool isValid = _otpGenerator.ValidateOtp(mobile, otpCode);
            if(!isValid) return "";
            var user = await _repository.FindByMobile(mobile);
            if (user == null)
                return "";
            return _jwtTokenGenerator.GeneratePatientToken(user);
        }
    }

}
