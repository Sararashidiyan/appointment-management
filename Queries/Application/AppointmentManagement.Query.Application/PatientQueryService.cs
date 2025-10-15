using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagement.Domain.Patients;
using AppointmentManagement.Query.Application.Interfaces.Patients;
using AppointmentManagement.Infrastructure;
using AppointmentManagement.Application.Interfaces.SystemUserAuth;
using Microsoft.EntityFrameworkCore;
using AppointmentManagement.Query.Application.Interfaces.Patients.Data;
using AppointmentManagement.Query.Application.Mappers;
using AppointmentManagement.Query.Application.Interfaces.Appointments.Data;

namespace AppointmentManagement.Query.Application
{
    public class PatientQueryService(AppointmentManagementContext _context, ICurrentUserService currentUserService) : IPatientQueryService
    {
        public async Task<PatientData> Profile()
        {
            var userId = currentUserService.UserId;
            var patient = await _context.Patients.FirstOrDefaultAsync(s=>s.Id==userId);
            GuardAgainstNullValue(patient);
            return PatientMappers.Map(patient);
        }
        public async Task<List<AppointmentData>> GetPatientAppointments()
        {
            var appointments = await _context.PatientAppointments.ToListAsync();
            return AppointmentMappers.Map(appointments);
        }
        private void GuardAgainstNullValue(Patient? patient)
        {
            if (patient == null)
                throw new DirectoryNotFoundException();
        }
    }
}
