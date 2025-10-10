namespace AppointmentManagement.Domain.DoctorSchedules
{
    public interface IDoctorDefaultScheduleRepository
    {
        Task<DoctorDefaultSchedule> getByDoctorId(long doctorId);
        Task<List<DoctorDefaultSchedule>> getAllByDoctorId(long doctorId);
    }
}
