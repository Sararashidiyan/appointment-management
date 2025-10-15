using AppointmentManagement.Application.Interfaces.DoctorSchedules;
using AppointmentManagement.Application.Interfaces.DoctorSchedules.DTOs.DoctorSchedule;
using AppointmentManagement.Application.Interfaces.DoctorSchedules.DTOs.OverrideSchedule;
using AppointmentManagement.Application.Mappers;
using AppointmentManagement.Domain;
using AppointmentManagement.Domain.DoctorSchedules;
using AppointmentManagement.Domain.Experts;

namespace AppointmentManagement.Application
{
    public class DoctorOverrideScheduleService(IDoctorOverrideScheduleRepository _repository) : IDoctorOverrideScheduleService
    {
        public async Task Create(CreateOverrideScheduleCMD cmd)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(long id)
        {
            var overrideSchedule = await _repository.GetByIdAsync(id);
            GuardAgainstNullValue(overrideSchedule);
            await _repository.DeleteAsync(overrideSchedule);
        }

        public async Task<List<OverrideScheduleDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<OverrideScheduleDTO> GetById(long id)
        {
            var overrideSchedule = await _repository.GetByIdAsync(id);
            GuardAgainstNullValue(overrideSchedule);
            throw new NotImplementedException();
        }
        public async Task<List<DoctorOverrideScheduleDTO>> GetDoctorOverrideSchedules(long doctorId)
        {
            var defaultSchedule = await _repository.getAllByDoctorId(doctorId);
            return DoctorScheduleMappers.Map(defaultSchedule);
        }

        public async Task Modify(ModifyOverrideScheduleCMD cmd)
        {
            var overrideSchedule = await _repository.GetByIdAsync(cmd.Id);
            GuardAgainstNullValue(overrideSchedule);
            throw new NotImplementedException();
        }

        public async Task Publish(long id)
        {
            var overrideSchedule = await _repository.GetByIdAsync(id);
            GuardAgainstNullValue(overrideSchedule);
            overrideSchedule.Publish();
        }
        private void GuardAgainstNullValue(DoctorOverrideSchedule overrideSchedule)
        {
            if (overrideSchedule == null)
                throw new DirectoryNotFoundException();
        }
    }
}
