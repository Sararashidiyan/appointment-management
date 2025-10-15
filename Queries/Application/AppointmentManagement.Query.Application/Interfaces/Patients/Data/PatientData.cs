using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Query.Application.Interfaces.Patients.Data
{
    public class PatientData
    {
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Email { get;  set; }
        public string Mobile { get;  set; }
        public string NationalCode { get;  set; }
    }
}
