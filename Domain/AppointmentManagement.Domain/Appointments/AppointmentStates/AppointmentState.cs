namespace AppointmentManagement.Domain.Appointments.AppointmentStates
{
    public abstract class AppointmentState
    {
        public virtual void Request(Appointment appointment) =>
        throw new InvalidOperationException("Confirm not allowed in this state.");
        public virtual void Compelete(Appointment appointment) =>
        throw new InvalidOperationException("Compelete not allowed in this state.");
        public virtual void CancelByPatient(Appointment appointment) =>
        throw new InvalidOperationException("CancelByPatient not allowed in this state.");
        public virtual void CancelByDoctor(Appointment appointment, string reseon) =>
        throw new InvalidOperationException("CancelByDoctor not allowed in this state.");
        public virtual void Reject(Appointment appointment,string reseon) =>
        throw new InvalidOperationException("Reject not allowed in this state.");
        public virtual void NoShow(Appointment appointment) =>
        throw new InvalidOperationException("NoShow not allowed in this state.");

    }
}
