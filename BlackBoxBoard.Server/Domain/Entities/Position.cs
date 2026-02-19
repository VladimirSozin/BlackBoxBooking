using BlackBoxBoard.Server.Domain.Common;

namespace BlackBoxBoard.Server.Domain.Entities;

public class Position : BaseEntity
{
    private Position() { }

    public Position(string code, string name, int? grade, int createdBy) : base(createdBy)
    {
        Code = code;
        Name = name;
        Grade = grade;
        IsActive = true;
    }

    public string Code { get; private set; } = null!;
    public string Name { get; private set; } = null!;
    public int? Grade { get; private set; }
    public bool IsActive { get; private set; }
    public virtual ICollection<Employee> Employees { get; private set; } = new List<Employee>();
    public virtual ICollection<EmployeeDepartment> EmployeeDepartments { get; private set; } = new List<EmployeeDepartment>();
    public virtual ICollection<ApprovalStage> ApprovalStages { get; private set; } = new List<ApprovalStage>();
}