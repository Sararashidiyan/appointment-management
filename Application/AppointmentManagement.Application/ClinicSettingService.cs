using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagement.Application.Interfaces.ClinicSettings;
using AppointmentManagement.Application.Interfaces.ClinicSettings.DTOs;
using AppointmentManagement.Application.Mappers;
using AppointmentManagement.Domain.ClinicSettings;

namespace AppointmentManagement.Application
{
    public class ClinicSettingService(IClinicSettingRepository _repository) : IClinicSettingService
    {

        public async Task Create(CreateClinicSettingCMD item)
        {
            var clinicSetting = new ClinicSetting(item.VisitPeriodPerMinute);
            await _repository.CreateAsync(clinicSetting);
        }
        public async Task<ClinicSettingDTO> GetById(int id)
        {
            var clinicSetting = await _repository.GetByIdAsync(id);
            GuardAgainstNullValue(clinicSetting);
            return ClinicSettingMappers.Map(clinicSetting);
        }

        public async Task Modify(ModifyClinicSettingCMD item)
        {
            var clinicSetting = await _repository.GetByIdAsync(item.Id);
            GuardAgainstNullValue(clinicSetting);
            clinicSetting.Update(clinicSetting.VisitPeriodPerMinute);
        }
        private void GuardAgainstNullValue(ClinicSetting clinicSetting)
        {
            if (clinicSetting == null)
                throw new DirectoryNotFoundException();
        }
    }
}
