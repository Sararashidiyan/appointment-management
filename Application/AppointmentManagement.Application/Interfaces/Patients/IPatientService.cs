using AppointmentManagement.Application.Interfaces.Patients.DTOs;
using AppointmentManagement.Domain.Users;

namespace AppointmentManagement.Application.Interfaces.Patients
{
    public interface IPatientService
    {
        Task<PatientDTO> GetById(long id);
        Task<PatientDTO> Profile();
        Task<List<PatientDTO>> GetAll();
        Task Create(CreatePatientCMD id);
        Task Modify(ModifyPatientCMD id);
    }
}
