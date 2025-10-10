using AppointmentManagement.Domain.ClinicSettings;

namespace AppointmentManagement.Infrastructure.Repositories
{
    public class ClinicSettingRepository : BaseRepository<int, ClinicSetting>, IClinicSettingRepository
    {
        public ClinicSettingRepository(AppointmentManagementContext context) : base(context)
        {
        }
    }
}
