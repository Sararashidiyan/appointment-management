using AppointmentManagement.Domain.Experts;

namespace AppointmentManagement.Infrastructure.Repositories
{
    public class ExpertRepository : BaseRepository<int, Expert>, IExpertRepository
    {
        public ExpertRepository(AppointmentManagementContext context) : base(context)
        {
        }

    }
}
