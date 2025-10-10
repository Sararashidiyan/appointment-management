using AppointmentManagement.Domain.Exceptions;

namespace AppointmentManagement.Domain.Appointments
{
    public class AppointmentDueDateTime: ValueObject
    {
        public DateTime Value { get; private set; }
        public bool IsExpire() => Value <= DateTime.Now;
        public AppointmentDueDateTime(DateTime date)
        {
            if (date <= DateTime.Now)
                throw new AppointmentExpiredException(date);
            Value = date;
        }
        private AppointmentDueDateTime() { }
    }
}
