namespace AppointmentManagement.Domain.Doctors.DoctorExperts
{
    public class DoctorExpertRate:ValueObject
    {
        public long Id { get; set; }
        public DateTime CreateDateTime { get; private set; }
        public string Email { get; private set; }
        public float Rate { get; private set; }
        public DoctorExpertRate(string email, float rate)
        {
            CreateDateTime = DateTime.Now;
            Email = email;
            Rate = rate;
        }
    }
}
