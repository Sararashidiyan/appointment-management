namespace AppointmentManagement.Domain.DomainServices
{
    public interface IPhoneNumberChecker
    {
        Task CheckNumber(string number, long? id = null);
    }

}
