using AppointmentManagement.Application.Interfaces.PatientAuth;
using AppointmentManagement.Application.Interfaces.PatientAuth.DTOs;
using AppointmentManagement.Application.Interfaces.Patients.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IPatientAuthService _patientAuthService) : ControllerBase
    {

        [HttpPost("otp-request")]
        public async Task<IActionResult> OtpRequest([FromBody]string mobile)
        {
            await _patientAuthService.SendOtp(mobile);
            return Ok("send otp code");
        }
        [HttpPost("verify")]
        public async Task<IActionResult> Auth([FromBody] VerifyCodeRequest verifyCodeRequest)
        {
            var token = await _patientAuthService.AuthAsync(verifyCodeRequest.Mobile, verifyCodeRequest.Code);
            if (string.IsNullOrEmpty(token))
                return Ok(new { Unauthorized = true, message = "redirect to register" });
            return Ok(new { Unauthorized = false, token, message = "user login successfully" });
        }
       
    }
}
