using AppointmentManagement.Application.Interfaces.Doctors;
using AppointmentManagement.Application.Interfaces.Doctors.DTOs;
using AppointmentManagement.Application.Interfaces.DoctorSchedules;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentManagement.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorScheduleController(IDoctorScheduleService _service) : ControllerBase
    {
        [HttpGet("{Current-week-schedule-by-doctorId}")]
        public async Task<IActionResult> GetCurrentWeekScheduleByDoctorId(long doctorId)
        {
            var result = await _service.GetCurrentWeekScheduleByDoctorId(doctorId);
            return Ok(result);
        }
    }
}
