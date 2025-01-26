using System.Linq.Expressions;
using Api.Application.Contracts.Persistence;
using Api.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly DataContext Context;

    public GenericRepository(DataContext context)
    {
        Context = context;
    }
    
    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await Context.Set<T>().AsNoTracking().ToListAsync();
    }

    public IQueryable<T> GetAllAsQueryable()
    {
        return Context.Set<T>().AsNoTracking();
    }

    public IQueryable<T> GetAllAsQueryable(params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = Context.Set<T>().AsNoTracking();
        
        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return query;
    }
    
    public async Task<IReadOnlyList<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = Context.Set<T>().AsNoTracking();

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.ToListAsync();
    }

    public async Task<IReadOnlyList<T>> GetAllByPredicateAsync(Expression<Func<T, bool>> predicate)
    {
        return await Context.Set<T>().AsNoTracking().Where(predicate).ToListAsync();
    }
    
    public async Task<IReadOnlyList<T>> GetAllByPredicateAsync(
        Expression<Func<T, bool>> predicate,
        params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = Context.Set<T>().AsNoTracking();

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.Where(predicate).ToListAsync();
    }

    public Task<T?> GetByIdAsync(Guid id)
    {
        return GetByPredicateAsync(q => q.Id == id);
    }
    
    public async Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = Context.Set<T>().AsNoTracking();

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.FirstOrDefaultAsync(entity => entity.Id == id);
    }

    public Task<T?> GetByPredicateAsync(Expression<Func<T, bool>> predicate)
    {
        return Context.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);
    }
    
    public async Task<T?> GetByPredicateAsync(
        Expression<Func<T, bool>> predicate,
        params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = Context.Set<T>().AsNoTracking();

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.FirstOrDefaultAsync(predicate);
    }
    
    public async Task CreateAsync(T entity)
    {
        await Context.AddAsync(entity);
        await Context.SaveChangesAsync();
    }
    
    public async Task CreateRangeAsync(IEnumerable<T> entity)
    {
        await Context.AddRangeAsync(entity);
        await Context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
        await Context.SaveChangesAsync();
    }
    
    public async Task UpdateRangeAsync(IEnumerable<T> entities)
    {
        Context.UpdateRange(entities);
        await Context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        Context.Remove(entity);
        await Context.SaveChangesAsync();
    }
}