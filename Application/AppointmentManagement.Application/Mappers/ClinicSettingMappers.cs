using AppointmentManagement.Application.Interfaces.ClinicSettings.DTOs;
using AppointmentManagement.Domain.ClinicSettings;

namespace AppointmentManagement.Application.Mappers
{
    public class ClinicSettingMappers
    {
        public static ClinicSettingDTO Map(ClinicSetting clinicSetting)
        {
            return new ClinicSettingDTO
            {
                Id = clinicSetting.Id,
                VisitPeriodPerMinute = clinicSetting.VisitPeriodPerMinute,
            };
        }
    }
}
