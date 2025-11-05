using AppointmentManagement.Application.Interfaces.Patients;
using AppointmentManagement.Application.Interfaces.Patients.DTOs;
using AppointmentManagement.Application.Interfaces.SystemUserAuth;
using AppointmentManagement.Application.Mappers;
using AppointmentManagement.Domain.Patients;
using AppointmentManagement.Domain.Users;

namespace AppointmentManagement.Application
{
    public class PatientService(IPatientRepository _repository,ICurrentUserService currentUserService) : IPatientService
    {
        public async Task<List<PatientDTO>> GetAll()
        {
            var patients = await _repository.GetAllAsync();
            return PatientMappers.Map(patients);
        }

        public async Task<PatientDTO> GetById(long id)
        {
            var patient = await _repository.GetByIdAsync(id);
            GuardAgainstNullValue(patient);
            return PatientMappers.Map(patient);
        }

        public async Task Modify(ModifyPatientCMD item)
        {
            var patient = await _repository.GetByIdAsync(item.Id);
            GuardAgainstNullValue(patient);
            var email = new Email(item.Email);
            var nationalCode = new NationalCode(item.NationalCode);
            patient.Update(item.FirstName, item.LastName, email, nationalCode);
        }

        public async Task<PatientDTO> Profile()
        {
            var userId = currentUserService.UserId;
            var patient = await _repository.GetByIdAsync(userId);
            GuardAgainstNullValue(patient);
            return PatientMappers.Map(patient);
        }

        private void GuardAgainstNullValue(Patient patient)
        {
            if (patient == null)
                throw new DirectoryNotFoundException();
        }
    }


}
