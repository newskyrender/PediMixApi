namespace PediMix.Domain.Common;

public abstract class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public bool IsDeleted { get; set; } = false;
}

public abstract class BaseEntityWithUser : BaseEntity
{
    public string CreatedById { get; set; } = string.Empty;
    public string UpdatedById { get; set; } = string.Empty;
}
