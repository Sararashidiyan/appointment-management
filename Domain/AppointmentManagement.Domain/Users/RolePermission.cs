namespace AppointmentManagement.Domain.Users
{
    public class RolePermission:EntityBase<int>
    {
        public RoleType Role { get;private set; }
        public string Permission { get;private set; }
        public RolePermission(RoleType role, string permission)
        {
            
        }
    }
}
