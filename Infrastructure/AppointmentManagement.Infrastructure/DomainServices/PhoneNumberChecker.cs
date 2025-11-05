using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagement.Domain.DomainServices;
using AppointmentManagement.Domain.Exceptions;
using AppointmentManagement.Domain.SystemUsers;

namespace AppointmentManagement.Infrastructure.DomainServices
{
    public class PhoneNumberChecker(ISystemUserRepository _repository) : IPhoneNumberChecker
    {
        public async Task CheckNumber(string number, long? id = null)
        {
            var isPhoneNumberDuplicate=await _repository.IsPhoneNumberDuplicate(number, id);
            if (isPhoneNumberDuplicate)
                throw new PhoneNumberIsDuplicateExpiration();
        }
    }

}
