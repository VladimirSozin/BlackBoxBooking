using BlackBoxBoard.Server.Domain.Common;
using BlackBoxBoard.Server.Domain.References;

namespace BlackBoxBoard.Server.Domain.Entities;

public class BalanceTransaction : BaseEntity
{
    private BalanceTransaction() { }
    public BalanceTransaction(int employeeId, int leaveTypeId, int transactionTypeId,
        decimal amount, int? requestId, int? leaveId, string? description, int createdBy)
        : base(createdBy)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be positive", nameof(amount));

        EmployeeId = employeeId;
        LeaveTypeId = leaveTypeId;
        TransactionTypeId = transactionTypeId;
        TransactionDate = DateTime.UtcNow;
        Amount = amount;
        RequestId = requestId;
        LeaveId = leaveId;
        Description = description;
    }

    public int EmployeeId { get; private set; }
    public int LeaveTypeId { get; private set; }
    public int TransactionTypeId { get; private set; }
    public DateTime TransactionDate { get; private set; }
    public decimal Amount { get; private set; }
    public int? LeaveId { get; private set; }
    public int? RequestId { get; private set; }
    public string? Description { get; private set; }
    public decimal SignedAmount => (TransactionType?.Sign == "-" ? -Amount : Amount);

    // Navigation
    public virtual Employee Employee { get; private set; } = null!;
    public virtual LeaveType LeaveType { get; private set; } = null!;
    public virtual TransactionType TransactionType { get; private set; } = null!;
    public virtual Leave? Leave { get; private set; }
    public virtual Request? Request { get; private set; }
}