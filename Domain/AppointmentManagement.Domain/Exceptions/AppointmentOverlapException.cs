namespace AppointmentManagement.Domain.Exceptions
{
    public class AppointmentOverlapException : DomaiException
    {
        public AppointmentOverlapException() : base("Appointment overlap.") { }
    }
}
