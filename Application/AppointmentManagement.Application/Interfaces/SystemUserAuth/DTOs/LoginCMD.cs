using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Application.Interfaces.SystemUserAuth.DTOs
{
    public class LoginCMD
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
