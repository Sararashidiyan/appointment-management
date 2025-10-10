using System.ComponentModel.DataAnnotations;

namespace AppointmentManagement.Application.Interfaces.Experts.DTOs
{
    public class ModifyExpertCMD
    {
        public int Id { get; set; }
        [Required]public string Title { get; set; }
        [Required]public string LatinTitle { get; set; }
    }
}
