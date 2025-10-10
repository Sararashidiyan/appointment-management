namespace AppointmentManagement.Application.Interfaces.Doctors.DTOs
{
    public class ModifyDoctorCMD
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
    }
}
