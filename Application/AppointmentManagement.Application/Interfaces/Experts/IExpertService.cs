using AppointmentManagement.Application.Interfaces.Experts.DTOs;

namespace AppointmentManagement.Application.Interfaces.Experts
{
    public interface IExpertService
    {
        Task<ExpertDTO> GetById(int id);
        Task<List<ExpertDTO>> GetAll();
        Task Create(CreateExpertCMD id);
        Task Modify(ModifyExpertCMD id);
        Task Delete(int id);
        Task Activate(int id);
        Task Deactivate(int id);
    }
}
