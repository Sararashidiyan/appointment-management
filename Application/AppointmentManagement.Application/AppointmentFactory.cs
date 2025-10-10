using AppointmentManagement.Application.Interfaces.Appointments.DTOs;
using AppointmentManagement.Application.Interfaces.SystemUserAuth;
using AppointmentManagement.Domain.Appointments;

namespace AppointmentManagement.Application
{
    public class AppointmentFactory
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly AppointmentDomainService _appointmentDomainService;
        public AppointmentFactory(ICurrentUserService currentUserService, AppointmentDomainService appointmentDomainService)
        {
            _currentUserService = currentUserService;
            _appointmentDomainService = appointmentDomainService;
        }
        public Appointment Create(CreateAppointmentCMD cmd)
        {
            var dueDateTime = new AppointmentDueDateTime(cmd.DueDateTime);
            var currentPatientId = _currentUserService.UserId;
            var currentPatientFullName = _currentUserService.FullName;
            return new Appointment(currentPatientId, cmd.DoctorExpertId, currentPatientFullName, cmd.DayOfWeek, dueDateTime);
        }
    }

}
