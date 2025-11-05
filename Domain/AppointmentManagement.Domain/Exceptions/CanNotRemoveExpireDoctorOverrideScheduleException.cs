namespace AppointmentManagement.Domain.Exceptions
{
    public class CanNotRemoveExpireDoctorOverrideScheduleException : DomaiException
    {
        public CanNotRemoveExpireDoctorOverrideScheduleException()
            : base($"Can not remove expire doctorTemproryScheduleOverride.")
        {
        }
    }
}
