using AppointmentManagement.Application.Interfaces.DoctorSchedules.DTOs.DoctorSchedule;

namespace AppointmentManagement.Application.Interfaces.DoctorSchedules
{
    public interface IDoctorScheduleService
    {
        Task<List<DoctorScheduleDTO>> GetCurrentWeekScheduleByDoctorId(long doctorId);
    }
}
