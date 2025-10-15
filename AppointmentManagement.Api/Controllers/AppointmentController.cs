using System.Runtime.InteropServices;
using AppointmentManagement.Application.Interfaces.Appointments;
using AppointmentManagement.Application.Interfaces.Appointments.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentManagement.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController(IAppointmentService _service) : ControllerBase
    {
        [HttpPost()]
        public async Task<IActionResult> Create(CreateAppointmentCMD cmd)
        {
           await _service.Create(cmd);
            return Ok(new {message="appointment created sucessfully"});
        }
        [HttpPatch("Compelete")]
        public async Task<IActionResult> Compelete(long id)
        {
            await _service.Compelete(id);
            return Ok(new { message = "appointment compeleted sucessfully" });
        }
        [HttpPatch("Reject")]
        public async Task<IActionResult> Reject(long id, string reseon)
        {
            await _service.Reject(id,reseon);
            return Ok(new { message = "appointment rejected sucessfully" });
        }
        [HttpPatch("Cancel-by-doctor")]
        public async Task<IActionResult> CancelByDoctor(long id, string reseon)
        {
            await _service.CancelByDoctor(id,reseon);
            return Ok(new { message = "appointment Cancelled by doctor sucessfully" });
        }
        [HttpPatch("NoShow")]
        public async Task<IActionResult> NoShow(long id)
        {
            await _service.NoShow(id);
            return Ok(new { message = "appointment noShow sucessfully" });
        }
       
        [HttpPatch("Doctor-appointments")]
        public async Task<IActionResult> GetDoctorAppointments(int stateId,DateTime? fromdate,DateTime? todate)
        {
           var appointmets= await _service.GetDoctorAppointments(stateId, fromdate, todate);
            return Ok(new { appointmets });

        }
        [HttpPatch("Cancel-by-patient")]
         public async Task<IActionResult> CancelByPatient(long id)
        {
            await _service.CancelByPatient(id);
            return Ok(new { message = "appointment Cancelled by patient sucessfully" });

        }
    }
}
