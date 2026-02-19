using BlackBoxBoard.Server.Domain.Events;
using MediatR;

namespace BlackBoxBoard.Server.Application.EventHandlers
{
    public class RequestSentBackHandler : INotificationHandler<RequestSentBackEvent>
    {
        public async Task Handle(RequestSentBackEvent notification, CancellationToken cancellationToken)
        {
            // TODO: Implement
            await Task.CompletedTask;
        }
    }
}
