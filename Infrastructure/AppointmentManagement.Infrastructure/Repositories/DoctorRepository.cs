using AppointmentManagement.Domain.Doctors;

namespace AppointmentManagement.Infrastructure.Repositories
{
    public class DoctorRepository : BaseRepository<long, Doctor>, IDoctorRepository
    {
        public DoctorRepository(AppointmentManagementContext context) : base(context)
        {
        }

    }
}
