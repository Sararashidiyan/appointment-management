using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagement.Domain.Patients;
using AppointmentManagement.Query.Application.Interfaces.Patients.Data;

namespace AppointmentManagement.Query.Application.Mappers
{
    public class PatientMappers
    {
        public static PatientData? Map(Patient? patient)
        {
            if(patient == null)
                return null;
            return new PatientData
            {
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Email = patient.Email.Value,
                Mobile = patient.Mobile.Value,
                NationalCode = patient.NationalCode.Value
            };
        }
    }
}
