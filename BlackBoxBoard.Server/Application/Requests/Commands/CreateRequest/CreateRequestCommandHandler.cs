using MediatR;

namespace BlackBoxBoard.Server.Application.Requests.Commands.CreateRequest
{
    public class CreateRequestCommandHandler : IRequestHandler<CreateRequestCommand, int>
    {
        public async Task<int> Handle(CreateRequestCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(1);
        }
    }
}
