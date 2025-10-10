using AppointmentManagement.Application.Interfaces.DoctorSchedules.DTOs.DoctorSchedule;
using AppointmentManagement.Domain;
using AppointmentManagement.Domain.Appointments;
using AppointmentManagement.Domain.DoctorSchedules;

namespace AppointmentManagement.Application.Mappers
{
    public class DoctorScheduleMappers
    {
        public static List<DoctorScheduleDTO> Map(List<Appointment> appointments, ScheduleTemplate scheduleTemplate)
        {
            throw new NotImplementedException();
        }
        public static DoctorDefaultScheduleDTO Map(DoctorDefaultSchedule defaultSchedule)
        {
            return new DoctorDefaultScheduleDTO
            {

            };
        }

        public static DoctorOverrideScheduleDTO Map(DoctorOverrideSchedule overrideSchedule)
        {
            return new DoctorOverrideScheduleDTO
            {

            };
        }
        public static List<DoctorDefaultScheduleDTO> Map(List<DoctorDefaultSchedule> defaultSchedules)
        {
            return defaultSchedules?.Select(Map).ToList();
        }

        public static List<DoctorOverrideScheduleDTO> Map(List<DoctorOverrideSchedule> overrideSchedules)
        {
            return overrideSchedules?.Select(Map).ToList();

        }
    }
}
