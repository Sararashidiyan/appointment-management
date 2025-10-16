using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagement.Domain.Appointments;
using AppointmentManagement.Domain.Appointments.AppointmentStates;
using AppointmentManagement.Domain.Exceptions;

namespace AppointmentManagement.Domain.Test
{
    public class AppointmentTest
    {
        [Fact]
        public void create_should_create_appointment_properly()
        {
            //Arrange
            var customerId = 1;
            var customerFullName = "سارا رشیدی یان";
            var dayOfWeek = "دوشنبه";
            var doctorExpertId = 1;
            var dueDate = DateTime.Now.AddDays(4);
            var dueTime = TimeSpan.FromHours(3, 30);
            var dateTime = dueDate + dueTime;
            var dueDateTime = new AppointmentDueDateTime(dateTime);
            //Act
            var appointment = new Appointment(customerId, doctorExpertId, customerFullName, dayOfWeek, dueDateTime);
            //Assert
            Assert.Equal(appointment.CustomerId, customerId);
            Assert.Equal(appointment.CustomerFullName, customerFullName);
            Assert.Equal(appointment.DayOfWeek, dayOfWeek);
            Assert.Equal(appointment.DoctorExpertId, doctorExpertId);
            Assert.Equal(appointment.DueDateTime, dueDateTime);
            Assert.Equal(AppointmentStateEnum.Requested, appointment.StateId);
            Assert.Equal(typeof(RequestedState), appointment.State.GetType());
        }

