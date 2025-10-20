using AppointmentManagement.Api.Authorization;
using AppointmentManagement.Application.Interfaces.Doctors;
using AppointmentManagement.Application.Interfaces.Doctors.DTOs;
using AppointmentManagement.Domain.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentManagement.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController(IDoctorService _service) : ControllerBase
    {
        [HttpGet("{id}")]
        [PanelPermission(PanelPermissionEnum.ViewDoctors)]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _service.GetById(id);
            return Ok(result);
        }
        [HttpGet()]
        [PanelPermission(PanelPermissionEnum.ViewDoctors)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAll();
            return Ok(result);
        }
        [HttpPost()]
        [PanelPermission(PanelPermissionEnum.CreateDoctor)]
        public async Task<IActionResult> Create(CreateDoctorCMD cmd)
        {
           await _service.Create(cmd);
            return Ok(new { message = "doctor created sucessfully" });
        }
        [HttpPut]
        [DoctorPermission(DoctorPermissionEnum.UpdateProfile)]
        public async Task<IActionResult> Modify(ModifyDoctorCMD cmd)
        {
            await _service.Modify(cmd);
            return Ok(new { message = "doctor modify sucessfully" });
        }
        [HttpDelete("{id}")]
        [PanelPermission(PanelPermissionEnum.DeleteDoctor)]
        public async Task<IActionResult> Delete(long id)
        {
            await _service.Delete(id);
            return Ok(new { message = "doctor delete sucessfully" });
        }
        [HttpPatch("{id}/activate")]
        [PanelPermission(PanelPermissionEnum.ActivateDoctors)]
        public async Task<IActionResult> Activate(long id)
        {
            await _service.Activate(id);
            return Ok(new { message = "doctor activate sucessfully" });
        }
        [HttpPatch("{id}/deactivate")]
        [PanelPermission(PanelPermissionEnum.DeactivateDoctors)]
        public async Task<IActionResult> Deactivate(long id)
        {
            await _service.Deactivate(id);
            return Ok(new { message = "doctor deactivate sucessfully" });
        }
    }
}
