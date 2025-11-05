namespace AppointmentManagement.Domain.Exceptions
{
    public class PhoneNumberIsDuplicateExpiration : DomaiException
    {
        public PhoneNumberIsDuplicateExpiration() : base("PhoneNumber is duplicate.") { }
    }
}
