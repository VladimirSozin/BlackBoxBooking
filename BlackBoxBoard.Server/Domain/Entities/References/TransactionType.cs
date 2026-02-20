using BlackBoxBoard.Server.Domain.Common;
using BlackBoxBoard.Server.Domain.Entities;

namespace BlackBoxBoard.Server.Domain.References;

public class TransactionType : BaseEntity, IReferenceEntity
{
    private TransactionType() { }

    public TransactionType(string code, string name, string sign, int sortOrder, int createdBy) : base(createdBy)
    {
        Code = code;
        Name = name;
        Sign = sign;
        SortOrder = sortOrder;
        IsActive = true;
    }

    public string Code { get; private set; } = null!;
    public string Name { get; private set; } = null!;
    public string Sign { get; private set; } = null!; 
    public int SortOrder { get; private set; }
    public bool IsActive { get; private set; }

    // Navigation
    public virtual ICollection<BalanceTransaction> BalanceTransactions { get; private set; } = new List<BalanceTransaction>();
}
