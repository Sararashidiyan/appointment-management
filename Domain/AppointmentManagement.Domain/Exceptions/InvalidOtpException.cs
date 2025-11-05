namespace AppointmentManagement.Domain.Exceptions
{
    public class InvalidOtpException : DomaiException
    {
        public InvalidOtpException() : base("Invalid OTP. Please try again.") { }
    } 
}
