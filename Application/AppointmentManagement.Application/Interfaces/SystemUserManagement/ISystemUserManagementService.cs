using AppointmentManagement.Application.Interfaces.SystemUserManagement.DTOs;

namespace AppointmentManagement.Application.Interfaces.SystemUserManagement
{
    public interface ISystemUserManagementService
    {
        Task<SystemUserManagementDTO> GetById(long id);
        Task<List<SystemUserManagementDTO>> GetAll();
        Task Create(CreateSystemUserManagementCMD item);
        Task Modify(ModifySystemUserManagementCMD item);
        Task Activate(long id);
        Task Deactivate(long id);
    }
}
