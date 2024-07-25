using BuildingBlocks.Pagination;
using Catalog.Application.Data;
using Catalog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.FeatureManagement;

namespace Catalog.EntityFrameworkCore.Data.Repositories;

public class Repository<T>(ApplicationDbContext context, IFeatureManager featureManager) : IRepository<T> where T : Entity
{
    private readonly DbSet<T> _dbSet = context.Set<T>();

    public async Task<IEnumerable<T>> GetAllAsync(PaginationRequest paginationRequest)
    {
        return await _dbSet
            .AsNoTracking()
            .Skip(paginationRequest.PageIndex * paginationRequest.PageSize)
            .Take(paginationRequest.PageSize)
            .ToListAsync();
    }

    public async Task<IEnumerable<T>> GetByCriteriaAsync(Func<T, bool> criteria)
    {
        var items = _dbSet.AsNoTracking().Where(criteria);
        return await Task.FromResult(items);
    }

    public async Task<Guid> CreateAsync(T item, Guid actedBy)
    {
        item.CreatedBy = actedBy;
        item.CreatedAt = DateTime.Now;
        item.IsActive = true;
        await _dbSet.AddAsync(item);
        
        return item.Id;
    }

    public async Task UpdateAsync(T item, Guid actedBy)
    {
        item.LastModifiedBy = actedBy;
        item.LastModified = DateTime.Now;
        item.IsActive = true;
        _dbSet.Update(item);
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(T item, Guid actedBy)
    {
        if (await featureManager.IsEnabledAsync("SoftDelete"))
        {
            item.LastModifiedBy = actedBy;
            item.LastModified = DateTime.Now;
            item.IsActive = false;
            _dbSet.Update(item);
        }
        else
        {
            _dbSet.Remove(item);
        }
        await Task.CompletedTask;
    }
}