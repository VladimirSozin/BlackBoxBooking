using BlackBoxBoard.Server.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace BlackBoxBoard.Server.Domain.Entities;

[Index(nameof(EmployeeNumber), IsUnique = true)]
public class Employee : BaseEntity, IAggregateRoot
{
    private Employee() { }

    public Employee(string employeeNumber, DateTime hireDate, int createdBy)
        : base(createdBy)
    {
        EmployeeNumber = employeeNumber;
        HireDate = hireDate;
        HasUserAccount = false;
    }

    public string EmployeeNumber { get; private set; } = null!;
    public DateTime HireDate { get; private set; }
    public DateTime? TerminationDate { get; private set; }
    public int? ManagerId { get; private set; }
    public bool HasUserAccount { get; private set; } 

    public virtual Employee? Manager { get; private set; }
    public virtual User? User { get; private set; }


    private readonly List<Employee> _subordinates = new();
    public virtual IReadOnlyCollection<Employee> Subordinates => _subordinates.AsReadOnly();


    private readonly List<EmployeeDepartment> _departmentAssignments = new();
    public virtual IReadOnlyCollection<EmployeeDepartment> DepartmentAssignments => _departmentAssignments.AsReadOnly();


    private readonly List<Department> _managedDepartments = new();
    public virtual IReadOnlyCollection<Department> ManagedDepartments => _managedDepartments.AsReadOnly();


    private readonly List<Leave> _leaves = new();
    public virtual IReadOnlyCollection<Leave> Leaves => _leaves.AsReadOnly();


    private readonly List<LeaveBalance> _balances = new();
    public virtual IReadOnlyCollection<LeaveBalance> Balances => _balances.AsReadOnly();


    private readonly List<BalanceTransaction> _balanceTransactions = new();
    public virtual IReadOnlyCollection<BalanceTransaction> BalanceTransactions => _balanceTransactions.AsReadOnly();


    private readonly List<Request> _requests = new();
    public virtual IReadOnlyCollection<Request> Requests => _requests.AsReadOnly();


    public EmployeeDepartment? GetCurrentPrimaryAssignment()
    {
        return _departmentAssignments
            .FirstOrDefault(da => da.IsPrimary && da.IsActive && (da.EndDate == null || da.EndDate > DateTime.UtcNow));
    }

    public Position? GetCurrentPosition()
    {
        return GetCurrentPrimaryAssignment()?.Position;
    }

    public void UpdateManager(int? managerId, int updatedBy)
    {
        if (managerId == Id)
            throw new InvalidOperationException("Employee cannot be their own manager");

        ManagerId = managerId;
        UpdateAuditFields(updatedBy);
    }

    public void UpdateHireDate(DateTime hireDate, int updatedBy)
    {
        if (hireDate > DateTime.UtcNow)
            throw new ArgumentException("Hire date cannot be in the future");

        HireDate = hireDate;
        UpdateAuditFields(updatedBy);
    }

    public void Terminate(DateTime terminationDate, int updatedBy)
    {
        if (terminationDate < HireDate)
            throw new ArgumentException("Termination date cannot be before hire date");

        TerminationDate = terminationDate;
        IsActive = false;
        UpdateAuditFields(updatedBy);

        //EmployeeTerminated
    }

    public void Reinstate(int updatedBy)
    {
        TerminationDate = null;
        IsActive = true;
        UpdateAuditFields(updatedBy);
    }

    public void LinkUserAccount(int userId, int updatedBy)
    {
        if (HasUserAccount)
            throw new InvalidOperationException("Employee already has a user account");

        HasUserAccount = true;
        UpdateAuditFields(updatedBy);

        // EmployeeLinkedToUser
    }

    public void UnlinkUserAccount(int updatedBy)
    {
        if (!HasUserAccount)
            throw new InvalidOperationException("Employee does not have a user account");

        HasUserAccount = false;
        UpdateAuditFields(updatedBy);
    }

    public void Activate(int updatedBy)
    {
        if (!IsActive && TerminationDate == null)
        {
            IsActive = true;
            UpdateAuditFields(updatedBy);
        }
    }

    public void Deactivate(int updatedBy)
    {
        if (IsActive)
        {
            IsActive = false;
            UpdateAuditFields(updatedBy);
        }
    }

    public string GetDisplayName()
    {
        if (User != null)
            return $"{User.LastName} {User.FirstName} ({EmployeeNumber})";

        return $"Employee #{EmployeeNumber} (no user account)";
    }

}