using BuildingBlocks.Pagination;
using Catalog.Domain.Models;

namespace Catalog.Application.Data;

public interface IRepository<T> where T : Entity
{
    Task<IEnumerable<T>> GetAllAsync(PaginationRequest paginationRequest);
    Task<IEnumerable<T>> GetByCriteriaAsync(Func<T, bool> criteria);
    Task<Guid> CreateAsync(T item, Guid actedBy);
    Task UpdateAsync(T item, Guid actedBy);
    Task DeleteAsync(T item, Guid actedBy);
}