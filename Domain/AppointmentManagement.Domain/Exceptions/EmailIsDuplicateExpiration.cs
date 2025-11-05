namespace AppointmentManagement.Domain.Exceptions
{
    public class EmailIsDuplicateExpiration : DomaiException
    {
        public EmailIsDuplicateExpiration() : base("Email is duplicate.") { }
    }
}
