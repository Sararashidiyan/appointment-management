namespace AppointmentManagement.Domain
{
    public abstract class EntityBase<T>
    {
        public T Id { get; set; }
    }
    public abstract class AuditableEntityBase<T> : Auditable
    {
        public T Id { get; set; }
    }
    public abstract class ValueObject 
    {
    }
}
