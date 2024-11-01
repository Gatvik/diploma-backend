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
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}