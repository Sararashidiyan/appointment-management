using AppointmentManagement.Application.Interfaces.PatientAuth;
using AppointmentManagement.Application.Interfaces.Patients.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IPatientAuthService _patientAuthService) : ControllerBase
    {

        [HttpPost("Otp-request")]
        public async Task<IActionResult> OtpRequest(string mobile)
        {
            await _patientAuthService.SendOtp(mobile);
            return Ok("send otp code");
        }
        [HttpPost("Auth")]
        public async Task<IActionResult> Auth(string mobile, string code)
        {
            var token = await _patientAuthService.AuthAsync(mobile, code);
            if (string.IsNullOrEmpty(token))
                return Ok(new { Unauthorized = true, message = "redirect to register" });
            return Ok(new { Unauthorized = false, token, message = "user login successfully" });
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(CreatePatientCMD item)
        {
            var token = await _patientAuthService.Register(item);
            return Ok(new { token, message = "user register successfully" });
        }
    }
}
