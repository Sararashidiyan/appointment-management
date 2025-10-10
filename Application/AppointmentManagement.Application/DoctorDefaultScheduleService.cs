using AppointmentManagement.Application.Interfaces.DoctorSchedules;
using AppointmentManagement.Application.Interfaces.DoctorSchedules.DTOs.DefaultSchedule;
using AppointmentManagement.Application.Interfaces.DoctorSchedules.DTOs.DoctorSchedule;
using AppointmentManagement.Application.Mappers;
using AppointmentManagement.Domain.DoctorSchedules;

namespace AppointmentManagement.Application
{
    public class DoctorDefaultScheduleService(IDoctorDefaultScheduleRepository _defaultScheduleRepository) : IDoctorDefaultScheduleService
    {
        public Task Create(CreaterDefaultScheduleCMD cmd)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<DefaultScheduleDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<DefaultScheduleDTO> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DoctorDefaultScheduleDTO>> GetDoctorDefaultSchedules(long doctorId)
        {
            var overrideSchedule = await _defaultScheduleRepository.getAllByDoctorId(doctorId);
            return DoctorScheduleMappers.Map(overrideSchedule);

        }

        public Task Modify(ModifyDefaultScheduleCMD cmd)
        {
            throw new NotImplementedException();
        }

        public Task Publish(long id)
        {
            throw new NotImplementedException();
        }
    }
}
