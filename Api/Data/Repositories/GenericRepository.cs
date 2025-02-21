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

    public int Count(Expression<Func<T, bool>>? predicate = null)
    {
        IQueryable<T> set = Context.Set<T>().AsNoTracking();
        if (predicate is not null)
            set = set.Where(predicate);

        return set.Count();
    }
    
    public async Task<IReadOnlyList<T>> GetAllAsync(
        int? pageNumber = null, 
        int? pageSize = null, 
        Expression<Func<T, object>>? orderBy = null, 
        bool descending = false, 
        params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = Context.Set<T>().AsNoTracking();
        
        foreach (var include in includes)
        {
            query = query.Include(include);
        }
        
        if (orderBy != null)
        {
            query = descending ? query.OrderByDescending(orderBy) : query.OrderBy(orderBy);
        }
        
        if (pageNumber is not null && pageSize is not null)
            query = query.Skip((pageNumber.Value - 1) * pageSize.Value).Take(pageSize.Value);

        return await query.ToListAsync();
    }
    
    public async Task<IReadOnlyList<T>> GetAllByPredicateAsync(
        Expression<Func<T, bool>> predicate,
        int? pageNumber = null, int? pageSize = null,
        Expression<Func<T, object>>? orderBy = null, 
        bool descending = false, 
        params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = Context.Set<T>().AsNoTracking();

        foreach (var include in includes)
        {
            query = query.Include(include);
        }
        
        if (orderBy != null)
        {
            query = descending ? query.OrderByDescending(orderBy) : query.OrderBy(orderBy);
        }

        if (pageNumber is not null && pageSize is not null)
            query = query.Where(predicate).Skip((pageNumber.Value - 1) * pageSize.Value).Take(pageSize.Value);
        else
            query = query.Where(predicate);

        return await query.ToListAsync();
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
    
    public async Task<T?> GetSingleByPredicateAsync(
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