using BlackBoxBoard.Server.Domain.Common;
using BlackBoxBoard.Server.Domain.Entities;

namespace BlackBoxBoard.Server.Domain.References;

public class DecisionType : BaseEntity, IReferenceEntity
{
    private DecisionType() { }

    public DecisionType(string code, string name, bool isFinal, int sortOrder, int createdBy) : base(createdBy)
    {
        Code = code;
        Name = name;
        IsFinal = isFinal;
        SortOrder = sortOrder;
        IsActive = true;
    }

    public string Code { get; private set; } = null!;
    public string Name { get; private set; } = null!;
    public bool IsFinal { get; private set; }
    public int SortOrder { get; private set; }
    public bool IsActive { get; private set; }

    // Navigation
    public virtual ICollection<ApprovalHistory> ApprovalHistories { get; private set; } = new List<ApprovalHistory>();
}
