using AppointmentManagement.Domain.DoctorSchedules;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagement.Infrastructure.Repositories
{
    public class DoctorOverrideScheduleRepository(AppointmentManagementContext _context) : IDoctorOverrideScheduleRepository
    {
        
        public Task<DoctorOverrideSchedule> getByDoctorId(long doctorId)
        {
            var latestSaturday = DateOfWeekHelper.GetLatestSaturday();
            return _context.DoctorOverrideSchedules.FirstOrDefaultAsync(s =>s.DoctorId== doctorId && s.SchaduleStartDate.Value == latestSaturday);

        }
        public Task<List<DoctorOverrideSchedule>> getAllByDoctorId(long doctorId)
        {
            return _context.DoctorOverrideSchedules.Where(s=>s.DoctorId== doctorId).ToListAsync();

        }

        public Task<DoctorOverrideSchedule> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(DoctorOverrideSchedule item)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(DoctorOverrideSchedule item)
        {
            throw new NotImplementedException();
        }

        public Task<List<DoctorOverrideSchedule>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
