using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagement.Application.Interfaces.DoctorSchedules;
using AppointmentManagement.Application.Interfaces.DoctorSchedules.DTOs.DoctorSchedule;
using AppointmentManagement.Application.Mappers;
using AppointmentManagement.Domain.Appointments;
using AppointmentManagement.Domain.DoctorSchedules;

namespace AppointmentManagement.Application
{
    public class DoctorScheduleService(IDoctorDefaultScheduleRepository _defaultScheduleRepository, 
        IDoctorOverrideScheduleRepository _doctorOverrideScheduleRepository,
        IAppointmentRepository _appointmentRepository) : IDoctorScheduleService
    {
        public async Task<List<DoctorScheduleDTO>> GetCurrentWeekScheduleByDoctorId(long doctorId)
        {
            var appointments = await _appointmentRepository.GetAppointmentsByDoctorExpertIdForTheCurrentWeek(doctorId);
            var overrideSchedule = await _doctorOverrideScheduleRepository.getByDoctorId(doctorId);
            if (overrideSchedule == null)
            {
                var defaultSchedule = await _defaultScheduleRepository.getByDoctorId(doctorId);
                return DoctorScheduleMappers.Map(appointments, defaultSchedule);
            }
            return DoctorScheduleMappers.Map(appointments, overrideSchedule);
        }
        public async Task<List<DoctorDefaultScheduleDTO>> GetDoctorDefaultSchedules(long doctorId)
        {
            var overrideSchedule = await _defaultScheduleRepository.getAllByDoctorId(doctorId);
            return DoctorScheduleMappers.Map(overrideSchedule);

        }
        public async Task<List<DoctorOverrideScheduleDTO>> GetDoctorOverrideSchedules(long doctorId)
        {
            var defaultSchedule = await _doctorOverrideScheduleRepository.getAllByDoctorId(doctorId);
            return DoctorScheduleMappers.Map(defaultSchedule);
        }
    }
}
