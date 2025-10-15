namespace AppointmentManagement.Domain.Users
{
    public class RolePermission:AuditableEntityBase<int>
    {
        public RoleType Role { get;private set; }
        public string Permission { get;private set; }
        public RolePermission(RoleType role, string permission)
        {
            
        }
    }
}
