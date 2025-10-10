namespace AppointmentManagement.Domain.Exceptions
{
    public class DoctorScheduleOverlapException : DomaiException
    {
        public DoctorScheduleOverlapException() : base("Doctor schedule overlap.") { }
    }
}
