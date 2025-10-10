using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Domain.ClinicSettings
{
    public interface IClinicSettingRepository:IRepository<int, ClinicSetting>
    {
    }
}
