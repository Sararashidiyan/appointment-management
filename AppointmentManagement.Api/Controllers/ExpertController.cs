using AppointmentManagement.Application.Interfaces.Experts;
using AppointmentManagement.Application.Interfaces.Experts.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentManagement.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ExpertController(IExpertService _service) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
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
        public async Task<IActionResult> Create(CreateExpertCMD cmd)
        {
            await _service.Create(cmd);
            return Ok(new { message = "expert created sucessfully" });
        }
        [HttpPut]
        public async Task<IActionResult> Modify(ModifyExpertCMD cmd)
        {
            await _service.Modify(cmd);
            return Ok(new { message = "expert modify sucessfully" });
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok(new { message = "expert delete sucessfully" });
        }
        [HttpPatch("{id}/activate")]
        public async Task<IActionResult> Activate(int id)
        {
            await _service.Activate(id);
            return Ok(new { message = "expert activate sucessfully" });
        }
        [HttpPatch("{id}/deactivate")]
        public async Task<IActionResult> Deactivate(int id)
        {
            await _service.Deactivate(id);
            return Ok(new { message = "expert deactivate sucessfully" });
        }

    }
}
