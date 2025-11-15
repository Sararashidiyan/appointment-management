using AppointmentManagement.Query.Application.Interfaces.Doctors.Data;
using AppointmentManagement.Query.Application.Interfaces.DoctorSchadules;
using AppointmentManagement.Query.Application.Interfaces.DoctorSchadules.Data;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentManagement.Query.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorScheduleQueryController(IDoctorScheduleService doctorScheduleService) : ControllerBase
    {
        [HttpGet("weekly-schedule")]
        public async Task<List<DoctorScheduleData>> GetCurrentWeekScheduleByDoctorId(long doctorId)
        {
            return await doctorScheduleService.GetCurrentWeekScheduleByDoctorId(doctorId);
        }
    }
}
