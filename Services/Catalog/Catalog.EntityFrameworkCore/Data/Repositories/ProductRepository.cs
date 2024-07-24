using Catalog.Application.Data;
using Catalog.Domain.Models;

namespace Catalog.EntityFrameworkCore.Data.Repositories;

public class ProductRepository(ApplicationDbContext context) : Repository<Product>(context), IProductRepository
{
    
}