namespace AppointmentManagement.Application.Interfaces.Notify
{
    public interface INotifyService
    {
        Task SendAsync(string type, string to);
        Task SendOtpAsync(string code, string to);
    }
}
