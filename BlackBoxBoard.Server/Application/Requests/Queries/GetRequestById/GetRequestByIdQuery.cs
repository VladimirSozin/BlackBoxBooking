using MediatR;

namespace BlackBoxBoard.Server.Application.Requests.Queries.GetRequestById
{
    public class GetRequestByIdQuery : IRequest<RequestDto>
    {
        public int Id { get; set; }
    }
}
