using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagement.Infrastructure;
using AppointmentManagement.Query.Application.Interfaces.Doctors;
using AppointmentManagement.Query.Application.Interfaces.Doctors.Data;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagement.Query.Application
{
    public class DoctorQueryService(AppointmentManagementContext _context) : IDoctorQueryService
    {
        public async Task<List<DoctorExpertData>> GetDoctorExpertsByCity(string city)
        {
            var doctorsWithExperts = await _context.Doctors.Where(s=>s.Location.Name.Equals(city))
                         .Include(d => d.DoctorExperts).ThenInclude(e=>e.Expert)
                         .Include(d => d.DoctorExperts).ThenInclude(e=>e.Doctor).ToListAsync();

            var grouped = doctorsWithExperts
                .SelectMany(d => d.DoctorExperts
                .Select(e => new {Description=e.Description, ExpertTitle = e.Expert.Title, Doctor = d }))
                .GroupBy(x => x.ExpertTitle)
                .Select(g => new DoctorExpertData
                {
                    Expert=g.Key,
                    Doctors= g.Select(x =>new DoctorData { Description=x.Description, FullName =x.Doctor.FullName}).Distinct().ToList()
                }).ToList();
            return grouped;

        }
    }
}
