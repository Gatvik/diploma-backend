﻿using System.Linq.Expressions;
using Api.Domain.Common;

namespace Api.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<IReadOnlyList<T>> GetAllAsync(int? pageNumber = null, int? pageSize = null, 
        Expression<Func<T, object>>? orderBy = null, 
        bool descending = false, 
        params Expression<Func<T, object>>[] includes);
    Task<IReadOnlyList<T>> GetAllByPredicateAsync(Expression<Func<T, bool>> predicate, int? pageNumber = null, int? pageSize = null,
        Expression<Func<T, object>>? orderBy = null, 
        bool descending = false, 
        params Expression<Func<T, object>>[] includes);
    Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes);
    Task<T?> GetSingleByPredicateAsync(Expression<Func<T, bool>> predicate,
        params Expression<Func<T, object>>[] includes);
    Task CreateAsync(T entity);
    Task CreateRangeAsync(IEnumerable<T> entity);
    Task UpdateAsync(T entity);
    Task UpdateRangeAsync(IEnumerable<T> entities);
    Task DeleteAsync(T entity);

    
}