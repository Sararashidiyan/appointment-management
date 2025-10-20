using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Domain.Users.RolePermission
{
    public class RolePermission:AuditableEntityBase<int>
    {
        public RoleType Role { get;private set; }
        public string Permission { get;private set; }
        public RolePermission(RoleType role,string permission)
        {
            Role=role;
            Permission=permission;
        }
     
    }
}
