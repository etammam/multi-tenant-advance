namespace MultiTenant.Catalog.Domain.Common;

public abstract class BaseEntity<TKey> : IBaseEntity<TKey>
{
    protected BaseEntity() => HandleGuidPrimaryKeyGeneration(); 

    public TKey Id { get; set; } = default!;

    public DateTime CreationDate { get; protected set; }

    public string CreatedByName { get; protected set; } = string.Empty;

    public Guid CreatedById { get; protected set; }

    public DateTime? ModificationDate { get; protected set; }

    public string ModifiedByName { get; protected set; } = string.Empty;

    public Guid? ModifiedById { get; protected set; }

    public DateTime? InactiveDate { get; protected set; }
    
    private void HandleGuidPrimaryKeyGeneration()
    {
        if (typeof(TKey) == typeof(Guid))
        {
            GetType().GetProperty(nameof(Id))?.SetValue(this, Guid.NewGuid());
        }
    }
}