using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagement.Domain.Appointments;

namespace AppointmentManagement.Application.Interfaces.Appointments.DTOs
{
    public class CreateAppointmentCMD
    {
        public long DoctorExpertId { get; private set; }
        public string DayOfWeek { get;  set; }
        public DateTime DueDateTime { get;  set; }
    }
}
