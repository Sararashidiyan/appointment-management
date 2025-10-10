namespace AppointmentManagement.Application.Interfaces.Appointments.DTOs
{
    public class AppointmentDTO
    {
        public long CustomerId { get;  set; }
        public string CustomerFullName { get;  set; }
        public string DayOfWeek { get;  set; }
        public DateTime DueDate { get;  set; }
        public TimeSpan DueTime { get;  set; }
    }
}
