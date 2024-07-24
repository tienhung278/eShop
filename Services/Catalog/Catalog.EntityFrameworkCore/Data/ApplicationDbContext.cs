using System.Reflection;
using Catalog.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalog.EntityFrameworkCore.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.Entity<Product>().HasQueryFilter(e => e.IsActive);
        base.OnModelCreating(modelBuilder);
    }
}