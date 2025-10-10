using AppointmentManagement.Application.Interfaces.SystemUserAuth;
using AppointmentManagement.Application.Interfaces.SystemUserAuth.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemUserAuthController(ISystemUserAuthService _services) : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginCMD cmd)
        {
            var token = await _services.LoginAsync(cmd);
            return Ok(new { token = token });
        }
        [HttpPost("Change-password")]
        public async Task<IActionResult> ChangePasswordAsync(ChangePasswordCMD cmd)
        {
            await _services.ChangePasswordAsync(cmd);
            return Ok(new { message = "Password changed successfully." });
        }
    }
}
