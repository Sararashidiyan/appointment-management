namespace AppointmentManagement.Domain.DoctorSchedules
{
    public interface IDoctorOverrideScheduleRepository:IRepository<long ,DoctorOverrideSchedule>
    {
        Task<List<DoctorOverrideSchedule>> getAllByDoctorId(long doctorId);
    }
}
