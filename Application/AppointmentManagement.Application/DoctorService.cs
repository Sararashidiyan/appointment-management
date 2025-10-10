using AppointmentManagement.Application.Interfaces.Doctors;
using AppointmentManagement.Application.Interfaces.Doctors.DTOs;
using AppointmentManagement.Application.Interfaces.SystemUserAuth;
using AppointmentManagement.Application.Mappers;
using AppointmentManagement.Domain.Doctors;
using AppointmentManagement.Domain.SystemUsers;
using AppointmentManagement.Domain.Users;
using System.Numerics;

namespace AppointmentManagement.Application
{
    public class DoctorService(ICurrentUserService currentUserService,IDoctorRepository _repository) : IDoctorService
    {
        public async Task Activate(long id)
        {
            var doctor = await _repository.GetByIdAsync(id);
            GuardAgainstNullValue(doctor);
            doctor.Activate();
        }

        public async Task Create(CreateDoctorCMD item)
        {
            var mobile = new Mobile(item.Mobile);
            var email = new Email(item.Email);
            var systemUser = new Doctor(item.FirstName, item.LastName, email, mobile, item.Password);
            await _repository.CreateAsync(systemUser);
        }

        public async Task Deactivate(long id)
        {
            var doctor = await _repository.GetByIdAsync(id);
            GuardAgainstNullValue(doctor);
            doctor.Deactivate();
        }

        public async Task Delete(long id)
        {
            var doctor = await _repository.GetByIdAsync(id);
            GuardAgainstNullValue(doctor);
            await _repository.DeleteAsync(doctor);
        }

        public async Task<List<DoctorDTO>> GetAll()
        {
            var doctors = await _repository.GetAllAsync();
            return DoctorMappers.Map(doctors);
        }

        public async Task<DoctorDTO> GetById(long id)
        {
            var doctor = await _repository.GetByIdAsync(id);
            GuardAgainstNullValue(doctor);
            return DoctorMappers.Map(doctor);
        }
        public async Task<DoctorDTO> Profile()
        {
            var userId = currentUserService.UserId;
            var doctor = await _repository.GetByIdAsync(userId);
            GuardAgainstNullValue(doctor);
            return DoctorMappers.Map(doctor);
        }

        public async Task Modify(ModifyDoctorCMD item)
        {
            var userId = currentUserService.UserId;
            var doctor = await _repository.GetByIdAsync(userId);
            GuardAgainstNullValue(doctor);
            var mobile = new Mobile(item.Mobile);
            doctor.Update(item.FirstName,item.LastName, mobile);
        }
        private void GuardAgainstNullValue(Doctor doctor)
        {
            if (doctor == null)
                throw new DirectoryNotFoundException();
        }
    }


}
