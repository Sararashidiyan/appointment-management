
using AppointmentManagement.Query.Application.Interfaces.DoctorSchedules.Data;

namespace AppointmentManagement.Application.Interfaces.DoctorSchedules
{
    public interface IDoctorScheduleService
    {
        Task<List<DoctorScheduleData>> GetCurrentWeekScheduleByDoctorId(long doctorId);
    }
}
