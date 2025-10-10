namespace AppointmentManagement.Application.Interfaces.Patients.DTOs
{
    public class CreatePatientCMD
    {
        public string NationalCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
    }
}
