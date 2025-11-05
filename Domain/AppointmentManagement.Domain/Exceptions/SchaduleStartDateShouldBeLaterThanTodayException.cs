namespace AppointmentManagement.Domain.Exceptions
{
    public class SchaduleStartDateShouldBeLaterThanTodayException : DomaiException
    {
        public SchaduleStartDateShouldBeLaterThanTodayException()
            : base($"WeekStartDate should be earlier than today.")
        {
        }
    }
}
