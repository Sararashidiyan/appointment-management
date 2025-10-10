namespace AppointmentManagement.Domain.Exceptions
{
    public class AppointmentExpiredException : DomaiException
    {
        public AppointmentExpiredException(DateTime scheduledTime)
            : base($"Appointment scheduled for {scheduledTime} has already expired.")
        {
        }
    }
    public class CanNotUpdatePublishedScheduleTemplateException : DomaiException
    {
        public CanNotUpdatePublishedScheduleTemplateException()
            : base($"can not update published scheduleTemplate.")
        {
        }
    }
}
