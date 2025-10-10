namespace AppointmentManagement.Domain.Exceptions
{
    public class AppointmentNotExpiredException : DomaiException
    {
        public AppointmentNotExpiredException(DateTime scheduledTime)
            : base($"Appointment scheduled for {scheduledTime} has not expired.")
        {
        }
    }
}
