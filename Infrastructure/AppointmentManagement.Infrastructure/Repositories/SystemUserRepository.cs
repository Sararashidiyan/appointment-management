﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagement.Domain.SystemUsers;
using AppointmentManagement.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagement.Infrastructure.Repositories
{
    public class SystemUserRepository :BaseRepository<long,SystemUser>, ISystemUserRepository
    {
        private readonly AppointmentManagementContext _context;
        public SystemUserRepository(AppointmentManagementContext context) : base(context)
        {
            _context = context;
        }
        public async override Task<List<SystemUser>> GetAllAsync()
        {
            return await _context.SystemUsers.Where(s=>!s.IsSupperAdmin).ToListAsync();
        }
        public async Task<SystemUser> FindByEmail(string email)
        {
            return await _context.SystemUsers.FirstOrDefaultAsync(s => s.Email.Value.Equals(email));
        }
        public async Task<SystemUser> FindByMobile(string mobile)
        {
            return await _context.SystemUsers.FirstOrDefaultAsync(s => s.Mobile.Value.Equals(mobile));

        }
    }
}
