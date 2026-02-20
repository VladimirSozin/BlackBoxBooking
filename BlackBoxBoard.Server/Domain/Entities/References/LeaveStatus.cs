using BlackBoxBoard.Server.Domain.Common;
using BlackBoxBoard.Server.Domain.Entities;

namespace BlackBoxBoard.Server.Domain.References;

public class LeaveStatus : BaseEntity, IReferenceEntity
{
    private LeaveStatus() { }

    public LeaveStatus(string code, string name, int sortOrder, int createdBy) : base(createdBy)
    {
        Code = code;
        Name = name;
        SortOrder = sortOrder;
        IsActive = true;
    }

    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public int SortOrder { get; set; }
    public bool IsActive { get; set; } = true;
    public virtual ICollection<Leave> Leaves { get; set; } = new List<Leave>();

}