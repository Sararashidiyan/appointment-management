using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Domain.Appointments
{
    public class AppointmentDomainService(IAppointmentRepository _repository)
    {
        public async Task<bool> CanPlaceAppointment(DateTime dueDateTime, long patientId,long doctorExpertId)
        {
            var isAppointmentOverlapping = await _repository.IsAppointmentOverlapping(dueDateTime, doctorExpertId);
            if (isAppointmentOverlapping)
                throw new Exception();
            var isCurrentPatientScheduledWithDoctorExpert = await _repository.IsCurrentPatientScheduledWithDoctorExpert(patientId, doctorExpertId);
            if (isCurrentPatientScheduledWithDoctorExpert)
                throw new Exception();
            return !(isAppointmentOverlapping && isCurrentPatientScheduledWithDoctorExpert);
        }
        
    }
}
