using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagement.Application.Interfaces.SystemUserManagement.DTOs;
using AppointmentManagement.Domain.Patients;
using AppointmentManagement.Domain.SystemUsers;

namespace AppointmentManagement.Application.Mappers
{
    public class SystemUserManagementMappers
    {
        public static SystemUserManagementDTO Map(SystemUser systemUser)
        {
            return new SystemUserManagementDTO
            {
                FirstName = systemUser.FirstName,
                LastName = systemUser.LastName,
                Mobile = systemUser.Mobile.Value,
                Email = systemUser.Email.Value,
            };
        }

        public static List<SystemUserManagementDTO?> Map(List<SystemUser> systemUsers)
        {
            return systemUsers?.Select(Map).ToList();

        }
    }
}
