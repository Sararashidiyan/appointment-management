using AppointmentManagement.Query.Application;
using AppointmentManagement.Query.Application.Interfaces.Appointments.Data;
using AppointmentManagement.Query.Application.Interfaces.Patients.Data;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentManagement.Query.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientQueryController(PatientQueryService patientQueryService) : ControllerBase
    {
        [HttpGet("profile")]
        public async Task<PatientData> Profile()
        {
            return await patientQueryService.Profile();
        }
        [HttpGet("appointments")]
        public async Task<List<AppointmentData>> GetPatientAppointments()
        {
            return await patientQueryService.GetPatientAppointments();
        }
    }
}
