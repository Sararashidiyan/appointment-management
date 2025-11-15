using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Query.Application.Interfaces.DoctorSchadules.Data
{
    public class DoctorScheduleData
    {
        public string DayOfWeek { get;  set; }
        public List<TimeSlotData> TimeSlots { get; set; } = []; 
    }
    public class TimeSlotData
    {
        public TimeSpan FromHour { get;  set; }
        public TimeSpan ToHour { get;  set; }
        public bool Booked { get;  set; }
    }
}
