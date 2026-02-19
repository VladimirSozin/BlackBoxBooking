using MediatR;

namespace BlackBoxBoard.Server.Application.Requests.Commands.ApproveRequest
{
    public class ApproveRequestCommand : IRequest
    {
        public int RequestId { get; set; }
        public int StageNumber { get; set; }
        public string? Comment { get; set; }
    }
}
