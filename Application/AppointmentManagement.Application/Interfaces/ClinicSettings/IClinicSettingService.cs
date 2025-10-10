using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagement.Application.Interfaces.ClinicSettings.DTOs;

namespace AppointmentManagement.Application.Interfaces.ClinicSettings
{
    public interface IClinicSettingService
    {
        Task<ClinicSettingDTO> GetById(int id);
        Task Create(CreateClinicSettingCMD item);
        Task Modify(ModifyClinicSettingCMD item);
    }
}
