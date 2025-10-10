namespace AppointmentManagement.Application.Interfaces.SystemUserManagement.DTOs
{
    public class ModifySystemUserManagementCMD
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Role { get; set; }
    }
}
