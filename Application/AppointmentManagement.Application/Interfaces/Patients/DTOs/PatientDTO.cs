using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagement.Domain.Patients;

namespace AppointmentManagement.Application.Interfaces.Patients.DTOs
{
    public class PatientDTO
    {
        public long Id { get;  set; }
        public string NationalCode { get;  set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
    }
 
}
