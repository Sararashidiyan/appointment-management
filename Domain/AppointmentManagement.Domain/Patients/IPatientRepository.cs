using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagement.Domain.Users;

namespace AppointmentManagement.Domain.Patients
{
    public interface IPatientRepository : IRepository<long, Patient>
    {
        Task<User?> FindByMobile(string mobile);
        Task<bool> IsNationalCodeDuplicate(string number, long? id);
    }
}
