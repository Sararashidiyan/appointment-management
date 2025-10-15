using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagement.Query.Application.Interfaces.Doctors.Data;

namespace AppointmentManagement.Query.Application.Interfaces.Doctors
{
    public interface IDoctorQueryService
    {
        Task<List<DoctorExpertData>> GetDoctorExpertsByCity(string city);
    }
}
