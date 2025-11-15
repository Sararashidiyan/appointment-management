using AppointmentManagement.Query.Application.Interfaces.DoctorSchadules.Data;

namespace AppointmentManagement.Query.Application.Interfaces.DoctorSchadules
{
    public interface IDoctorScheduleService
    {
        Task<List<DoctorScheduleData>> GetCurrentWeekScheduleByDoctorId(long doctorId);
    }
}
