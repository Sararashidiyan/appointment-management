namespace AppointmentManagement.Domain.DoctorSchedules
{
    public interface IDoctorDefaultScheduleRepository
    {
        Task<List<DoctorDefaultSchedule>> getAllByDoctorId(long doctorId);
    }
}
