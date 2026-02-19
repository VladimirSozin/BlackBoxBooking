using BlackBoxBoard.Server.Domain.Events;
using MediatR;

namespace BlackBoxBoard.Server.Application.EventHandlers
{
    public class RequestApprovedHandler : INotificationHandler<RequestApprovedEvent>
    {
        public async Task Handle(RequestApprovedEvent notification, CancellationToken cancellationToken)
        {
            // TODO: Implement
            await Task.CompletedTask;
        }
    }
}
