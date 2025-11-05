namespace AppointmentManagement.Domain.Exceptions
{
    public class NationalCodeIsDuplicateExpiration : DomaiException
    {
        public NationalCodeIsDuplicateExpiration() : base("NationalCode is duplicate.") { }
    }
}
