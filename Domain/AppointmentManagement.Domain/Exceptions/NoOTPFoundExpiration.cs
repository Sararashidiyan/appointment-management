namespace AppointmentManagement.Domain.Exceptions
{
    public class NoOTPFoundExpiration : DomaiException
    {
        public NoOTPFoundExpiration() : base("No OTP found for this mobile number. Please request one first.") { }
    }
}
