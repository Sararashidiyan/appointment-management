using AppointmentManagement.Domain.Appointments;
using AppointmentManagement.Domain.Appointments.AppointmentStates;
using AppointmentManagement.Domain.Users;
using AppointmentManagement.Domain.Users.RolePermission;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagement.Infrastructure.Repositories
{
    public class RolePermissionRepository : BaseRepository<int, RolePermission>, IRolePermissionRepository
    {
        private readonly AppointmentManagementContext _context;
        public RolePermissionRepository(AppointmentManagementContext context) : base(context)
        {
            _context = context;
        }

        public List<RolePermission> GetByRole(RoleType role)
        {
            throw new NotImplementedException();
        }
    }
}
