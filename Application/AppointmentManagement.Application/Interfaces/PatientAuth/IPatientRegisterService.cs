
using AppointmentManagement.Application.Interfaces.Patients.DTOs;

namespace AppointmentManagement.Application.Interfaces.PatientAuth
{
    public interface IPatientRegisterService
    {
         Task<string> Register(CreatePatientCMD item);
    }
}
