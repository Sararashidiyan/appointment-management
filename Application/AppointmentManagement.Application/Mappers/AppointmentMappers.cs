using AppointmentManagement.Application.Interfaces.Appointments.DTOs;
using AppointmentManagement.Domain.Appointments;

namespace AppointmentManagement.Application.Mappers
{
    public class AppointmentMappers
    {
        public static List<AppointmentDTO>? Map(List<Appointment> appointments)
        {
            return appointments?.Select(Map).ToList();
        }
        public static AppointmentDTO Map(Appointment appointment)
        {
            return new AppointmentDTO
            {
                CustomerId = appointment.CustomerId,
                CustomerFullName = appointment.CustomerFullName,
                DayOfWeek = appointment.DayOfWeek,
                DueDate = appointment.DueDateTime.Value.Date,
                DueTime = appointment.DueDateTime.Value.TimeOfDay,
            };
        }
       
    }
}
