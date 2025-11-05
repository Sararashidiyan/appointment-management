using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagement.Application.Interfaces.RolePermissions.DTOs;
using AppointmentManagement.Domain.Users;

namespace AppointmentManagement.Application.Interfaces.RolePermissions
{
    public interface IRolePermissionService
    {
        Task Modify(List<ModifyRolePermissionDTO> items);
        Task<List<RolePermissionDTO>> GetByRole(RoleType role);
    }
}
