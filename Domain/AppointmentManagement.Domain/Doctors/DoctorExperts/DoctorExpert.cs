
using AppointmentManagement.Domain.Experts;

namespace AppointmentManagement.Domain.Doctors.DoctorExperts
{
    public class DoctorExpert
    {
        public DoctorExpert(int expertId)
        {
            ExpertId = expertId;
        }
        public int Id { get; private set; }
        public long DoctorId { get; private set; }
        public int ExpertId { get; private set; }
        public Doctor Doctor { get; private set; }
        public Expert Expert { get; private set; }
        public bool IsActive { get; private set; }
        public void AddRate(DoctorExpertRate doctorRate)
        {
            DoctorRates.Add(doctorRate);
        }
        public void AddReview(DoctorExpertReview doctorExpertReview)
        {
            DoctorExpertReviews.Add(doctorExpertReview);
        }
        public void Activate()
        {
            IsActive = true;
        }
        public void Deactivate()
        {
            IsActive = false;
        }
        public ICollection<DoctorExpertReview> DoctorExpertReviews { get; set; } = new List<DoctorExpertReview>();
        public ICollection<DoctorExpertRate> DoctorRates { get; set; } = new List<DoctorExpertRate>();
    }
}
