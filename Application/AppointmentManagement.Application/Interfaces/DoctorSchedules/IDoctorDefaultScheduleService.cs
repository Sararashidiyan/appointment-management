using AppointmentManagement.Application.Interfaces.DoctorSchedules.DTOs.DefaultSchedule;
using AppointmentManagement.Application.Interfaces.DoctorSchedules.DTOs.DoctorSchedule;

namespace AppointmentManagement.Application.Interfaces.DoctorSchedules
{
    public interface IDoctorDefaultScheduleService
    {
        Task<DefaultScheduleDTO> GetById(long id);
        Task<List<DefaultScheduleDTO>> GetAll();
        Task Create(CreaterDefaultScheduleCMD cmd);
        Task Modify(ModifyDefaultScheduleCMD cmd);
        Task Delete(long id);
        Task Publish(long id);
        Task<List<DoctorDefaultScheduleDTO>> GetDoctorDefaultSchedules(long doctorId);
    }
}
