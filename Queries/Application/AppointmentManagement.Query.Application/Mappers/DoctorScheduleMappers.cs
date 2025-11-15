
using AppointmentManagement.Domain;
using AppointmentManagement.Domain.Appointments;
using AppointmentManagement.Domain.DoctorSchedules;
using AppointmentManagement.Query.Application.Interfaces.DoctorSchadules.Data;
using static System.Reflection.Metadata.BlobBuilder;

namespace AppointmentManagement.Query.Application.Mappers
{
    public class DoctorScheduleMappers
    {
        public static List<DoctorScheduleData> Map(List<Appointment> appointments, ScheduleTemplate scheduleTemplate)
        {
            var schadules = new List<DoctorScheduleData>();
            var interval = TimeSpan.FromMinutes(30);
            foreach (var weeklySchedule in scheduleTemplate.WeeklySchedules)
            {
                var schadule = new DoctorScheduleData { DayOfWeek = weeklySchedule.DayOfWeek };
                foreach (var timeSlot in weeklySchedule.TimeSlot)
                {
                    for (var time = timeSlot.FromHour; time < timeSlot.ToHour; time += interval)
                    {
                        var timeSlotData = new TimeSlotData() { FromHour = time, ToHour = (time + interval) };
                        var matchedAppointment = appointments.Any(a =>
                        a.DayOfWeek == weeklySchedule.DayOfWeek
                        && a.DueDateTime.Value.TimeOfDay == timeSlotData.FromHour);
                        timeSlotData.Booked = matchedAppointment;
                        schadule.TimeSlots.Add(timeSlotData);
                    }
                }
                schadules.Add(schadule);
            }
            return schadules;
        }

    }
}
