namespace AppointmentManagement.Domain.Appointments.AppointmentStates
{
    public enum AppointmentStateEnum
    {
        Requested,
        Compeleted,
        CancelledByPatient,
        CancelledByDoctor,
        Rejected,
        NoShow
    }
}
