using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Domain.Exceptions
{ 
    public class TimeRangeException: DomaiException
    {
        public TimeRangeException():base("Start time must be earlier than end time.") { }
    } 
}
