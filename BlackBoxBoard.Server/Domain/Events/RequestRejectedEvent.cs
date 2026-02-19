using BlackBoxBoard.Server.Domain.Common;

namespace BlackBoxBoard.Server.Domain.Events
{
    public class RequestRejectedEvent : IDomainEvent
    {
        public int RequestId { get; }
        public int UserId { get; }
        public string? Reason { get; }
        public DateTime OccurredOn { get; }

        public RequestRejectedEvent(int requestId, int userId, string? reason = null)
        {
            RequestId = requestId;
            UserId = userId;
            Reason = reason;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
