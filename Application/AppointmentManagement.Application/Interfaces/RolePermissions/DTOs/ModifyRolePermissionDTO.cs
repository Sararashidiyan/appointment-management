using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagement.Domain.Users;

namespace AppointmentManagement.Application.Interfaces.RolePermissions.DTOs
{
    public class ModifyRolePermissionDTO
    {
        public RoleType RoleType { get; set; }
        public string Permission { get; set; }
    }
}
