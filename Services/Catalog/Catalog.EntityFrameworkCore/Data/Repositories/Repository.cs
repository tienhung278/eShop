using BuildingBlocks.Pagination;
using Catalog.Application.Data;
using Catalog.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalog.EntityFrameworkCore.Data.Repositories;

public class Repository<T>(ApplicationDbContext context) : IRepository<T> where T : Entity
{
    private readonly DbSet<T> _dbSet = context.Set<T>();

    public async Task<IEnumerable<T>> GetAllAsync(PaginationRequest paginationRequest)
    {
        return await _dbSet
            .Skip(paginationRequest.PageIndex * paginationRequest.PageSize)
            .Take(paginationRequest.PageSize)
            .ToListAsync();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetByCriteriaAsync(Func<T, bool> criteria)
    {
        var items = _dbSet.Where(criteria);
        return await Task.FromResult(items);
    }

    public async Task<Guid> CreateAsync(T item, Guid actedBy)
    {
        item.CreatedAt = DateTime.UtcNow;
        item.CreatedBy = actedBy;
        item.IsActive = true;
        await _dbSet.AddAsync(item);
        return item.Id;
    }

    public async Task UpdateAsync(T item, Guid actedBy)
    {
        item.LastModified = DateTime.UtcNow;
        item.LastModifiedBy = actedBy;
        _dbSet.Update(item);
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(T item, Guid actedBy)
    {
        item.IsActive = false;
        item.LastModified = DateTime.UtcNow;
        item.LastModifiedBy = actedBy;
        _dbSet.Update(item);
        await Task.CompletedTask;
    }
}