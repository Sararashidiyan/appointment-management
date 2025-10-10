using AppointmentManagement.Domain.Patients;

namespace AppointmentManagement.Infrastructure.Repositories
{
    public class PatientRepository : BaseRepository<long, Patient>, IPatientRepository
    {
        public PatientRepository(AppointmentManagementContext context) : base(context)
        {
        }
    }
}
