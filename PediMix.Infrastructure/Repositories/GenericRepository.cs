using Microsoft.EntityFrameworkCore;
using PediMix.Application.Interfaces;
using PediMix.Infrastructure.Data;

namespace PediMix.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly PediMixDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(PediMixDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public virtual async Task<T?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public virtual async Task<T> UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        return await Task.FromResult(entity);
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
        }
    }

    public virtual async Task<bool> ExistsAsync(Guid id)
    {
        return await _dbSet.FindAsync(id) != null;
    }
}
