using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Application.Interfaces.Experts.DTOs
{
    public class ExpertDTO
    {
        public int Id { get;  set; }
        public string Title { get;  set; }
        public string LatinTitle { get;  set; }
        public bool IsActive { get;  set; }
    }
}
