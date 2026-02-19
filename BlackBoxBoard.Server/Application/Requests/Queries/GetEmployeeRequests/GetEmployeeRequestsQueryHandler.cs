using MediatR;

namespace BlackBoxBoard.Server.Application.Requests.Queries.GetEmployeeRequests
{
    public class GetEmployeeRequestsQueryHandler : IRequestHandler<GetEmployeeRequestsQuery, List<RequestDto>>
    {
        public async Task<List<RequestDto>> Handle(GetEmployeeRequestsQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new List<RequestDto>());
        }
    }
}
