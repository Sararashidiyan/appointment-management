using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Infrastructure.Repositories
{
    public static class DateOfWeekHelper
    {
        public static DateTime GetLatestSaturday()
        {
            var today = DateTime.Today;
            int daysSinceSaturday = (int)today.DayOfWeek >= 6 ? 0 : ((int)today.DayOfWeek + 1);
            return today.AddDays(-daysSinceSaturday);
        }
    }
}
