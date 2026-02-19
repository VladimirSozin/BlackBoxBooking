using BlackBoxBoard.Server.Domain.Common;

namespace BlackBoxBoard.Server.Domain.Events;

public class RequestSubmittedEvent : IDomainEvent
{
    public int RequestId { get; }
    public int EmployeeId { get; }
    public DateTime OccurredOn { get; }

    public RequestSubmittedEvent(int requestId, int employeeId)
    {
        RequestId = requestId;
        EmployeeId = employeeId;
        OccurredOn = DateTime.UtcNow;
    }
}
