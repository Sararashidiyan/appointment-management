using AppointmentManagement.Domain.DoctorSchedules;

namespace AppointmentManagement.Domain.ClinicSettings.ClinicSchedules
{
    public class ClinicSchedule:ScheduleTemplate
    {
        public int ClinicSettingId { get; set; }
      
        public ClinicSchedule(int clinicSettingId, SchaduleStartDate schaduleStartDate, List<WeeklySchedule> weeklySchedules)
            :base(schaduleStartDate,weeklySchedules)
        {
            ClinicSettingId = clinicSettingId;
        }
      
        public ClinicSchedule()
        {

        }
    }
}
