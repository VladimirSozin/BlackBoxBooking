using MediatR;

namespace BlackBoxBoard.Server.Modules.ApprovalWorkflow.Application.Commands.SendBackRequest
{
    public class SendBackRequestCommand : IRequest
    {
        public int RequestId { get; set; }
        public int StageNumber { get; set; }
        public string? Comment { get; set; }
    }
}
