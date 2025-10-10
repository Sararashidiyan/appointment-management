using AppointmentManagement.Application.Interfaces.Appointments;
using AppointmentManagement.Application.Interfaces.Appointments.DTOs;
using AppointmentManagement.Application.Mappers;
using AppointmentManagement.Domain.Appointments;

namespace AppointmentManagement.Application
{
    public class AppointmentService(IAppointmentRepository _repository, AppointmentFactory appointmentFactory) : IAppointmentService
    {
        public async Task CancelByDoctor(long id, string reseon)
        {
            var appointment = await _repository.GetDoctorAppointment(id);
            GuardAgainstNullValue(appointment);
            appointment.CancelByDoctor(reseon);
        }

        public async Task CancelByPatient(long id)
        {
            var appointment = await _repository.GetPatientAppointment(id);
            GuardAgainstNullValue(appointment);
            appointment.CancelByPatient();
        }

        public async Task Compelete(long id)
        {
            var appointment = await _repository.GetDoctorAppointment(id);
            GuardAgainstNullValue(appointment);
            appointment.Compelete();
        }

        public async Task Create(CreateAppointmentCMD cmd)
        {
            var appointment = appointmentFactory.Create(cmd);
            await _repository.CreateAsync(appointment);
        }

        public async Task<List<AppointmentDTO>> GetAppointmentsByDoctorIdForTheCurrentWeek(long doctorExpertId)
        {
            var appointments = await _repository.GetAppointmentsByDoctorExpertIdForTheCurrentWeek(doctorExpertId);
            return AppointmentMappers.Map(appointments);
        }
        public async Task<List<AppointmentDTO>> GetPatientAppointments()
        {
            var appointments = await _repository.GetPatientAppointments();
            return AppointmentMappers.Map(appointments);
        }
        public async Task<List<AppointmentDTO>> GetDoctorAppointments(int stateId, DateTime? fromdate, DateTime? todate)
        {
            var appointments = await _repository.GetDoctorAppointments(stateId, fromdate, todate);
            return AppointmentMappers.Map(appointments);
        }

        public async Task NoShow(long id)
        {
            var appointment = await _repository.GetDoctorAppointment(id);
            GuardAgainstNullValue(appointment);
            appointment.NoShow();
        }

        public async Task Reject(long id, string reseon)
        {
            var appointment = await _repository.GetDoctorAppointment(id);
            GuardAgainstNullValue(appointment);
            appointment.Reject(reseon);
        }
        private void GuardAgainstNullValue(Appointment expert)
        {
            if (expert == null)
                throw new DirectoryNotFoundException();
        }
    }

}
