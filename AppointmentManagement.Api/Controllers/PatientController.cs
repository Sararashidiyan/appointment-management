using AppointmentManagement.Application.Interfaces.Patients;
using AppointmentManagement.Application.Interfaces.Patients.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentManagement.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController(IPatientService _service) : ControllerBase
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
        [HttpGet("Profile")]
        public async Task<IActionResult> Profile()
        {
            var result = await _service.Profile();
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Modify(ModifyPatientCMD cmd)
        {
            await _service.Modify(cmd);
            return Ok(new { message = "user modify sucessfully" });
        }
    }
}
