
using System;
using System.Collections.Generic;
using System.Numerics;
using AppointmentManagement.Domain.Doctors.DoctorExperts;
using AppointmentManagement.Domain.Doctors;
using AppointmentManagement.Domain.DoctorSchedules;
using AppointmentManagement.Domain.Exceptions;
using AppointmentManagement.Domain.Experts;
using AppointmentManagement.Domain.Users;
using System.ComponentModel.DataAnnotations;

namespace AppointmentManagement.Domain.Test
{
    public class DoctorTest
    {

        [Fact]
        public void location_create_properly()
        {
            //Arrange
            var name = "سارا";
            var province = "123456";
            var englishName = "رشیدی یان";
            //Act
            var location = new Location(name, province, englishName); 
            //Assert
            Assert.Equal(location.Name, name);
            Assert.Equal(location.Province, province);
            Assert.Equal(location.EnglishName, englishName);
        }
        [Fact]
        public void create_should_create_doctor_properly()
        {
            //Arrange
            var firstName = "سارا";
            var pass = "123456";
            var lastName = "رشیدی یان";
            var FullName = $"{firstName} {lastName}";
            var email = new Email("sara@gmail.com");
            var mobile = new Mobile("09126717325");
            var role = RoleType.Doctor;
            var experts = new List<DoctorExpert>() { new(1), new(2) };
            var location = new Location("تهران", "تهران", "Tehran");
            //Act
            var doctor = new Doctor(firstName, lastName, email, mobile, pass, location);
            doctor.AssignDoctorExperts(experts);
            //Assert
            Assert.Equal(firstName, doctor.FirstName);
            Assert.Equal(lastName, doctor.LastName);
            Assert.Equal(FullName, doctor.FullName);
            Assert.Equal(role, doctor.Role);
            Assert.Equal(mobile, doctor.Mobile);
            Assert.Equal(email, doctor.Email);
            Assert.Equal(experts, doctor.DoctorExperts);
            Assert.Equal(location, doctor.Location);
            Assert.Equal(experts.Count, doctor.DoctorExperts.Count);
        }

        [Fact]
        public void update_should_update_doctor_properly()
        {
            //Arrange
            var firstName = "سارا";
            var pass = "123456";
            var lastName = "رشیدی یان";
            var email = new Email("sara@gmail.com");
            var mobile = new Mobile("09126717325");
            var location = new Location("تهران", "تهران", "Tehran");
            var doctor = new Doctor(firstName, lastName, email, mobile, pass,location);
            //Act
            doctor.Update(firstName,lastName,mobile,location);
            //Assert
            Assert.Equal(firstName, doctor.FirstName);
            Assert.Equal(lastName, doctor.LastName);
            Assert.Equal(email, doctor.Email);
            Assert.Equal(location, doctor.Location);
        }


        [Fact]
        public void Start_time_must_be_earlier_than_end_time()
        {
            //Arrange
            var fromHour = TimeSpan.FromHours(8);
            var toHour = TimeSpan.FromHours(12);
            //Act
            var timeRange = new TimeSlot(fromHour, toHour);
            //Assert
            Assert.Equal(timeRange.FromHour, fromHour);
            Assert.Equal(timeRange.ToHour, toHour);


        }
        [Fact]
        public void Time_range_should_throw_exception_when_start_time_be_later_than_end_time()
        {
            //Arrange
            var fromHour = TimeSpan.FromHours(8);
            var toHour = TimeSpan.FromHours(7);
            //Act
            //Assert
            Assert.Throws<TimeRangeException>(() => new TimeSlot(fromHour, toHour));
        }
        [Fact]
        public void create_weeklySchedule_should_create_weeklySchedule_properly()
        {
            //Arrange
            var dayOfWeek = "دوشنبه";
            var timeSlots = new List<TimeSlot>()
            {
                new(TimeSpan.FromHours(8), TimeSpan.FromHours(10))
            };
            //Act
            var weeklySchedule = new WeeklySchedule(dayOfWeek, timeSlots);
            //Assert
            Assert.Equal(weeklySchedule.DayOfWeek, dayOfWeek);
            Assert.Equal(weeklySchedule.TimeSlot.Count, timeSlots.Count);
            Assert.Equal(weeklySchedule.TimeSlot, timeSlots);
        }
        [Fact]
        public void create_weeklySchedule_should_throw_exception_when_timeSlots_overlap()
        {
            //Arrange
            var dayOfWeek = "دوشنبه";
            var timeSlots = new List<TimeSlot>()
            {
                new(TimeSpan.FromHours(8), TimeSpan.FromHours(10)),
                new(TimeSpan.FromHours(9), TimeSpan.FromHours(10)),
            };
            //Act
            //Assert
            Assert.Throws<ScheduleTimeSlotOverlapException>(() => new WeeklySchedule(dayOfWeek, timeSlots));
        }
        [Fact]
        public void create_schaduleStartDate_should_create_schaduleStartDate_properly()
        {
            //Arrange
            DateTime today = DateTime.Today;
            int daysUntilSaturday = ((int)DayOfWeek.Saturday - (int)today.DayOfWeek + 7) % 7;
            DateTime nextSaturday = today.AddDays(daysUntilSaturday == 0 ? 7 : daysUntilSaturday);
            //Act
            var schaduleStartDate = new SchaduleStartDate(nextSaturday);
            //Assert
            Assert.Equal(schaduleStartDate.Value, nextSaturday);

        }
        [Fact]
        public void create_schaduleStartDate_should_throw_exception_when_dayOfWeek_is_not_saturday()
        {
            //Arrange
            DateTime today = DateTime.Today;
            int daysUntilSaturday = ((int)DayOfWeek.Sunday - (int)today.DayOfWeek + 7) % 7;
            DateTime nextSaturday = today.AddDays(daysUntilSaturday == 0 ? 7 : daysUntilSaturday);
            //Act
            //Assert
            Assert.Throws<SchaduleStartDateShouldBeSaturdayException>(() => new SchaduleStartDate(nextSaturday));

        }
        [Fact]
        public void create_schaduleStartDate_should_throw_exception_when_dayOfWeek_is_earlier_than_today()
        {
            //Arrange
            DateTime nextSaturday = DateTime.Now.AddDays(-1);
            //Act
            //Assert
            Assert.Throws<SchaduleStartDateShouldBeLaterThanTodayException>(() => new SchaduleStartDate(nextSaturday));

        }

        [Fact]
        public void activate_doctorExpert_should_active_doctorExpert()
        {
            //Arrange
            
            //Act
            //Assert
        }
        [Fact]
        public void deactivate_doctorExpert_should_deactive_doctorExpert()
        {
            //Arrange

            //Act
            //Assert
        }
    }
}
