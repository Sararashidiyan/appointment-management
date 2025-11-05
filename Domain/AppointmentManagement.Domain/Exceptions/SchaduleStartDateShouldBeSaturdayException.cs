namespace AppointmentManagement.Domain.Exceptions
{
    public class SchaduleStartDateShouldBeSaturdayException : DomaiException
    {
        public SchaduleStartDateShouldBeSaturdayException()
            : base($"WeekStartDate should be saturday.")
        {
        }
    }
}
