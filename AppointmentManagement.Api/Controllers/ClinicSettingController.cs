using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppointmentManagement.Application.Interfaces.ClinicSettings;
using AppointmentManagement.Application.Interfaces.ClinicSettings.DTOs;
using AppointmentManagement.Api.Authorization;
using AppointmentManagement.Domain.Authorization;

namespace AppointmentManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicSettingController(IClinicSettingService _service) : ControllerBase
    {
        [HttpGet("{id}")]
        [PanelPermission(PanelPermissionEnum.ViewlinicSetting)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetById(id);
            return Ok(result);
        }
        [HttpPut]
        [PanelPermission(PanelPermissionEnum.UpdateClinicSetting)]
        public async Task<IActionResult> Modify(ModifyClinicSettingCMD cmd)
        {
            await _service.Modify(cmd);
            return Ok(new { message = "clinicSetting modify sucessfully" });
        }

    }
}
