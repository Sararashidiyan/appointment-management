using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagement.Domain.Appointments.AppointmentStates;

namespace AppointmentManagement.Domain.Appointments
{
    public class Appointment:EntityBase<long>,IAggrigateRoot
    {
        public long CustomerId { get; private set; }
        public long DoctorExpertId { get; private set; }
        public string CustomerFullName { get; private set; }
        public string DayOfWeek { get; private set; }
        public AppointmentDueDateTime DueDateTime { get; private set; }
        public AppointmentState State { get; set; }
        public AppointmentStateEnum StateId { get; set; }
        public string StateReseon { get; set; }
        public bool IsExpire => DueDateTime.IsExpire();
        public Appointment(long customerId,
            long doctorExpertId, string customerFullName, string dayOfWeek, AppointmentDueDateTime dateTime)
        {
            CustomerId = customerId;
            DoctorExpertId = doctorExpertId;
            CustomerFullName = customerFullName;
            DayOfWeek = dayOfWeek;
            DueDateTime = dateTime;
            State = new RequestedState();
            StateId = AppointmentStateEnum.Requested;
        }
        public Appointment()
        {

        }
        public void Compelete() => State.Compelete(this);
        public void CancelByPatient() => State.CancelByPatient(this);
        public void CancelByDoctor(string reseon) => State.CancelByDoctor(this, reseon);
        public void Reject(string reseon) => State.Reject(this, reseon);
        public void NoShow() => State.NoShow(this);
    }
}
