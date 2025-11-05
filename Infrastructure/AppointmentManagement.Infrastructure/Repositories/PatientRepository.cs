using AppointmentManagement.Domain.Patients;
using AppointmentManagement.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagement.Infrastructure.Repositories
{
    public class PatientRepository : BaseRepository<long, Patient>, IPatientRepository
    {
        private readonly AppointmentManagementContext _context;
        public PatientRepository(AppointmentManagementContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User?> FindByMobile(string mobile)
        {
            return await _context.Patients.FirstOrDefaultAsync(s => s.Mobile.Value == mobile);
        }

        public async Task<bool> IsNationalCodeDuplicate(string nationalCode, long? id)
        {
            return await _context.Patients.AnyAsync(s => (id == null || s.Id == id) && s.NationalCode.Value.Equals(nationalCode));
        }
    }
}
