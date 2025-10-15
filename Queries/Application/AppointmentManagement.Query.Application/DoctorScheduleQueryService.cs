using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagement.Application.Interfaces.DoctorSchedules;
using AppointmentManagement.Core;
using AppointmentManagement.Domain.Appointments;
using AppointmentManagement.Domain.DoctorSchedules;
using AppointmentManagement.Infrastructure;
using AppointmentManagement.Infrastructure.Repositories;
using AppointmentManagement.Query.Application.Interfaces.DoctorSchedules.Data;
using AppointmentManagement.Query.Application.Mappers;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagement.Query.Application
{
    public class DoctorScheduleQueryService(AppointmentManagementContext _context) : IDoctorScheduleService
    {
        public async Task<List<DoctorScheduleData>> GetCurrentWeekScheduleByDoctorId(long doctorId)
        {
            var appointments = await GetAppointmentsByDoctorExpertIdForTheCurrentWeek(doctorId);
            var overrideSchedule = await GetByDoctorOverrideScheduleId(doctorId);
            if (overrideSchedule == null)
            {
                var defaultSchedule = await GetByDoctorDefaultScheduleId(doctorId);
                return DoctorScheduleMappers.Map(appointments, defaultSchedule);
            }
            return DoctorScheduleMappers.Map(appointments, overrideSchedule);
        }
        public Task<DoctorOverrideSchedule> GetByDoctorOverrideScheduleId(long doctorId)
        {
            var latestSaturday = DateExtensions.GetLatestSaturday();
            return _context.DoctorOverrideSchedules.FirstOrDefaultAsync(s => s.DoctorId == doctorId && s.SchaduleStartDate.Value == latestSaturday);

        }
        public async Task<DoctorDefaultSchedule> GetByDoctorDefaultScheduleId(long doctorId)
        {
            return await _context.DoctorDefaultSchedules.Where(s => s.DoctorId == doctorId).OrderBy(s => s.SchaduleStartDate.Value).FirstOrDefaultAsync();
        }
        private async Task<List<Appointment>> GetAppointmentsByDoctorExpertIdForTheCurrentWeek(long doctorExpertId)
        {
            var fromdate = DateExtensions.GetLatestSaturday();
            var todate = fromdate.AddDays(7);
            return await _context.DoctorAppointments
                .Where(s => s.DueDateTime.Value >= fromdate && s.DueDateTime.Value <= todate
                && s.DoctorExpertId == doctorExpertId).ToListAsync();
        }
    }
}
