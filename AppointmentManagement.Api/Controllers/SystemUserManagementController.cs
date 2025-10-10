using AppointmentManagement.Application.Interfaces.SystemUserManagement;
using AppointmentManagement.Application.Interfaces.SystemUserManagement.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemUserManagementController(ISystemUserManagementService _service) : ControllerBase
    {

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _service.GetById(id);
            return Ok(result);
        }
        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAll();
            return Ok(result);
        }
        [HttpPost()]
        public async Task<IActionResult> Create(CreateSystemUserManagementCMD cmd)
        {
            await _service.Create(cmd);
            return Ok(new { message = "systemUser create sucessfully" });
        }
        [HttpPut]
        public async Task<IActionResult> Modify(ModifySystemUserManagementCMD cmd)
        {
            await _service.Modify(cmd);
            return Ok(new { message = "systemUser modify sucessfully" });
        }
        
        [HttpPatch("{id}/activate")]
        public async Task<IActionResult> Activate(long id)
        {
            await _service.Activate(id);
            return Ok(new { message = "systemUser activate sucessfully" });
        }
        [HttpPatch("{id}/deactivate")]
        public async Task<IActionResult> Deactivate(long id)
        {
            await _service.Deactivate(id);
            return Ok(new { message = "systemUser deactivate sucessfully" });
        }
    }
   
}
