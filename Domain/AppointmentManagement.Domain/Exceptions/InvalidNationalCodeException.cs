namespace AppointmentManagement.Domain.Exceptions
{
    public class InvalidNationalCodeException : DomaiException
    {
        public InvalidNationalCodeException() : base("NationalCode is invalid.") { }
    }
}
