namespace AppointmentManagement.Domain.Exceptions
{
    public class InvalidEmailException : DomaiException
    {
        public InvalidEmailException() : base("Email is invalid.") { }
    }
}
