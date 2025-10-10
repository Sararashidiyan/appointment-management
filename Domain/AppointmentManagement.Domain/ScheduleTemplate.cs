using System.Collections.Generic;
using AppointmentManagement.Domain.DoctorSchedules;
using AppointmentManagement.Domain.Exceptions;

namespace AppointmentManagement.Domain
{
    public abstract class ScheduleTemplate: EntityBase<int>
    {
        public SchaduleStartDate SchaduleStartDate { get; private set; }
        public List<WeeklySchedule> WeeklySchedules { get; private set; }
        public bool IsPublish { get; private set; }
        public bool IsActive { get; private set; }
        private List<WeeklySchedule> MergeSameDayOfWeeks(List<WeeklySchedule> weeklySchedule)
        {
           var groupedWeeklySchedule = weeklySchedule.GroupBy(w => w.DayOfWeek).Select(v => new WeeklySchedule(v.Key, v.SelectMany(s => s.TimeSlot).ToList()));
            return groupedWeeklySchedule.ToList();
        }
        public ScheduleTemplate(SchaduleStartDate schaduleStartDate, List<WeeklySchedule> weeklySchedules)
        {
            IsPublish = false;
            SchaduleStartDate = schaduleStartDate;
            WeeklySchedules = MergeSameDayOfWeeks(weeklySchedules);
        }
        public void Update(SchaduleStartDate schaduleStartDate, List<WeeklySchedule> weeklySchedules)
        {
            if (IsPublish) throw new CanNotUpdatePublishedScheduleTemplateException();
            SchaduleStartDate = schaduleStartDate;
            WeeklySchedules = MergeSameDayOfWeeks(weeklySchedules);

        }
        public void Publish()
        {
            if (SchaduleStartDate.Value <= DateTime.Now.Date)
                throw new SchaduleStartDateShouldBeLaterThanTodayException();
            IsPublish = true;
        }
        public void Activate()
        {
            IsActive= true;
        }
        public void Deactivate()
        {
            IsActive = false;
        }
        
        public ScheduleTemplate()
        {

        }
    }

    public class TestScheduleTemplate : ScheduleTemplate
    {
        public TestScheduleTemplate(SchaduleStartDate schaduleStartDate, List<WeeklySchedule> weeklySchedules)
            :base(schaduleStartDate,weeklySchedules)
        {
     
        }
    }
}
