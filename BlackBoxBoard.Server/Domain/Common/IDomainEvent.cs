using MediatR;

namespace BlackBoxBoard.Server.Domain.Common;

public interface IDomainEvent : INotification
{
    DateTime OccurredOn { get; }
}