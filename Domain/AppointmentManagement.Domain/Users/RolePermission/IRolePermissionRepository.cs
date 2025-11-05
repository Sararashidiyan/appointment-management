namespace AppointmentManagement.Domain.Users.RolePermission
{
    public interface IRolePermissionRepository:IRepository<int,RolePermission>
    {
        List<RolePermission> GetByRole(RoleType role);
    }
}
