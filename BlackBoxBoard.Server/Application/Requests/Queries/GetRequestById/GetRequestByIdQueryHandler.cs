using MediatR;

namespace BlackBoxBoard.Server.Application.Requests.Queries.GetRequestById
{
    public class GetRequestByIdQueryHandler : IRequestHandler<GetRequestByIdQuery, RequestDto>
    {
        public async Task<RequestDto> Handle(GetRequestByIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new RequestDto());
        }
    }
}
