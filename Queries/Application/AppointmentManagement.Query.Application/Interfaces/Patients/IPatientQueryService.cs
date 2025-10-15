using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagement.Query.Application.Interfaces.Appointments.Data;
using AppointmentManagement.Query.Application.Interfaces.Patients.Data;

namespace AppointmentManagement.Query.Application.Interfaces.Patients
{
    public interface IPatientQueryService
    {
        Task<PatientData> Profile();
        Task<List<AppointmentData>> GetPatientAppointments();
    }
}
