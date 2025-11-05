using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Domain.OTPGenerator
{
    public interface IOtpGenerator
    {
        string GenerateOtp(string mobile, int length = 4, int expiryMinutes = 5);
        bool ValidateOtp(string mobile, string inputOtp);
    }
}
