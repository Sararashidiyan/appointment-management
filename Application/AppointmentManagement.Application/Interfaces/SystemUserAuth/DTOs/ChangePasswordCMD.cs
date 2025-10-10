namespace AppointmentManagement.Application.Interfaces.SystemUserAuth.DTOs
{
    public class ChangePasswordCMD
    {
        public string Email { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
