using AppointmentManagement.Application.Interfaces.DoctorSchedules;
using AppointmentManagement.Application.Interfaces.DoctorSchedules.DTOs.OverrideSchedule;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorOverrideScheduleController(IDoctorOverrideScheduleService _service) : ControllerBase
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
        public async Task<IActionResult> Create(CreateOverrideScheduleCMD cmd)
        {
            await _service.Create(cmd);
            return Ok(new { message = "OverrideSchadule created sucessfully" });
        }
        [HttpPut]
        public async Task<IActionResult> Modify(ModifyOverrideScheduleCMD cmd)
        {
            await _service.Modify(cmd);
            return Ok(new { message = "OverrideSchadule modify sucessfully" });
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok(new { message = "OverrideSchadule delete sucessfully" });
        }
        [HttpPatch("{id}/publish")]
        public async Task<IActionResult> Publish(int id)
        {
            await _service.Publish(id);
            return Ok(new { message = "OverrideSchadule publish sucessfully" });
        }
    }
}
