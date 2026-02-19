using BlackBoxBoard.Server.Domain.Common;

namespace BlackBoxBoard.Server.Domain.Events;

public class RequestApprovedEvent : IDomainEvent
{
    public int RequestId { get; }
    public int ApproverId { get; }
    public int StageNumber { get; }
    public DateTime OccurredOn { get; }

    public RequestApprovedEvent(int requestId, int stageNumber, int approverId)
    {
        RequestId = requestId;
        StageNumber = stageNumber;
        ApproverId = approverId;
        OccurredOn = DateTime.UtcNow;
    }
}
