using Catalog.Application.Data;
using Catalog.Domain.Models;

namespace Catalog.EntityFrameworkCore.Data.Repositories;

public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    private readonly Dictionary<Type, object?> _repositories = new Dictionary<Type, object?>();
    
    public IRepository<T> GetRepository<T>() where T : Entity
    {
        if (!_repositories.TryGetValue(typeof(T), out object? repository))
        {
            repository = new Repository<T>(context);
            _repositories.Add(typeof(T), repository);
        }

        return (IRepository<T>)repository;

    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();

    }
}