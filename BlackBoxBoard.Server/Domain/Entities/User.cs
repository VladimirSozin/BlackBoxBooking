using BlackBoxBoard.Server.Domain.Common;
using BlackBoxBoard.Server.Domain.References;
using BlackBoxBoard.Server.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace BlackBoxBoard.Server.Domain.Entities;

[Index(nameof(Username), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
[Index(nameof(EmployeeId), IsUnique = true, Name = "IX_User_EmployeeId_Unique")]
public class User : BaseEntity, IAggregateRoot
{
    private User() { } 

    public User(string username, string email, string firstName, string lastName,
        int roleId, int createdBy) : base(createdBy)
    {
        Username = username;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        RoleId = roleId;
        IsEmployee = false;
    }

    public User(string username, string email, string firstName, string lastName,
        int roleId, int employeeId, int createdBy) : base(createdBy)
    {
        Username = username;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        RoleId = roleId;
        EmployeeId = employeeId;
        IsActive = true;
        IsEmployee = true;
    }

    public string Username { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string? MiddleName { get; private set; }
    public string? Phone { get; private set; }
    public DateTime? DateOfBirth { get; private set; }
    public int RoleId { get; private set; }
    public int? EmployeeId { get; private set; }
    public bool IsEmployee { get; private set; }
    public DateTime? LastLoginAt { get; private set; }

    // Navigation
    public virtual Role Role { get; private set; } = null!;
    public virtual Employee? Employee { get; private set; }

    private readonly List<ApprovalHistory> _approvals = new();
    public virtual IReadOnlyCollection<ApprovalHistory> Approvals => _approvals.AsReadOnly();

    private readonly List<BalanceTransaction> _createdTransactions = new();
    public virtual IReadOnlyCollection<BalanceTransaction> CreatedTransactions => _createdTransactions.AsReadOnly();

    // Methods
    public void UpdatePersonalInfo(string? firstName, string? lastName, string? middleName,
        string? phone, DateTime? dateOfBirth, int updatedBy)
    {
        FirstName = firstName ?? FirstName;
        LastName = lastName ?? LastName;
        MiddleName = middleName ?? MiddleName;
        Phone = phone ?? Phone;
        DateOfBirth = dateOfBirth ?? DateOfBirth;

        UpdateAuditFields(updatedBy);
    }

    public void UpdateContactInfo(string email, string? phone, int updatedBy)
    {
        Email = email;
        Phone = phone ?? Phone;
        UpdateAuditFields(updatedBy);
    }

    public void UpdateRole(int roleId, int updatedBy)
    {
        RoleId = roleId;
        UpdateAuditFields(updatedBy);
    }

    public void LinkToEmployee(int employeeId, int updatedBy)
    {
        if (IsEmployee)
            throw new InvalidOperationException("User is already linked to an employee");

        EmployeeId = employeeId;
        IsEmployee = true;
        UpdateAuditFields(updatedBy);
    }

    public void UnlinkFromEmployee(int updatedBy)
    {
        if (!IsEmployee)
            throw new InvalidOperationException("User is not linked to any employee");

        EmployeeId = null;
        IsEmployee = false;
        UpdateAuditFields(updatedBy);
    }

    public bool CanAccessEmployeeData()
    {
        return IsEmployee || Role?.Code == "HR" || Role?.Code == "ADMIN";
    }

    public void RecordLogin()
    {
        LastLoginAt = DateTime.UtcNow;
    }

    public string GetDisplayName()
    {
        if (IsEmployee && Employee != null)
            return $"{LastName} {FirstName} ({Employee.EmployeeNumber})";

        return $"{LastName} {FirstName} (External)";
    }
}