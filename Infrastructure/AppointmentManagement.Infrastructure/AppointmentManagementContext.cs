using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagement.Application.Interfaces.SystemUserAuth;
using AppointmentManagement.Domain;
using AppointmentManagement.Domain.Appointments;
using AppointmentManagement.Domain.Doctors;
using AppointmentManagement.Domain.DoctorSchedules;
using AppointmentManagement.Domain.Experts;
using AppointmentManagement.Domain.Patients;
using AppointmentManagement.Domain.SystemUsers;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagement.Infrastructure
{
    public class AppointmentManagementContext : DbContext
    {
        private readonly ICurrentUserService _currentUserService;
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Expert> Experts { get; set; }
        public DbSet<DoctorDefaultSchedule> DoctorDefaultSchedules { get; set; }
        public DbSet<DoctorOverrideSchedule> DoctorOverrideSchedules { get; set; }
        public IQueryable<Appointment> PatientAppointments => Appointments.Where(s => s.CustomerId == _currentUserService.UserId);
        public IQueryable<Appointment> DoctorAppointments => Appointments.Where(s => s.DoctorExpertId == _currentUserService.UserId);
        public DbSet<SystemUser> SystemUsers { get; set; }

        public AppointmentManagementContext(DbContextOptions<AppointmentManagementContext> options)
            : base(options)
        { }
        public AppointmentManagementContext(DbContextOptions<AppointmentManagementContext> options, ICurrentUserService currentUserService )
          : base(options)
        {
            _currentUserService = currentUserService;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppointmentManagementContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<Auditable>())
            {
                if (entry.State == EntityState.Added)
                    entry.Property("CreatedAt").CurrentValue = DateTime.UtcNow;

                if (entry.State == EntityState.Modified)
                    entry.Property("UpdatedAt").CurrentValue = DateTime.UtcNow;
            }
            return base.SaveChangesAsync(cancellationToken);
        }

    }

}
