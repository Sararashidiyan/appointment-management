using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Domain.SystemUsers
{
    public interface ISystemUserRepository:IRepository<long,SystemUser>
    {
        Task<SystemUser> FindByEmail(string email);
        Task<SystemUser> FindByMobile(string mobile);
    }
}