        [Fact]
        public void complete_requested_state_should_change_state_to_compelete()
        {
            //Arrange
            var customerId = 1;
            var customerFullName = "سارا رشیدی یان";
            var dayOfWeek = "دوشنبه";
            var doctorExpertId = 1;
            var dueDate = DateTime.Now.AddDays(4);
            var dueTime = TimeSpan.FromHours(3, 30);
            var dateTime = dueDate + dueTime;
            var dueDateTime = new AppointmentDueDateTime(dateTime);
            //Act
            var appointment = new Appointment(customerId, doctorExpertId, customerFullName, dayOfWeek, dueDateTime);
            appointment.Compelete();
            //Assert
            Assert.Equal(AppointmentStateEnum.Compeleted, appointment.StateId);
            Assert.Equal(typeof(CompeletedState), appointment.State.GetType());
        }
        [Fact]
        public void complete_cancelByDoctor_state_should_throw_exception()
        {
            //Arrange
            var stateReseon = "";
            var customerId = 1;
            var customerFullName = "سارا رشیدی یان";
            var dayOfWeek = "دوشنبه";
            var doctorExpertId = 1;
            var dueDate = DateTime.Now.AddDays(4);
            var dueTime = TimeSpan.FromHours(3, 30);
            var dateTime = dueDate + dueTime;
            var dueDateTime = new AppointmentDueDateTime(dateTime);
            //Act
            var appointment = new Appointment(customerId, doctorExpertId, customerFullName, dayOfWeek, dueDateTime);
            appointment.CancelByDoctor(stateReseon);
            //Assert
            Assert.Throws<InvalidOperationException>(() => appointment.Compelete());
        }
        [Fact]
        public void complete_cancelByPatient_state_should_throw_exception()
        {
            //Arrange
            var customerId = 1;
            var customerFullName = "سارا رشیدی یان";
            var dayOfWeek = "دوشنبه";
            var doctorExpertId = 1;
            var dueDate = DateTime.Now.AddDays(4);
            var dueTime = TimeSpan.FromHours(3, 30);
            var dateTime = dueDate + dueTime;
            var dueDateTime = new AppointmentDueDateTime(dateTime);
            //Act
            var appointment = new Appointment(customerId, doctorExpertId, customerFullName, dayOfWeek, dueDateTime);
            appointment.CancelByPatient();
            //Assert
            Assert.Throws<InvalidOperationException>(() => appointment.Compelete());
        }
        [Fact]
        public void complete_reject_state_should_throw_exception()
        {
            //Arrange
            var customerId = 1;
            var stateReseon = "";
            var customerFullName = "سارا رشیدی یان";
            var dayOfWeek = "دوشنبه";
            var doctorExpertId = 1;
            var dueDate = DateTime.Now.AddDays(4);
            var dueTime = TimeSpan.FromHours(3, 30);
            var dateTime = dueDate + dueTime;

            var dueDateTime = new AppointmentDueDateTime(dateTime);
            //Act
            var appointment = new Appointment(customerId, doctorExpertId, customerFullName, dayOfWeek, dueDateTime);
            appointment.Reject(stateReseon);
            //Assert
            Assert.Throws<InvalidOperationException>(() => appointment.Compelete());
        }
        [Fact]
        public void reject_complete_state_should_throw_exception()
        {
            //Arrange
            var customerId = 1;
            var stateReseon = "";
            var customerFullName = "سارا رشیدی یان";
            var dayOfWeek = "دوشنبه";
            var doctorExpertId = 1;
            var dueDate = DateTime.Now.AddDays(4);
            var dueTime = TimeSpan.FromHours(3, 30);
            var dateTime = dueDate + dueTime;

            var dueDateTime = new AppointmentDueDateTime(dateTime);
            //Act
            var appointment = new Appointment(customerId, doctorExpertId, customerFullName, dayOfWeek, dueDateTime);
            appointment.Compelete();
            //Assert
            var ex = Assert.Throws<InvalidOperationException>(() => appointment.Reject(stateReseon));
            Assert.Equal("Reject not allowed in this state.", ex.Message);
        }
        [Fact]
        public void reject_requested_state_should_change_state_to_reject()
        {
            //Arrange
            var stateReseon = "";
            var customerId = 1;
            var customerFullName = "سارا رشیدی یان";
            var dayOfWeek = "دوشنبه";
            var doctorExpertId = 1;
            var dueDate = DateTime.Now.AddDays(4);
            var dueTime = TimeSpan.FromHours(3, 30);
            var dateTime = dueDate + dueTime;
            var dueDateTime = new AppointmentDueDateTime(dateTime);
            //Act
            var appointment = new Appointment(customerId, doctorExpertId, customerFullName, dayOfWeek, dueDateTime);
            appointment.Reject(stateReseon);
            //Assert
            Assert.Equal(AppointmentStateEnum.Rejected, appointment.StateId);
            Assert.Equal(typeof(RejectedState), appointment.State.GetType());
        }
        [Fact]
        public void reject_cancelByDoctor_state_should_throw_exception()
        {
            //Arrange
            var customerId = 1;
            var stateReseon = "";
            var customerFullName = "سارا رشیدی یان";
            var dayOfWeek = "دوشنبه";
            var doctorExpertId = 1;
            var dueDate = DateTime.Now.AddDays(4);
            var dueTime = TimeSpan.FromHours(3, 30);
            var dateTime = dueDate + dueTime;
            var dueDateTime = new AppointmentDueDateTime(dateTime);
            //Act
            var appointment = new Appointment(customerId, doctorExpertId, customerFullName, dayOfWeek, dueDateTime);
            appointment.CancelByDoctor(stateReseon);
            //Assert
            Assert.Throws<InvalidOperationException>(() => appointment.Reject(stateReseon));
        }
        [Fact]
        public void reject_cancelByPatient_state_should_throw_exception()
        {
            //Arrange
            var stateReseon = "";
            var customerId = 1;
            var customerFullName = "سارا رشیدی یان";
            var dayOfWeek = "دوشنبه";
            var doctorExpertId = 1;
            var dueDate = DateTime.Now.AddDays(4);
            var dueTime = TimeSpan.FromHours(3, 30);
            var dateTime = dueDate + dueTime;

            var dueDateTime = new AppointmentDueDateTime(dateTime);
            //Act
            var appointment = new Appointment(customerId, doctorExpertId, customerFullName, dayOfWeek, dueDateTime);
            appointment.CancelByPatient();
            //Assert
            Assert.Throws<InvalidOperationException>(() => appointment.Reject(stateReseon));
        }
        [Fact]
        public void cancelByPatient_cancelByDoctor_state_should_throw_exception()
        {
            //Arrange
            var stateReseon = "";
            var customerId = 1;
            var customerFullName = "سارا رشیدی یان";
            var dayOfWeek = "دوشنبه";
            var doctorExpertId = 1;
            var dueDate = DateTime.Now.AddDays(4);
            var dueTime = TimeSpan.FromHours(3, 30);
            var dateTime = dueDate + dueTime;
            var dueDateTime = new AppointmentDueDateTime(dateTime);
            //Act
            var appointment = new Appointment(customerId, doctorExpertId, customerFullName, dayOfWeek, dueDateTime);
            appointment.CancelByDoctor(stateReseon);
            //Assert
            Assert.Throws<InvalidOperationException>(() => appointment.CancelByPatient());
        }
        [Fact]
        public void cancelByPatient_reject_state_should_throw_exception()
        {
            //Arrange
            var stateReseon = "";
            var customerId = 1;
            var customerFullName = "سارا رشیدی یان";
            var dayOfWeek = "دوشنبه";
            var doctorExpertId = 1;
            var dueDate = DateTime.Now.AddDays(4);
            var dueTime = TimeSpan.FromHours(3, 30);
            var dateTime = dueDate + dueTime;
            var dueDateTime = new AppointmentDueDateTime(dateTime);
            //Act
            var appointment = new Appointment(customerId, doctorExpertId, customerFullName, dayOfWeek, dueDateTime);
            appointment.Reject(stateReseon);
            //Assert
            Assert.Throws<InvalidOperationException>(() => appointment.CancelByPatient());
        }
        [Fact]
        public void cancelByPatient_complete_state_should_throw_exception()
        {
            //Arrange
            var customerId = 1;
            var customerFullName = "سارا رشیدی یان";
            var dayOfWeek = "دوشنبه";
            var doctorExpertId = 1;
            var dueDate = DateTime.Now.AddDays(4);
            var dueTime = TimeSpan.FromHours(3, 30);
            var dateTime = dueDate + dueTime;
            var dueDateTime = new AppointmentDueDateTime(dateTime);
            //Act
            var appointment = new Appointment(customerId, doctorExpertId, customerFullName, dayOfWeek, dueDateTime);
            appointment.Compelete();
            //Assert
            var ex = Assert.Throws<InvalidOperationException>(() => appointment.CancelByPatient());
            Assert.Equal("CancelByPatient not allowed in this state.", ex.Message);
        }
        [Fact]
        public void cancelByPatient_requested_state_should_change_state_to_cancelledByPatient()
        {
            //Arrange
            var customerId = 1;
            var customerFullName = "سارا رشیدی یان";
            var dayOfWeek = "دوشنبه";
            var doctorExpertId = 1;
            var dueDate = DateTime.Now.AddDays(4);
            var dueTime = TimeSpan.FromHours(3, 30);
            var dateTime = dueDate + dueTime;
            var dueDateTime = new AppointmentDueDateTime(dateTime);
            //Act
            var appointment = new Appointment(customerId, doctorExpertId, customerFullName, dayOfWeek, dueDateTime);
            appointment.CancelByPatient();
            //Assert
            Assert.Equal(AppointmentStateEnum.CancelledByPatient, appointment.StateId);
            Assert.Equal(typeof(CancelledByPatientState), appointment.State.GetType());
        }

