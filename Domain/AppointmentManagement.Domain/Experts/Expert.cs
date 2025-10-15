
using AppointmentManagement.Domain.Doctors.DoctorExperts;

namespace AppointmentManagement.Domain.Experts
{
    public class Expert: AuditableEntityBase<int>
    {
        public string Title { get; private set; }
        public string LatinTitle { get; private set; }
        public bool IsActive { get; private set; }
        public List<DoctorExpert> DoctorExperts { get; private set; }
        public Expert()
        {

        }
       
        public Expert(string title, string latinTitle)
        {
            Title = title;
            IsActive= true;
            LatinTitle = latinTitle;
        }

        public void Update(string title, string latinTitle)
        {
            Title = title;
            LatinTitle = latinTitle;
        }
        public void Activate()
        {
            IsActive = true;
        }
        public void Deactivate()
        {
            IsActive = false;
        }
    }
}
