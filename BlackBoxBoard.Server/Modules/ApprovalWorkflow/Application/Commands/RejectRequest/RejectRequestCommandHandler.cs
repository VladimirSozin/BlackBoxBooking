using MediatR;

namespace BlackBoxBoard.Server.Modules.ApprovalWorkflow.Application.Commands.RejectRequest
{
    public class RejectRequestCommandHandler : IRequestHandler<RejectRequestCommand>
    {
        public async Task Handle(RejectRequestCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
    }
}
