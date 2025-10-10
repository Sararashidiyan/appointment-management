using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagement.Application.Interfaces.SystemUserManagement;
using AppointmentManagement.Application.Interfaces.SystemUserManagement.DTOs;
using AppointmentManagement.Application.Mappers;
using AppointmentManagement.Domain.SystemUsers;
using AppointmentManagement.Domain.Users;

namespace AppointmentManagement.Application
{
    public class SystemUserManagementService(ISystemUserRepository _repository) : ISystemUserManagementService
    {
        public async Task Activate(long id)
        {
            var systemUserManagement = await _repository.GetByIdAsync(id);
            GuardAgainstNullValue(systemUserManagement);
            systemUserManagement.Activate();
        }
        public async Task Create(CreateSystemUserManagementCMD item)
        {
            var mobile = new Mobile(item.Mobile);
            var email = new Email(item.Email);
            var systemUser = new SystemUser(item.FirstName, item.LastName, email, mobile, item.Role, item.Password);
            await _repository.CreateAsync(systemUser);
        }

        public async Task Deactivate(long id)
        {
            var systemUser = await _repository.GetByIdAsync(id);
            GuardAgainstNullValue(systemUser);
            systemUser.Deactivate();
        }
        public async Task<List<SystemUserManagementDTO>> GetAll()
        {
            var systemUsers = await _repository.GetAllAsync();
            return SystemUserManagementMappers.Map(systemUsers);
        }

        public async Task<SystemUserManagementDTO> GetById(long id)
        {
            var systemUser = await _repository.GetByIdAsync(id);
            GuardAgainstNullValue(systemUser);
            return SystemUserManagementMappers.Map(systemUser);
        }

        public async Task Modify(ModifySystemUserManagementCMD item)
        {
            var systemUser = await _repository.GetByIdAsync(item.Id);
            GuardAgainstNullValue(systemUser);
            var mobile = new Mobile(item.Mobile);
            systemUser.Update(item.FirstName,item.LastName,mobile);
        }
        private void GuardAgainstNullValue(SystemUser systemUser)
        {
            if (systemUser == null)
                throw new DirectoryNotFoundException();
        }
    }
}
