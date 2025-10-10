using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Application.Interfaces.SystemUserAuth
{
    public interface ICurrentUserService
    {
        long UserId { get; }
        string FullName { get; }
        string Role { get; }
    }
}
