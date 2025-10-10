namespace AppointmentManagement.Domain
{
    public abstract class EntityBase<T> : Auditable
    {
        public T Id { get; set; }
    }
    public abstract class ValueObject 
    {
    }
}
