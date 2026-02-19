using BlackBoxBoard.Server.Domain.Events;
using MediatR;

namespace BlackBoxBoard.Server.Application.EventHandlers
{
    public class RequestRejectedHandler : INotificationHandler<RequestRejectedEvent>
    {
        public async Task Handle(RequestRejectedEvent notification, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
    }
}
