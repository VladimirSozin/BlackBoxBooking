using BlackBoxBoard.Server.Domain.Common;

namespace BlackBoxBoard.Server.Domain.Events;

public class EntityDeletedEvent : IDomainEvent
{
    public string EntityType { get; }
    public int EntityId { get; }
    public int DeletedBy { get; }
    public DateTime OccurredOn { get; }

    public EntityDeletedEvent(string entityType, int entityId, int deletedBy)
    {
        EntityType = entityType;
        EntityId = entityId;
        DeletedBy = deletedBy;
        OccurredOn = DateTime.UtcNow;
    }
}