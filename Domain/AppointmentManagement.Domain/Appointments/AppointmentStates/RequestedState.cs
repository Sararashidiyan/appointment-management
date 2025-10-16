using AppointmentManagement.Domain.Exceptions;

namespace AppointmentManagement.Domain.Appointments.AppointmentStates
{
    public class RequestedState : AppointmentState
    {
        public override void Compelete(Appointment appointment)
        {
            //if (!appointment.IsExpire)
            //    throw new AppointmentNotExpiredException(appointment.DueDateTime.Value);
            appointment.State = new CompeletedState();
            appointment.StateId = AppointmentStateEnum.Compeleted;
            appointment.ChangeStateAt = DateTime.Now;
        }
        public override void Reject(Appointment appointment, string reseon)
        {
            if (appointment.IsExpire)
                throw new AppointmentExpiredException(appointment.DueDateTime.Value);
            appointment.State = new RejectedState();
            appointment.StateId = AppointmentStateEnum.Rejected;
            appointment.StateReseon = reseon;
            appointment.ChangeStateAt = DateTime.Now;
        }
        public override void CancelByDoctor(Appointment appointment, string reseon)
        {
            if (appointment.IsExpire)
                throw new AppointmentExpiredException(appointment.DueDateTime.Value);
            appointment.State = new CancelledByDoctorState();
            appointment.StateId = AppointmentStateEnum.CancelledByDoctor;
            appointment.StateReseon = reseon;
            appointment.ChangeStateAt = DateTime.Now;
        }
        public override void CancelByPatient(Appointment appointment)
        {
            if (appointment.IsExpire)
                throw new AppointmentExpiredException(appointment.DueDateTime.Value);
            appointment.State = new CancelledByPatientState();
            appointment.StateId = AppointmentStateEnum.CancelledByPatient;
            appointment.ChangeStateAt = DateTime.Now;
        }
        public override void NoShow(Appointment appointment)
        {
            if (!appointment.IsExpire)
                throw new AppointmentNotExpiredException(appointment.DueDateTime.Value);
            appointment.State = new NoShowState();
            appointment.StateId = AppointmentStateEnum.NoShow;
            appointment.ChangeStateAt = DateTime.Now;
        }
    }
}
