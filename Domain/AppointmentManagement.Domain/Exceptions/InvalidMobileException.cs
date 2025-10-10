namespace AppointmentManagement.Domain.Exceptions
{
    public class InvalidMobileException : DomaiException
    {
        public InvalidMobileException() : base("Mobile is invalid.") { }
    }
}
