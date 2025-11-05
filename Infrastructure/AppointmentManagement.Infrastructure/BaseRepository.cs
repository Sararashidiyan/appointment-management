using AppointmentManagement.Domain;
using AppointmentManagement.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagement.Infrastructure
{
    public abstract class BaseRepository<TKey, T>(AppointmentManagementContext context) : IRepository<TKey, T> where T : class
    {
        public readonly AppointmentManagementContext _context;
        public async Task CreateAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(TKey id)
        {
            return await context.Set<T>().FindAsync(id);
        }
    }
}
