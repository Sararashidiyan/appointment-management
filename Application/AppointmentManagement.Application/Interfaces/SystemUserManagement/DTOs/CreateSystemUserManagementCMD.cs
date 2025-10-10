using AppointmentManagement.Domain.Users;

namespace AppointmentManagement.Application.Interfaces.SystemUserManagement.DTOs
{
    public class CreateSystemUserManagementCMD
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public RoleType Role { get; set; }
        public string Password { get; set; }
    }
}
