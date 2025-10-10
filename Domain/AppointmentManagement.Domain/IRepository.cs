namespace AppointmentManagement.Domain
{
    public interface IRepository<TKey,T> where T : class
    {
        Task<T> GetByIdAsync(TKey id);
        Task DeleteAsync(T item);
        Task CreateAsync(T item);
        Task<List<T>> GetAllAsync();
    }
}
