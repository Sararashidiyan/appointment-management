using System.ComponentModel.DataAnnotations;

namespace AppointmentManagement.Application.Interfaces.Experts.DTOs
{
    public class CreateExpertCMD
    {
        [Required]public string Title { get; set; }
        [Required] public string LatinTitle { get; set; }
    }
}
