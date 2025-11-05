using AppointmentManagement.Domain.DomainServices;
using AppointmentManagement.Domain.Exceptions;
using AppointmentManagement.Domain.Patients;

namespace AppointmentManagement.Infrastructure.DomainServices
{
    public class NationalCodeChecker(IPatientRepository _repository) : INationalCodeChecker
    {
        public async Task CheckNationalCode(string nationalCode,long? id=null)
        {
            var isNationalCodeDuplicate=await _repository.IsNationalCodeDuplicate(nationalCode, id);
            if (isNationalCodeDuplicate)
                throw new NationalCodeIsDuplicateExpiration();
        }
    }

}
