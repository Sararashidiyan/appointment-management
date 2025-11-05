namespace AppointmentManagement.Domain.Exceptions
{
    public class ScheduleTimeSlotOverlapException : DomaiException
    {
        public ScheduleTimeSlotOverlapException():base("ScheduleTimeSlot overlap.") { }
    }
}
