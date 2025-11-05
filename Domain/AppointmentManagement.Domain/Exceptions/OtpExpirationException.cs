namespace AppointmentManagement.Domain.Exceptions
{
    public class OtpExpirationException : DomaiException
    {
        public OtpExpirationException() : base("OTP has expired. Please request a new one.") { }
    }
}
