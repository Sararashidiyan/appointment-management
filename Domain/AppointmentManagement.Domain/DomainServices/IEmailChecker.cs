namespace AppointmentManagement.Domain.DomainServices
{
    public interface IEmailChecker
    {
        Task CheckEmail(string email, long? id = null);
    }

}
