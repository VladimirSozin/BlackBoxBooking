using BlackBoxBoard.Server.Domain.Common;
using StackExchange.Redis;

namespace BlackBoxBoard.Server.Domain.Entities;

public class Employee : BaseEntity, IAggregateRoot
{
    private Employee() { }

    public Employee(string employeeNumber, DateTime hireDate, int? positionId, int createdBy)
        : base(createdBy)
    {
        EmployeeNumber = employeeNumber;
        HireDate = hireDate;
        PositionId = positionId;
        IsActive = true;
    }

    public string EmployeeNumber { get; private set; } = null!;
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }
    public string? MiddleName { get; private set; }
    public DateTime HireDate { get; private set; }
    public DateTime? TerminationDate { get; private set; }
    public int? PositionId { get; private set; }
    public int? ManagerId { get; private set; }
    public bool IsActive { get; private set; }
    public virtual Position? Position { get; private set; }
    public virtual Employee? Manager { get; private set; }
    public virtual ICollection<Employee> Subordinates { get; private set; } = new List<Employee>();
    public virtual User? User { get; private set; }
    public virtual ICollection<EmployeeDepartment> DepartmentAssignments { get; private set; } = new List<EmployeeDepartment>();
    public virtual ICollection<Department> ManagedDepartments { get; private set; } = new List<Department>();
    public virtual ICollection<Request> Requests { get; private set; } = new List<Request>();
    public virtual ICollection<Leave> Leaves { get; private set; } = new List<Leave>();
    public virtual ICollection<LeaveBalance> Balances { get; private set; } = new List<LeaveBalance>();
    public virtual ICollection<BalanceTransaction> BalanceTransactions { get; private set; } = new List<BalanceTransaction>();
}