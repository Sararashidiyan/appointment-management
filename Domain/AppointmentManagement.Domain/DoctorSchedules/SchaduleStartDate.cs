using AppointmentManagement.Domain.Exceptions;

namespace AppointmentManagement.Domain.DoctorSchedules
{
    public class SchaduleStartDate
    {
        public DateTime Value { get; set; }
        private SchaduleStartDate()
        {
            
        }
        public SchaduleStartDate(DateTime value)
        {
            if (value <= DateTime.Now)
                throw new SchaduleStartDateShouldBeLaterThanTodayException();
            if (value.DayOfWeek != DayOfWeek.Saturday)
                throw new SchaduleStartDateShouldBeSaturdayException();
            Value = value;
        }
    }
}
