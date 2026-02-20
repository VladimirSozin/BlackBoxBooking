using BlackBoxBoard.Server.Domain.Common;
using BlackBoxBoard.Server.Domain.References;

namespace BlackBoxBoard.Server.Domain.Entities;

public class ApprovalHistory : BaseEntity
{
    private ApprovalHistory() { }
    public ApprovalHistory(int requestId, int stageNumber, int approverId,
        int decisionId, string? comment, int? nextStageNumber, int createdBy) : base(createdBy)
    {
        RequestId = requestId;
        StageNumber = stageNumber;
        ApproverId = approverId;
        DecisionId = decisionId;
        Comment = comment;
        NextStageNumber = nextStageNumber;
        DecisionDate = DateTime.UtcNow;
    }

    public int RequestId { get; private set; }
    public int StageNumber { get; private set; }
    public int ApproverId { get; private set; }
    public int DecisionId { get; private set; }
    public DateTime DecisionDate { get; private set; }
    public string? Comment { get; private set; }
    public int? NextStageNumber { get; private set; }

    // Navigation 
    public virtual Request Request { get; private set; } = null!;
    public virtual User Approver { get; private set; } = null!;
    public virtual DecisionType Decision { get; private set; } = null!;
}