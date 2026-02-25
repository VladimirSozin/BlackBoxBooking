using MediatR;

namespace BlackBoxBoard.Server.Modules.Shared.Domain.Common;

public interface IDomainEvent : INotification
{
    DateTime OccurredOn { get; }
}