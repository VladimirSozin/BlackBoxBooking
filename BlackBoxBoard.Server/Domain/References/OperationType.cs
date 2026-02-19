using BlackBoxBoard.Server.Domain.Common;
using BlackBoxBoard.Server.Domain.Entities;

namespace BlackBoxBoard.Server.Domain.References;

public class OperationType : BaseEntity, IReferenceEntity
{
    private OperationType() { }

    public OperationType(string code, string name, int sortOrder, int createdBy) : base(createdBy)
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

    // Navigation
    public virtual ICollection<Request> Requests { get; private set; } = new List<Request>();
}