using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagement.Domain.DoctorSchedules;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagement.Infrastructure.Repositories
{
    public class DoctorDefaultScheduleRepository(AppointmentManagementContext _context): IDoctorDefaultScheduleRepository
    {
        public async Task<List<DoctorDefaultSchedule>> getAllByDoctorId(long doctorId)
        {
            return await _context.DoctorDefaultSchedules.Where(s=>s.DoctorId== doctorId).ToListAsync();
        }
        
    }
}
