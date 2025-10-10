using AppointmentManagement.Application.Interfaces.DoctorSchedules.DTOs.DoctorSchedule;
using AppointmentManagement.Application.Interfaces.DoctorSchedules.DTOs.OverrideSchedule;

namespace AppointmentManagement.Application.Interfaces.DoctorSchedules
{
    public interface IDoctorOverrideScheduleService
    {
        Task<List<DoctorScheduleDTO>> GetCurrentWeekScheduleByDoctorId(long doctorId);
        Task<OverrideScheduleDTO> GetById(long id);
        Task<List<OverrideScheduleDTO>> GetAll();
        Task Create(CreateOverrideScheduleCMD cmd);
        Task Modify(ModifyOverrideScheduleCMD cmd);
        Task Delete(long id);
        Task Publish(long id);
        Task<List<DoctorOverrideScheduleDTO>> GetDoctorOverrideSchedules(long doctorId);
    }
}
