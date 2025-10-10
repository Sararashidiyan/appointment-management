using AppointmentManagement.Application.Interfaces.Doctors.DTOs;
using AppointmentManagement.Domain.Doctors;

namespace AppointmentManagement.Application.Mappers
{
    public class DoctorMappers
    {
        public static DoctorDTO Map(Doctor doctor)
        {
            return new DoctorDTO
            {
                FirstName=doctor.FirstName,
                LastName=doctor.LastName,
                Mobile=doctor.Mobile.Value,
                Email=doctor.Email.Value,
                IsActive=doctor.IsActive,
            };
        }

        public static List<DoctorDTO> Map(List<Doctor> doctors)
        {
            return doctors?.Select(Map).ToList();
        }
    } 
}
