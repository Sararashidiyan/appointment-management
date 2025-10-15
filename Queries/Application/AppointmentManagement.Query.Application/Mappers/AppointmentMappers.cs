using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagement.Core;
using AppointmentManagement.Domain.Appointments;
using AppointmentManagement.Domain.Appointments.AppointmentStates;
using AppointmentManagement.Query.Application.Interfaces.Appointments.Data;

namespace AppointmentManagement.Query.Application.Mappers
{
    public class AppointmentMappers
    {
        public static AppointmentData? Map(Appointment appointment)
        {
            if (appointment == null) return null;
            return new AppointmentData
            {
                DayOfWeek= appointment.DayOfWeek,
                DueDate=appointment.DueDateTime.Value.ToPersianDate(),
                DueTime=appointment.DueDateTime.Value.TimeOfDay.ToString(),
                ChangeStateAt=appointment.ChangeStateAt==null?"":appointment.ChangeStateAt.Value.ToPersianDate(),
                CreatedAt=appointment.CreatedAt.ToPersianDate(),
                //State=(AppointmentState)appointment.StateId,
                StateReseon=appointment.StateReseon,
            };
        }
        public static List<AppointmentData>? Map(List<Appointment> appointments)
        {
            return appointments?.Select(Map).ToList();
        }
    }
}
