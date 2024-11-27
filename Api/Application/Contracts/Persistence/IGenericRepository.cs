using System.Linq.Expressions;
using Api.Domain.Common;

namespace Api.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<IReadOnlyList<T>> GetAllByPredicateAsync(Expression<Func<T, bool>> predicate);
    Task<T?> GetByIdAsync(Guid id);
    Task<T?> GetByPredicateAsync(Expression<Func<T, bool>> predicate);
    Task CreateAsync(T entity);
    Task CreateRangeAsync(IEnumerable<T> entity);
    Task UpdateAsync(T entity);
    Task UpdateRangeAsync(IEnumerable<T> entities);
    Task DeleteAsync(T entity);

    public Task<IReadOnlyList<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
    public Task<IReadOnlyList<T>> GetAllByPredicateAsync(Expression<Func<T, bool>> predicate,
        params Expression<Func<T, object>>[] includes);
    public Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes);
    public Task<T?> GetByPredicateAsync(Expression<Func<T, bool>> predicate,
        params Expression<Func<T, object>>[] includes);
}