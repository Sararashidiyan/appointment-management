namespace AppointmentManagement.Domain.DoctorSchedules
{
    public interface IDoctorOverrideScheduleRepository:IRepository<long ,DoctorOverrideSchedule>
    {
        Task<DoctorOverrideSchedule> getByDoctorId(long doctorId);
        Task<List<DoctorOverrideSchedule>> getAllByDoctorId(long doctorId);
    }
}
