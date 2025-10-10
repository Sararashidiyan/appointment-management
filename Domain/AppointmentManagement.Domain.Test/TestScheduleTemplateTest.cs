using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagement.Domain.DoctorSchedules;
using AppointmentManagement.Domain.Exceptions;

namespace AppointmentManagement.Domain.Test
{
    public class TestScheduleTemplateTest
    {
        [Fact]
        public void create_schedules_should_create_schedule_properly()
        {
            //Arrange
            DateTime today = DateTime.Today;
            int daysUntilSaturday = ((int)DayOfWeek.Saturday - (int)today.DayOfWeek + 7) % 7;
            DateTime nextSaturday = today.AddDays(daysUntilSaturday == 0 ? 7 : daysUntilSaturday);
            var schaduleStartDate = new SchaduleStartDate(nextSaturday);
            //Act

            var schedule1 = new WeeklySchedule("شنبه",
            [
                new(TimeSpan.FromHours(8), TimeSpan.FromHours(10)) ,
                new(TimeSpan.FromHours(10), TimeSpan.FromHours(12)),
                new(TimeSpan.FromHours(12), TimeSpan.FromHours(14))
            ]);
            var schedule2 = new WeeklySchedule("یکشنبه", [
                new(TimeSpan.FromHours(16), TimeSpan.FromHours(18))
            ]);
            var schedule3 = new WeeklySchedule("دوشنبه", [
                new(TimeSpan.FromHours(8), TimeSpan.FromHours(10)) ,
                new(TimeSpan.FromHours(12), TimeSpan.FromHours(14))
            ]);
            var schedule4 = new WeeklySchedule("دوشنبه", [
                new(TimeSpan.FromHours(14), TimeSpan.FromHours(16))
            ]);
            var schedules = new List<WeeklySchedule>() { schedule1, schedule2, schedule3, schedule4 };
            var testScheduleTemplate = new TestScheduleTemplate(schaduleStartDate, schedules);
            //Assert
            var expectedList = new List<WeeklySchedule>() { schedule1, schedule2, schedule3 };
            Assert.Equal(testScheduleTemplate.SchaduleStartDate, schaduleStartDate);
            Assert.Equal(expectedList.Count, testScheduleTemplate.WeeklySchedules.Count);
            Assert.False(testScheduleTemplate.IsPublish);
        }

        [Fact]
        public void create_temprory_schedules_should_create_temprory_schedule_properly()
        {
            //Arrange
            var reason = "travel";
            DateTime today = DateTime.Today;
            int daysUntilSaturday = ((int)DayOfWeek.Saturday - (int)today.DayOfWeek + 7) % 7;
            DateTime nextSaturday = today.AddDays(daysUntilSaturday == 0 ? 7 : daysUntilSaturday);
            var schaduleStartDate = new SchaduleStartDate(nextSaturday);
            //Act

            var schedule1 = new WeeklySchedule("شنبه",
            [
                new(TimeSpan.FromHours(8), TimeSpan.FromHours(10)) ,
                new(TimeSpan.FromHours(10), TimeSpan.FromHours(12)),
                new(TimeSpan.FromHours(12), TimeSpan.FromHours(14))
            ]);
            var schedule2 = new WeeklySchedule("یکشنبه", [
                new(TimeSpan.FromHours(16), TimeSpan.FromHours(18))
            ]);
            var schedule3 = new WeeklySchedule("دوشنبه", [
                new(TimeSpan.FromHours(8), TimeSpan.FromHours(10)) ,
                new(TimeSpan.FromHours(12), TimeSpan.FromHours(14))
            ]);
            var schedule4 = new WeeklySchedule("دوشنبه", [
                new(TimeSpan.FromHours(14), TimeSpan.FromHours(16))
            ]);
            var schedules = new List<WeeklySchedule>() { schedule1, schedule2, schedule3, schedule4 };
            var testScheduleTemplate = new DoctorOverrideSchedule(schaduleStartDate, schedules, reason);
            //Assert
            Assert.Equal(testScheduleTemplate.Reason, reason);
        }

