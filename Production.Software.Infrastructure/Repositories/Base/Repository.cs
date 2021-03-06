using Microsoft.EntityFrameworkCore;
using Production.Software.Infrastructure.Data;

namespace Production.Software.Core.Repositories.Base;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly AppDbContext _appDbContext;

    public Repository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<T> AddAsync(T entity)
    {
        await _appDbContext.Set<T>().AddAsync(entity);
        await _appDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        _appDbContext.Set<T>().Remove(entity);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _appDbContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _appDbContext.Set<T>().FindAsync(id);
    }

    public Task UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }
}