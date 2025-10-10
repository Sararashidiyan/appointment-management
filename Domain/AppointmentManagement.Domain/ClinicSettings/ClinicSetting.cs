using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagement.Domain.ClinicSettings.ClinicSchedules;

namespace AppointmentManagement.Domain.ClinicSettings
{
    public class ClinicSetting:EntityBase<int>,IAggrigateRoot
    {
        public  int VisitPeriodPerMinute { get;private set; }
        public List<ClinicSchedule> ClinicSchedules { get; private set; }
        public ClinicSetting(int visitPeriodPerMinute)
        {
            VisitPeriodPerMinute = visitPeriodPerMinute;
        }
        public void Update(int visitPeriodPerMinute)
        {
            VisitPeriodPerMinute = visitPeriodPerMinute;
        }

    }
}
