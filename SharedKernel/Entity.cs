using SharedKernel.Enums;

namespace SharedKernel;

public abstract class Entity
{
    private readonly List<IDomainEvent> _domainEvents = new();

    protected Entity(Guid id)
    {
        Id = id;
    }

    protected Entity()
    {
    }

    public Guid Id { get; init; }
    public StatusType Status { get; private set; }

    public List<IDomainEvent> DomainEvents => _domainEvents.ToList();

    public virtual void SoftDelete()
    {
        Status = StatusType.Deleted;
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected void Raise(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}
