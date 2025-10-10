using AppointmentManagement.Application.Interfaces.Experts;
using AppointmentManagement.Application.Interfaces.Experts.DTOs;
using AppointmentManagement.Application.Mappers;
using AppointmentManagement.Domain.Experts;

namespace AppointmentManagement.Application
{
    public class ExpertService(IExpertRepository _repository) : IExpertService
    {
        public async Task Activate(int id)
        {
            var expert = await _repository.GetByIdAsync(id);
            GuardAgainstNullValue(expert);
            expert.Activate();
        }

        public Task Create(CreateExpertCMD id)
        {
            throw new NotImplementedException();
        }

        public async Task Deactivate(int id)
        {
            var expert = await _repository.GetByIdAsync(id);
            GuardAgainstNullValue(expert);
            expert.Deactivate();
        }

        public async Task Delete(int id)
        {
            var expert = await _repository.GetByIdAsync(id);
            GuardAgainstNullValue(expert);
        }

        public Task<List<ExpertDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ExpertDTO> GetById(int id)
        {
            var expert = await _repository.GetByIdAsync(id);
            GuardAgainstNullValue(expert);
            return ExpertMappers.Map(expert);
        }

        public async Task Modify(ModifyExpertCMD item)
        {
            var expert = await _repository.GetByIdAsync(item.Id);
            GuardAgainstNullValue(expert);
        }
        private void GuardAgainstNullValue(Expert expert)
        {
            if (expert == null)
                throw new DirectoryNotFoundException();
        }
    }


}
