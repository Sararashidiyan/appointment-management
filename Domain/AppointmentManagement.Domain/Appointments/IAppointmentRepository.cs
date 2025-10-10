using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Domain.Appointments
{
    public interface IAppointmentRepository
    {
        Task<List<Appointment>> GetAppointmentsByDoctorExpertIdForTheCurrentWeek(long doctorId);
        Task<Appointment> GetByIdAsync(long id);
        Task CreateAsync(Appointment item);
        Task<bool> IsAppointmentOverlapping(DateTime dueDateTime, long doctorExpertId);
        Task<bool> IsCurrentPatientScheduledWithDoctorExpert(long patientId, long doctorExpertId);
        Task<List<Appointment>> GetPatientAppointments();
        Task<List<Appointment>> GetDoctorAppointments(int stateId, DateTime? fromdate, DateTime? todate);
        Task<Appointment> GetPatientAppointment(long id);
        Task<Appointment> GetDoctorAppointment(long id);
    }
}
