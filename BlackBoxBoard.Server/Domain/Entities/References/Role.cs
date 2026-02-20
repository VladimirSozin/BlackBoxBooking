using BlackBoxBoard.Server.Domain.Common;
using BlackBoxBoard.Server.Domain.Entities;

namespace BlackBoxBoard.Server.Domain.References;

public class Role : BaseEntity, IReferenceEntity
{
    private Role() { }

    public Role(string code, string name, int priority, int sortOrder, int createdBy) : base(createdBy)
    {
        Code = code;
        Name = name;
        Priority = priority;
        SortOrder = sortOrder;
        IsActive = true;
    }

    public string Code { get; private set; } = null!;
    public string Name { get; private set; } = null!;
    public int Priority { get; private set; }
    public int SortOrder { get; private set; }
    public bool IsActive { get; private set; }
    public virtual ICollection<User> Users { get; private set; } = new List<User>();
    public virtual ICollection<ApprovalStage> ApprovalStages { get; private set; } = new List<ApprovalStage>();
}