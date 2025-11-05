namespace AppointmentManagement.Domain.DomainServices
{
    public interface INationalCodeChecker
    {
        Task CheckNationalCode(string number, long? id = null);
    }

}
