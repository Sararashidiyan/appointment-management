using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagement.Application.Interfaces.RolePermissions;
using AppointmentManagement.Application.Interfaces.RolePermissions.DTOs;
using AppointmentManagement.Domain.Users;
using AppointmentManagement.Domain.Users.RolePermission;

namespace AppointmentManagement.Application
{
    public class RolePermissionService(IRolePermissionRepository _repository) : IRolePermissionService
    {
        public List<RolePermissionDTO> GetByRole(RoleType role)
        {
            throw new NotImplementedException();
        }

        public Task Modify(List<ModifyRolePermissionDTO> items)
        {
            throw new NotImplementedException();
        }
        Task<List<RolePermissionDTO>> IRolePermissionService.GetByRole(RoleType role)
        {
            throw new NotImplementedException();
        }
    }
}
