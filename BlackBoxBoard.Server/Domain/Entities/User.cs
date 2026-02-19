using BlackBoxBoard.Server.Domain.Common;
using BlackBoxBoard.Server.Domain.References;
using BlackBoxBoard.Server.Domain.ValueObjects;

namespace BlackBoxBoard.Server.Domain.Entities;

public class User : BaseEntity
{
    private User() { } 

    public User(string username, string email, int roleId, int createdBy) : base(createdBy)
    {
        Username = username;
        Email = email;
        RoleId = roleId;
        IsActive = true;
    }

    public string Username { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }
    public string? Phone { get; private set; }
    public int RoleId { get; private set; }
    public int? EmployeeId { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime? LastLoginAt { get; private set; }

    // Navigation properties
    public virtual Role Role { get; private set; } = null!;
    public virtual Employee? Employee { get; private set; }
    public virtual ICollection<ApprovalHistory> Approvals { get; private set; } = new List<ApprovalHistory>();
    public virtual ICollection<BalanceTransaction> CreatedTransactions { get; private set; } = new List<BalanceTransaction>();
}