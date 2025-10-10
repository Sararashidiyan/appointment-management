using AppointmentManagement.Domain.Exceptions;

namespace AppointmentManagement.Domain.DoctorSchedules
{
    public class WeeklySchedule:ValueObject
    {
        public long Id { get; private set; }
        public int ScheduleTemplateId { get; private set; }
        public string DayOfWeek { get; private set; }
        public List<TimeSlot> TimeSlot { get; private set; }
        public WeeklySchedule()
        {

        }
        public WeeklySchedule(string dayOfWeek, List<TimeSlot> timeSlots)
        {
            DayOfWeek = dayOfWeek;
            CheckOverlap(timeSlots);
            TimeSlot = timeSlots;
        }
        private void CheckOverlap(List<TimeSlot> timeSlot)
        {
            var sorted = timeSlot.OrderBy(r => r.FromHour).ToList();
            for (int i = 0; i < sorted.Count - 1; i++)
            {
                var current = sorted[i];
                var next = sorted[i + 1];
                if (current.ToHour > next.FromHour)
                    throw new ScheduleTimeSlotOverlapException();
            }
        }

    }
}
