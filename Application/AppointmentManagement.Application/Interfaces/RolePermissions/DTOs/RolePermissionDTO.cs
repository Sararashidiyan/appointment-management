using AppointmentManagement.Domain.Users;

namespace AppointmentManagement.Application.Interfaces.RolePermissions.DTOs
{
    public class RolePermissionDTO
    {
        public int Id { get; set; }
        public RoleType RoleType { get; set; }
        public string Permission { get; set; }
    }
}
