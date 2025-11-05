using System.ComponentModel.DataAnnotations;

namespace AppointmentManagement.Application.Interfaces.Patients.DTOs
{
    public class CreatePatientCMD
    {
        [Required]public string NationalCode { get; set; }
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public string Mobile { get; set; }
    }
}
