using AppointmentManagement.Query.Application.Interfaces.Doctors;
using AppointmentManagement.Query.Application.Interfaces.Doctors.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentManagement.Query.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorQueryController(IDoctorQueryService doctorQueryService) : ControllerBase
    {
        [HttpGet("by-city")]
        public async Task<List<DoctorExpertData>> GetDoctorExpertsByCity(string city)
        {
            return await doctorQueryService.GetDoctorExpertsByCity(city);
        }
    }
}
