using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Domain.DoctorSchedules
{
    public class DoctorDefaultSchedule: ScheduleTemplate
    {
        public long DoctorId { get; set; }

        public DoctorDefaultSchedule(SchaduleStartDate schaduleStartDate, List<WeeklySchedule> weeklySchedules):
            base(schaduleStartDate, weeklySchedules)
        {
           
        }
        public DoctorDefaultSchedule()
        {
            
        }
    }
}
