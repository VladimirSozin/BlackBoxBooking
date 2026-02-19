using BlackBoxBoard.Server.Domain.Common;

namespace BlackBoxBoard.Server.Domain.Entities;

public class Department : BaseEntity, IAggregateRoot
{
    private Department() { }

    public Department(string code, string name, int? parentId, int? managerId, int createdBy)
        : base(createdBy)
    {
        Code = code;
        Name = name;
        ParentId = parentId;
        ManagerId = managerId;
        IsActive = true;
    }

    public int? ParentId { get; private set; }
    public string Code { get; private set; } = null!;
    public string Name { get; private set; } = null!;
    public int? ManagerId { get; private set; }
    public bool IsActive { get; private set; }
    public virtual Department? Parent { get; private set; }
    public virtual ICollection<Department> Children { get; private set; } = new List<Department>();
    public virtual Employee? Manager { get; private set; }
    public virtual ICollection<EmployeeDepartment> EmployeeAssignments { get; private set; } = new List<EmployeeDepartment>();
    public virtual ICollection<Request> Requests { get; private set; } = new List<Request>();
    public virtual ICollection<ApprovalStage> ApprovalStages { get; private set; } = new List<ApprovalStage>();
}