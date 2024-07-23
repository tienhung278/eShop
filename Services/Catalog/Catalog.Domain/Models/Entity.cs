namespace Catalog.Domain.Models;

public abstract class Entity
{
    public Guid Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public Guid LastModifiedBy { get; set; }
    public bool IsActive { get; set; }
}