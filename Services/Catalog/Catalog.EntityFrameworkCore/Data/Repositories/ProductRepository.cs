using Catalog.Application.Data;
using Catalog.Domain.Models;
using Microsoft.FeatureManagement;

namespace Catalog.EntityFrameworkCore.Data.Repositories;

public class ProductRepository(ApplicationDbContext context, IFeatureManager featureManager) : Repository<Product>(context, featureManager), IProductRepository
{
}