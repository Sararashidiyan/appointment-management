namespace AppointmentManagement.Application.Interfaces.Notify
{
    public class NotifyMessage
    {
        public string Type { get; set; }
        public string To { get; set; }
        public string Body { get; set; }
    }
}