        [Fact]
        public void cancelByDoctor_reject_state_should_throw_exception()
        {
            //Arrange
            var stateReseon = "";
            var customerId = 1;
            var customerFullName = "سارا رشیدی یان";
            var dayOfWeek = "دوشنبه";
            var doctorExpertId = 1;
            var dueDate = DateTime.Now.AddDays(4);
            var dueTime = TimeSpan.FromHours(3, 30);
            var dateTime = dueDate + dueTime;
            var dueDateTime = new AppointmentDueDateTime(dateTime);
            //Act
            var appointment = new Appointment(customerId, doctorExpertId, customerFullName, dayOfWeek, dueDateTime);
            appointment.Reject(stateReseon);
            //Assert
            Assert.Throws<InvalidOperationException>(() => appointment.CancelByDoctor(stateReseon));
        }

        [Fact]
        public void cancelByDoctor_complete_state_should_throw_exception()
        {
            //Arrange
            var stateReseon = "";
            var customerId = 1;
            var customerFullName = "سارا رشیدی یان";
            var dayOfWeek = "دوشنبه";
            var doctorExpertId = 1;
            var dueDate = DateTime.Now.AddDays(4);
            var dueTime = TimeSpan.FromHours(3, 30);
            var dateTime = dueDate + dueTime;
            var dueDateTime = new AppointmentDueDateTime(dateTime);
            //Act
            var appointment = new Appointment(customerId, doctorExpertId, customerFullName, dayOfWeek, dueDateTime);
            appointment.Compelete();
            //Assert
            var ex = Assert.Throws<InvalidOperationException>(() => appointment.CancelByDoctor(stateReseon));
            Assert.Equal("CancelByDoctor not allowed in this state.", ex.Message);
        }
        [Fact]
        public void cancelByDoctor_cancelledByPatient_state_should_throw_exception()
        {
            //Arrange
            var stateReseon = "";
            var customerId = 1;
            var customerFullName = "سارا رشیدی یان";
            var dayOfWeek = "دوشنبه";
            var doctorExpertId = 1;
            var dueDate = DateTime.Now.AddDays(4);
            var dueTime = TimeSpan.FromHours(3, 30);
            var dateTime = dueDate + dueTime;
            var dueDateTime = new AppointmentDueDateTime(dateTime);
            //Act
            var appointment = new Appointment(customerId, doctorExpertId, customerFullName, dayOfWeek, dueDateTime);
            appointment.CancelByPatient();
            //Assert
            Assert.Throws<InvalidOperationException>(() => appointment.CancelByDoctor(stateReseon));
        }

