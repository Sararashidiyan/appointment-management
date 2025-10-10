namespace AppointmentManagement.Domain.Doctors.DoctorExperts
{
    public class DoctorExpertReview : ValueObject
    {
        public long Id { get; set; }
        public DateTime CreateDateTime { get; private set; }
        public string Email { get; private set; }
        public string Comment { get; private set; }
        public DoctorExpertReview(string email, string comment)
        {
            CreateDateTime = DateTime.Now;
            Email = email;
            Comment = comment;
        }
    }
}
