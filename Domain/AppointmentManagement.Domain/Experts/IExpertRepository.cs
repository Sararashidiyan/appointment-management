using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Domain.Experts
{
    public interface IExpertRepository: IRepository<int, Expert>
    {
    }
}