        [Fact]
        public void update_schedules_should_update_schedule_properly()
        {
            //Arrange
            DateTime today = DateTime.Today;
            int daysUntilSaturday = ((int)DayOfWeek.Saturday - (int)today.DayOfWeek + 7) % 7;
            DateTime nextSaturday = today.AddDays(daysUntilSaturday == 0 ? 7 : daysUntilSaturday);
            var schaduleStartDate = new SchaduleStartDate(nextSaturday);

            var schedule1 = new WeeklySchedule("شنبه",
            [
                new(TimeSpan.FromHours(8), TimeSpan.FromHours(10)) ,
                new(TimeSpan.FromHours(10), TimeSpan.FromHours(12)),
                new(TimeSpan.FromHours(12), TimeSpan.FromHours(14))
            ]);

            var schedules = new List<WeeklySchedule>() { schedule1 };
            var newSchedules = new List<WeeklySchedule>() { schedule1 };
            var testScheduleTemplate = new TestScheduleTemplate(schaduleStartDate, schedules);

            //Act
            testScheduleTemplate.Update(schaduleStartDate, newSchedules);
            //Assert
            Assert.Equal(testScheduleTemplate.SchaduleStartDate, schaduleStartDate);
            Assert.Equal(newSchedules.Count, testScheduleTemplate.WeeklySchedules.Count);
        }
        [Fact]
        public void update_schedules_should_throw_exception_when_schadule_is_published()
        {
            //Arrange
            DateTime today = DateTime.Today;
            int daysUntilSaturday = ((int)DayOfWeek.Saturday - (int)today.DayOfWeek + 7) % 7;
            DateTime nextSaturday = today.AddDays(daysUntilSaturday == 0 ? 7 : daysUntilSaturday);
            var schaduleStartDate = new SchaduleStartDate(nextSaturday);

            var schedule1 = new WeeklySchedule("شنبه",
            [
                new(TimeSpan.FromHours(8), TimeSpan.FromHours(10)) 
            ]);
            var newSchedule1 = new WeeklySchedule("دوشنبه",
            [
                new(TimeSpan.FromHours(18), TimeSpan.FromHours(20))
            ]);

            var schedules = new List<WeeklySchedule>() { schedule1 };
            var newSchedules = new List<WeeklySchedule>() { newSchedule1 };
            var testScheduleTemplate = new TestScheduleTemplate(schaduleStartDate, schedules);
            testScheduleTemplate.Publish();
            //Act
            //Assert
            Assert.Throws<CanNotUpdatePublishedScheduleTemplateException>(() => testScheduleTemplate.Update(schaduleStartDate, newSchedules));
            
        }
        [Fact]
        public void publish_should_publish_schedule_properly()
        {
            //Arrange
            DateTime today = DateTime.Today;
            int daysUntilSaturday = ((int)DayOfWeek.Saturday - (int)today.DayOfWeek + 7) % 7;
            DateTime nextSaturday = today.AddDays(daysUntilSaturday == 0 ? 7 : daysUntilSaturday);
            var schaduleStartDate = new SchaduleStartDate(nextSaturday);
            //Act

            var schedule1 = new WeeklySchedule("شنبه",
            [
                new(TimeSpan.FromHours(8), TimeSpan.FromHours(10)) ,
                new(TimeSpan.FromHours(10), TimeSpan.FromHours(12)),
                new(TimeSpan.FromHours(12), TimeSpan.FromHours(14))
            ]);

            var schedules = new List<WeeklySchedule>() { schedule1 };
            var testScheduleTemplate = new TestScheduleTemplate(schaduleStartDate, schedules);
            testScheduleTemplate.Publish();
            //Assert
            Assert.True(testScheduleTemplate.IsPublish);
        }
        //[Fact]
        //public void publish_should_throw_exception_when_schaduleStartDate_is_earlier_than_today()
        //{
        //    //Arrange
        //    DateTime today = DateTime.Today;
        //    int daysUntilSaturday = ((int)DayOfWeek.Saturday - (int)today.DayOfWeek + 7) % 7;
        //    DateTime nextSaturday = today.AddDays(daysUntilSaturday == 0 ? 7 : daysUntilSaturday);
        //    var schaduleStartDate = new SchaduleStartDate(nextSaturday);
        //    //Act

        //    var schedule1 = new WeeklySchedule("شنبه",
        //    [
        //        new(TimeSpan.FromHours(8), TimeSpan.FromHours(10)) ,
        //        new(TimeSpan.FromHours(10), TimeSpan.FromHours(12)),
        //        new(TimeSpan.FromHours(12), TimeSpan.FromHours(14))
        //    ]);

        //    var schedules = new List<WeeklySchedule>() { schedule1 };
        //    var testScheduleTemplate = new TestScheduleTemplate(schaduleStartDate, schedules);
        //    testScheduleTemplate.Publish();
        //    //Assert
        //    Assert.Throws<SchaduleStartDateShouldBeLaterThanTodayException>(() => testScheduleTemplate.Publish());

        //}

        [Fact]
        public void activate_should_active_schadule_properly()
        {
            //Arrange
            DateTime today = DateTime.Today;
            int daysUntilSaturday = ((int)DayOfWeek.Saturday - (int)today.DayOfWeek + 7) % 7;
            DateTime nextSaturday = today.AddDays(daysUntilSaturday == 0 ? 7 : daysUntilSaturday);
            var schaduleStartDate = new SchaduleStartDate(nextSaturday);

            var schedule1 = new WeeklySchedule("شنبه",
            [
                new(TimeSpan.FromHours(8), TimeSpan.FromHours(10))
            ]);
            var newSchedule1 = new WeeklySchedule("دوشنبه",
            [
                new(TimeSpan.FromHours(18), TimeSpan.FromHours(20))
            ]);

            var schedules = new List<WeeklySchedule>() { schedule1 };
            var testScheduleTemplate = new TestScheduleTemplate(schaduleStartDate, schedules);

            //Act
            testScheduleTemplate.Activate();
            
            //Assert
            Assert.True(testScheduleTemplate.IsActive);

        }

        [Fact]
        public void deactivate_should_deactive_schadule_properly()
        {
            //Arrange
            DateTime today = DateTime.Today;
            int daysUntilSaturday = ((int)DayOfWeek.Saturday - (int)today.DayOfWeek + 7) % 7;
            DateTime nextSaturday = today.AddDays(daysUntilSaturday == 0 ? 7 : daysUntilSaturday);
            var schaduleStartDate = new SchaduleStartDate(nextSaturday);

            var schedule1 = new WeeklySchedule("شنبه",
            [
                new(TimeSpan.FromHours(8), TimeSpan.FromHours(10))
            ]);
            var newSchedule1 = new WeeklySchedule("دوشنبه",
            [
                new(TimeSpan.FromHours(18), TimeSpan.FromHours(20))
            ]);

            var schedules = new List<WeeklySchedule>() { schedule1 };
            var testScheduleTemplate = new TestScheduleTemplate(schaduleStartDate, schedules);

            //Act
            testScheduleTemplate.Deactivate();

            //Assert
            Assert.False(testScheduleTemplate.IsActive);

        }
    }
}
