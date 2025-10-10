namespace AppointmentManagement.Domain.DoctorSchedules
{
    public class DoctorOverrideSchedule: ScheduleTemplate
    {
        public string Reason { get; private set; }
        public long DoctorId { get; set; }

        public DoctorOverrideSchedule()
        {
            
        }
        public DoctorOverrideSchedule(SchaduleStartDate schaduleStartDate, List<WeeklySchedule> weeklySchedules,string reason) :
            base(schaduleStartDate, weeklySchedules)
        {
            Reason = reason;
        }

    }
}
