using AppointmentManagement.Domain.Exceptions;

namespace AppointmentManagement.Domain.DoctorSchedules
{
    public class TimeSlot
    {
        public TimeSpan FromHour { get; private set; }
        public TimeSpan ToHour { get; private set; }
        public TimeSlot(TimeSpan fromHour, TimeSpan toHour)
        {
            ValidateTimeRange(fromHour, toHour);
            FromHour = fromHour;
            ToHour = toHour;

        } 
        private void ValidateTimeRange(TimeSpan fromHour, TimeSpan toHour)
        {
            if (fromHour > toHour)
                throw new TimeRangeException();
        }
        public TimeSlot()
        {
        }
    }
}
