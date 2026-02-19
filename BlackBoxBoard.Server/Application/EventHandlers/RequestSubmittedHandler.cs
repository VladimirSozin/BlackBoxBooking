using BlackBoxBoard.Server.Domain.Events;
using MediatR;

namespace BlackBoxBoard.Server.Application.EventHandlers
{
    public class RequestSubmittedHandler : INotificationHandler<RequestSubmittedEvent>
    {
        public async Task Handle(RequestSubmittedEvent notification, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
    }
}
