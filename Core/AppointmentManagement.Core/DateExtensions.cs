using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Core
{
    public static class DateExtensions
    {
        public static string ToPersianDate(this DateTime date)
        {
            var pc = new PersianCalendar();
            int year = pc.GetYear(date);
            int month = pc.GetMonth(date);
            int day = pc.GetDayOfMonth(date);

            return $"{year:0000}/{month:00}/{day:00}";
        }
        public static DateTime GetLatestSaturday()
        {
            var today = DateTime.Today;
            int daysSinceSaturday = (int)today.DayOfWeek >= 6 ? 0 : ((int)today.DayOfWeek + 1);
            return today.AddDays(-daysSinceSaturday);
        }
    }
}