        [Fact]
        public void cancelByDoctor_requested_state_should_change_state_to_cancelledByDoctor()
        {
            //Arrange
            var stateReseon = "";
            var customerId = 1;
            var customerFullName = "سارا رشیدی یان";
            var dayOfWeek = "دوشنبه";
            var doctorExpertId = 1;
            var dueDate = DateTime.Now.AddDays(4);
            var dueTime = TimeSpan.FromHours(3, 30);
            var dateTime = dueDate + dueTime;
            var dueDateTime = new AppointmentDueDateTime(dateTime);
            //Act
            var appointment = new Appointment(customerId, doctorExpertId, customerFullName, dayOfWeek, dueDateTime);
            appointment.CancelByDoctor(stateReseon);
            //Assert
            Assert.Equal(AppointmentStateEnum.CancelledByDoctor, appointment.StateId);
            Assert.Equal(typeof(CancelledByDoctorState), appointment.State.GetType());
        }

        [Fact]
        public void appointmentDueTime_should_create_appointmentDateTime_properly()
        {
            //Arrange
            var dueDate = DateTime.Now.AddDays(2).Date;
            var dueTime = TimeSpan.FromHours(3, 30);
            //Act
            var dateTime = dueDate + dueTime;
            var appointmentDateTime = new AppointmentDueDateTime(dateTime);
            //Assert
            Assert.Equal(appointmentDateTime.Value, dateTime);
        }
        [Fact]
        public void appointmentDueTime_should_throw_exception_when_dueDate_is_expire()
        {
            //Arrange
            var dueDate = DateTime.Now.AddDays(-2);
            var dueTime = TimeSpan.FromHours(3, 30);
            var dateTime = dueDate + dueTime;

            //Act
            //Assert
            Assert.Throws<AppointmentExpiredException>(() => new AppointmentDueDateTime(dateTime));
        }
        //[Fact]
        //public void isExpire_should_true_when_dueDateTime_is_earlier_than_now()
        //{
        //    //Arrange
        //    var customerId = 1;
        //    var customerFullName = "سارا رشیدی یان";
        //    var dayOfWeek = "دوشنبه";
        //    var doctorExpertId = 1;
        //    var dueDate = DateTime.Now.AddDays(-2);
        //    var dueTime = TimeSpan.FromHours(3, 30);
        //    var dueDateTime = new AppointmentDueDateTime(dueDate, dueTime);
        //    //Act
        //    var appointment = new Appointment(customerId, doctorExpertId, customerFullName, dayOfWeek, dueDateTime);
        //    //Assert
        //    Assert.True(appointment.IsExpire);
        //}
        [Fact]
        public void isExpire_should_false_when_dueDateTime_is_later_than_now()
        {
            //Arrange
            var customerId = 1;
            var customerFullName = "سارا رشیدی یان";
            var dayOfWeek = "دوشنبه";
            var doctorExpertId = 1;
            var dueDate = DateTime.Now.AddDays(2);
            var dueTime = TimeSpan.FromHours(3, 30);
            var dateTime = dueDate + dueTime;
            var dueDateTime = new AppointmentDueDateTime(dateTime);
            //Act
            var appointment = new Appointment(customerId, doctorExpertId, customerFullName, dayOfWeek, dueDateTime);
            //Assert
            Assert.False(appointment.IsExpire);
        }
        //[Fact]
        //public void noShow_requested_state_should_change_state_to_noShow()
        //{
        //    //Arrange
        //    var customerId = 1;
        //    var customerFullName = "سارا رشیدی یان";
        //    var dayOfWeek = "دوشنبه";
        //    var doctorExpertId = 1;
        //    var dueDate = DateTime.Now.AddDays(4);
        //    var dueTime = TimeSpan.FromHours(3, 30);
        //    var dateTime = dueDate + dueTime;
        //    var dueDateTime = new AppointmentDueDateTime(dateTime);
        //    //Act
        //    var appointment = new Appointment(customerId, doctorExpertId, customerFullName, dayOfWeek, dueDateTime);
        //    appointment.NoShow();
        //    //Assert
        //    Assert.Equal(AppointmentStateEnum.NoShow, appointment.StateId);
        //    Assert.Equal(typeof(NoShowState), appointment.State.GetType());
        //}
        //[Fact]
        //public void noShow_compeleted_state_should_throw_exception()
        //{
        //    //Arrange
        //    var customerId = 1;
        //    var customerFullName = "سارا رشیدی یان";
        //    var dayOfWeek = "دوشنبه";
        //    var doctorExpertId = 1;
        //    var dueDate = DateTime.Now.AddDays(-4);
        //    var dueTime = TimeSpan.FromHours(3, 30);
        //    var dateTime = dueDate + dueTime;
        //    var dueDateTime = new AppointmentDueDateTime(dateTime);
        //    //Act
        //    var appointment = new Appointment(customerId, doctorExpertId, customerFullName, dayOfWeek, dueDateTime);
        //    appointment.Compelete();
        //    //Assert
        //    Assert.Throws<InvalidOperationException>(() => appointment.NoShow());


        //}
    }
}
