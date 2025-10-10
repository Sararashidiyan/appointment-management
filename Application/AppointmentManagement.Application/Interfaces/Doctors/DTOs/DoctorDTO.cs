using AppointmentManagement.Application.Interfaces.Experts.DTOs;

namespace AppointmentManagement.Application.Interfaces.Doctors.DTOs
{
    public class DoctorDTO
    {
        public long Id { get; set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string Email { get;  set; }
        public string Mobile { get;  set; }
        public bool IsActive { get;  set; }
        public List<ExpertDTO> Experts { get;  set; }

    }
}
