using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagement.Domain.Appointments.AppointmentStates;
using AppointmentManagement.Domain.Appointments;

namespace AppointmentManagement.Query.Application.Interfaces.Appointments.Data
{
    public class AppointmentData
    {
        public string DayOfWeek { get;  set; }
        public string DueDate { get;  set; }
        public string DueTime { get;  set; }
        public string State { get; set; }
        public string StateReseon { get; set; }
        public bool IsExpire { get; set; }
        public string CreatedAt { get; set; }
        public string ChangeStateAt { get; set; }
    }
}
