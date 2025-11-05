using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagement.Domain.Exceptions;
using AppointmentManagement.Domain.Users;

namespace AppointmentManagement.Domain.Patients
{
    public class Patient : User
    {
        public Patient()
        {

        }
        public Patient(string firstName, string lastName, Mobile mobile, NationalCode nationalCode)
            : base(firstName, lastName, mobile,RoleType.Patient)
        {
            NationalCode=nationalCode;

        }
        public void Update(string firstName, string lastName, Email email, NationalCode nationalCode)
        {
            Update(firstName, lastName, email);
            NationalCode=nationalCode;
        }
        public NationalCode NationalCode { get; private set; }
        

    }
}

