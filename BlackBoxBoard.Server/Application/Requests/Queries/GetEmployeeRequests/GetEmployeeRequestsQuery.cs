using MediatR;

namespace BlackBoxBoard.Server.Application.Requests.Queries.GetEmployeeRequests
{
    public class GetEmployeeRequestsQuery : IRequest<List<RequestDto>>
    {
        public int EmployeeId { get; set; }
    }

    public class RequestDto
    {
        public int Id { get; set; }
        public string RequestNumber { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
