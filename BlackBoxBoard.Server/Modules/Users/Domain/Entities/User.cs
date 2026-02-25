using BlackBoxBoard.Server.Modules.Shared.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace BlackBoxBoard.Server.Modules.Users.Domain.Entities;

[Index(nameof(Username), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
[Index(nameof(EmployeeId), IsUnique = true)]
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
    public virtual Role Role { get; private set; } = null!;

}