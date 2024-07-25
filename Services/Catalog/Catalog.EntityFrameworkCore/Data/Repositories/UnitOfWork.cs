using Catalog.Application.Data;
using Catalog.Domain.Models;
using Microsoft.FeatureManagement;

namespace Catalog.EntityFrameworkCore.Data.Repositories;

public class UnitOfWork(ApplicationDbContext context, IFeatureManager featureManager) : IUnitOfWork
{
    private readonly Dictionary<Type, object?> _repositories = new();

    public IRepository<T> GetRepository<T>() where T : Entity
    {
        if (!_repositories.TryGetValue(typeof(T), out var repository))
        {
            repository = new Repository<T>(context, featureManager);
            _repositories.Add(typeof(T), repository);
        }

        return (IRepository<T>)repository;
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}