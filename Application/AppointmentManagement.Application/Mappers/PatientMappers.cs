using AppointmentManagement.Application.Interfaces.Patients.DTOs;
using AppointmentManagement.Domain.Doctors;
using AppointmentManagement.Domain.Patients;

namespace AppointmentManagement.Application.Mappers
{
    public class PatientMappers
    {
        public static List<PatientDTO> Map(List<Patient> patients)
        {
            return patients?.Select(Map).ToList();
        }

        public static PatientDTO Map(Patient patient)
        {
            return new PatientDTO
            {
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Mobile = patient.Mobile.Value,
                Email = patient.Email.Value,
                NationalCode = patient.NationalCode.Value,
            };
        }
    }
}
