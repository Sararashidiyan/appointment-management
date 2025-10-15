using AppointmentManagement.Application.Interfaces.Appointments.DTOs;

namespace AppointmentManagement.Application.Interfaces.Appointments
{
    public interface IAppointmentService
    {
        Task CancelByDoctor(long id, string reseon);
        Task CancelByPatient(long id);
        Task Compelete(long id);
        Task Create(CreateAppointmentCMD cmd);
        Task Reject(long id, string reseon);
        Task NoShow(long id);
        Task<List<AppointmentDTO>> GetDoctorAppointments(int stateId, DateTime? fromdate, DateTime? todate);
    }
}
