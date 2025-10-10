namespace AppointmentManagement.Domain.Exceptions
{
    public class CanNotRemoveExpireDoctorTemproryScheduleOverrideException : DomaiException
    {
        public CanNotRemoveExpireDoctorTemproryScheduleOverrideException()
            : base($"Can not remove expire doctorTemproryScheduleOverride.")
        {
        }
    }
    public class SchaduleStartDateShouldBeLaterThanTodayException : DomaiException
    {
        public SchaduleStartDateShouldBeLaterThanTodayException()
            : base($"WeekStartDate should be earlier than today.")
        {
        }
    }
    public class SchaduleStartDateShouldBeSaturdayException : DomaiException
    {
        public SchaduleStartDateShouldBeSaturdayException()
            : base($"WeekStartDate should be saturday.")
        {
        }
    }
}
