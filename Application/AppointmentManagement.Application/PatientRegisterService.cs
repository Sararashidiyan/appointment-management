using AppointmentManagement.Application.Interfaces.PatientAuth;
using AppointmentManagement.Application.Interfaces.Patients.DTOs;
using AppointmentManagement.Domain.JwtTokenGenerator;
using AppointmentManagement.Domain.Patients;
using AppointmentManagement.Domain.DomainServices;
using AppointmentManagement.Domain.Users;

namespace AppointmentManagement.Application
{
    public class PatientRegisterService(
        IPatientRepository _repository
        ,IJwtTokenGenerator _jwtTokenGenerator
        ,IPhoneNumberChecker _phoneNumberChecker
        , INationalCodeChecker _nationalCodeChecker
        ) 
        : IPatientRegisterService
    {
        private async Task Create(CreatePatientCMD item)
        {
            var mobile = new Mobile(item.Mobile);
            var nationalCode = new NationalCode(item.NationalCode);
            await _phoneNumberChecker.CheckNumber(item.Mobile);
            await _nationalCodeChecker.CheckNationalCode(item.NationalCode);
            var patient = new Patient(item.FirstName, item.LastName, mobile, nationalCode);
            await _repository.CreateAsync(patient);
        }
        public async Task<string> Register(CreatePatientCMD item)
        {
            await Create(item);
            var user = await _repository.FindByMobile(item.Mobile);
            GuardAgainstNullValue(user);
            return _jwtTokenGenerator.GeneratePatientToken(user);
        }
        private void GuardAgainstNullValue(User? user)
        {
            if (user == null)
                throw new DirectoryNotFoundException();
        }
    }

}
