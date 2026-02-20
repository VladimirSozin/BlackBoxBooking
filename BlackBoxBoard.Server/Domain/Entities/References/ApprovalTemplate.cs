using BlackBoxBoard.Server.Domain.Common;
using BlackBoxBoard.Server.Domain.Entities;

namespace BlackBoxBoard.Server.Domain.References;

public class ApprovalTemplate : BaseEntity, IReferenceEntity
{
    private ApprovalTemplate() { }

    public ApprovalTemplate(string code, string name, int sortOrder, int createdBy) : base(createdBy)
    {
        Code = code;
        Name = name;
        SortOrder = sortOrder;
        IsActive = true;
    }

    public string Code { get; private set; } = null!;
    public string Name { get; private set; } = null!;
    public int SortOrder { get; private set; }
    public bool IsActive { get; private set; }
    public string? Description { get; private set; }

    // Navigation
    public virtual ICollection<ApprovalStage> Stages { get; private set; } = new List<ApprovalStage>();
    public virtual ICollection<Request> Requests { get; private set; } = new List<Request>();
}
