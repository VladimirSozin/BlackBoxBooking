using MediatR;

namespace BlackBoxBoard.Server.Application.Requests.Commands.SendBackRequest
{
    public class SendBackRequestCommandHandler : IRequestHandler<SendBackRequestCommand>
    {
        public async Task Handle(SendBackRequestCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
    }
}
