using System.Runtime.InteropServices;
using AppointmentManagement.Api.Authorization;
using AppointmentManagement.Application.Interfaces.Appointments;
using AppointmentManagement.Application.Interfaces.Appointments.DTOs;
using AppointmentManagement.Domain.Authorization;
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
        [PatientPermission(PatientPermissionEnum.CreateAppointment)]
        public async Task<IActionResult> Create(CreateAppointmentCMD cmd)
        {
           await _service.Create(cmd);
            return Ok(new {message="appointment created sucessfully"});
        }
        [HttpPatch("Compelete")]
        [DoctorPermission(DoctorPermissionEnum.CompeleteAppointment)]
        public async Task<IActionResult> Compelete(long id)
        {
            await _service.Compelete(id);
            return Ok(new { message = "appointment compeleted sucessfully" });
        }
        [HttpPatch("Reject")]
        [DoctorPermission(DoctorPermissionEnum.RejectAppointment)]
        public async Task<IActionResult> Reject(long id, string reseon)
        {
            await _service.Reject(id,reseon);
            return Ok(new { message = "appointment rejected sucessfully" });
        }
        [HttpPatch("Cancel-by-doctor")]
        [DoctorPermission(DoctorPermissionEnum.CancelAppointment)]
        public async Task<IActionResult> CancelByDoctor(long id, string reseon)
        {
            await _service.CancelByDoctor(id,reseon);
            return Ok(new { message = "appointment Cancelled by doctor sucessfully" });
        }
        [HttpPatch("NoShow")]
        [DoctorPermission(DoctorPermissionEnum.NoShowAppointment)]
        public async Task<IActionResult> NoShow(long id)
        {
            await _service.NoShow(id);
            return Ok(new { message = "appointment noShow sucessfully" });
        }
       
        [HttpPatch("Doctor-appointments")]
        [DoctorPermission(DoctorPermissionEnum.ViewAppointments)]
        public async Task<IActionResult> GetDoctorAppointments(int stateId,DateTime? fromdate,DateTime? todate)
        {
           var appointmets= await _service.GetDoctorAppointments(stateId, fromdate, todate);
            return Ok(new { appointmets });

        }
        [HttpPatch("Cancel-by-patient")]
        [PatientPermission(PatientPermissionEnum.CancelAppointment)]
        public async Task<IActionResult> CancelByPatient(long id)
        {
            await _service.CancelByPatient(id);
            return Ok(new { message = "appointment Cancelled by patient sucessfully" });

        }
    }
}
