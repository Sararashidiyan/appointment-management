using AppointmentManagement.Domain.Appointments;
using AppointmentManagement.Domain.Appointments.AppointmentStates;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagement.Infrastructure.Repositories
{
    public class AppointmentRepository : BaseRepository<long, Appointment>, IAppointmentRepository
    {
        private readonly AppointmentManagementContext _context;
        public AppointmentRepository(AppointmentManagementContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Appointment>> GetAppointmentsByDoctorExpertIdForTheCurrentWeek(long doctorExpertId)
        {
            var fromdate = DateOfWeekHelper.GetLatestSaturday();
            var todate = fromdate.AddDays(7);
            return await _context.DoctorAppointments
                .Where(s =>s.DueDateTime.Value >= fromdate && s.DueDateTime.Value <= todate
                && s.DoctorExpertId == doctorExpertId).ToListAsync();
        }

        public async Task<Appointment> GetDoctorAppointment(long id)
        {
            return await _context.DoctorAppointments.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<Appointment>> GetDoctorAppointments(int stateId, DateTime? fromdate, DateTime? todate)
        {
            var state= (AppointmentStateEnum)stateId;
            if(fromdate==null)
            {
                fromdate = DateOfWeekHelper.GetLatestSaturday();
                todate = fromdate.Value.AddDays(7);
            }
            return await _context.DoctorAppointments
                .Where(s=>s.StateId== state && s.DueDateTime.Value>= fromdate && s.DueDateTime.Value <= todate)
                .ToListAsync();
        }

        public async Task<Appointment> GetPatientAppointment(long id)
        {
            return await _context.PatientAppointments.FirstOrDefaultAsync(s=>s.Id==id);
        }

        public async Task<List<Appointment>> GetPatientAppointments()
        {
            return await _context.PatientAppointments.ToListAsync();
        }

        public async Task<bool> IsAppointmentOverlapping(DateTime dueDateTime, long doctorExpertId)
        {
            var appointment = await _context.Appointments
                .FirstOrDefaultAsync(a => a.StateId == AppointmentStateEnum.Requested
                && a.DueDateTime.Value == dueDateTime.Date
                && a.DoctorExpertId == doctorExpertId);
            return appointment?.IsExpire == false;
        }

        public async Task<bool> IsCurrentPatientScheduledWithDoctorExpert(long patientId, long doctorExpertId)
        {
            var appointment= await _context.Appointments
                .FirstOrDefaultAsync(a => a.StateId == AppointmentStateEnum.Requested
                && a.CustomerId == patientId
                && a.DoctorExpertId == doctorExpertId);
            return appointment?.IsExpire == false;
        }

    }
}
