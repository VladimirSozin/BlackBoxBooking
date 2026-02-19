using MediatR;

namespace BlackBoxBoard.Server.Application.Requests.Commands.ApproveRequest
{
    public class ApproveRequestCommandHandler : IRequestHandler<ApproveRequestCommand>
    {
        public async Task Handle(ApproveRequestCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
    }
}
