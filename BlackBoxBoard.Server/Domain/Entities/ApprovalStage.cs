using BlackBoxBoard.Server.Domain.Common;
using BlackBoxBoard.Server.Domain.Entities;
using BlackBoxBoard.Server.Domain.References;

public class ApprovalStage : BaseEntity
{
    private ApprovalStage() { }

    public ApprovalStage(int templateId, int stageNumber, int? roleId, int? departmentId,
        int? positionId, string? stageName, int? timeoutHours, bool isRequired, int createdBy)
        : base(createdBy)
    {
        TemplateId = templateId;
        StageNumber = stageNumber;
        RoleId = roleId;
        DepartmentId = departmentId;
        PositionId = positionId;
        StageName = stageName;
        TimeoutHours = timeoutHours;
        IsRequired = isRequired;
    }

    public int TemplateId { get; private set; }
    public int StageNumber { get; private set; }
    public int? RoleId { get; private set; }
    public int? DepartmentId { get; private set; }
    public int? PositionId { get; private set; }
    public string? StageName { get; private set; }
    public int? TimeoutHours { get; private set; }
    public bool IsRequired { get; private set; }
    public virtual ApprovalTemplate Template { get; private set; } = null!;
    public virtual Role? Role { get; private set; }
    public virtual Department? Department { get; private set; }
    public virtual Position? Position { get; private set; }
}