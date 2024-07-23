using Catalog.Domain.Models;

namespace Catalog.Application.Data;

public interface IUnitOfWork
{
    IRepository<T> GetRepository<T>() where T : Entity;
    Task SaveChangesAsync();
}