using BlackBoxBoard.Server.Domain.Common;
using BlackBoxBoard.Server.Domain.Entities;

namespace BlackBoxBoard.Server.Domain.References;

public class LeaveType : BaseEntity, IReferenceEntity
{
    private LeaveType() { }

    public LeaveType(string code, string name, bool isPaid, bool affectsBalance,
        int minDays, int maxDays, int sortOrder, int createdBy) : base(createdBy)
    {
        Code = code;
        Name = name;
        IsPaid = isPaid;
        AffectsBalance = affectsBalance;
        MinDays = minDays;
        MaxDays = maxDays;
        SortOrder = sortOrder;
        IsActive = true;
    }

    public string Code { get; private set; } = null!;
    public string Name { get; private set; } = null!;
    public bool IsPaid { get; private set; }
    public bool AffectsBalance { get; private set; }
    public int MinDays { get; private set; }
    public int MaxDays { get; private set; }
    public decimal? AccrualRate { get; private set; }
    public int SortOrder { get; private set; }
    public bool IsActive { get; private set; }

    // Navigation
    public virtual ICollection<Leave> Leaves { get; private set; } = new List<Leave>();
    public virtual ICollection<LeaveBalance> LeaveBalances { get; private set; } = new List<LeaveBalance>();
    public virtual ICollection<BalanceTransaction> BalanceTransactions { get; private set; } = new List<BalanceTransaction>();
}