using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagement.Domain.Users;

namespace AppointmentManagement.Domain.JwtTokenGenerator
{
    public interface IJwtTokenGenerator
    {
        string GeneratePatientToken(User user);
        string GenerateDoctorToken(User user);
        string GenerateUserToken(User user);
    }
}
