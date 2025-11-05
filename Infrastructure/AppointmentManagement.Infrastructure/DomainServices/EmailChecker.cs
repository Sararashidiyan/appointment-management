using AppointmentManagement.Domain.DomainServices;
using AppointmentManagement.Domain.Exceptions;
using AppointmentManagement.Domain.SystemUsers;

namespace AppointmentManagement.Infrastructure.DomainServices
{
    public class EmailChecker(ISystemUserRepository _repository) : IEmailChecker
    {
        public async Task CheckEmail(string email, long? id = null)
        {
            var isEmailDuplicate=await _repository.IsEmailDuplicate(email, id);
            if (isEmailDuplicate)
                throw new EmailIsDuplicateExpiration();
        }
    }

}
