using BlackBoxBoard.Server.Domain.Common;
using BlackBoxBoard.Server.Domain.References;

namespace BlackBoxBoard.Server.Domain.Entities;

public class LeaveBalance : BaseEntity
{
    private LeaveBalance() { }
    public LeaveBalance(int employeeId, int leaveTypeId, int year, DateTime calculatedAt, int createdBy) : base(createdBy)
    {
        EmployeeId = employeeId;
        LeaveTypeId = leaveTypeId;
        Year = year;
        CalculatedAt = calculatedAt;
    }

    public int EmployeeId { get; private set; }
    public int LeaveTypeId { get; private set; }
    public int Year { get; private set; }
    public decimal Entitled { get; private set; }
    public decimal Used { get; private set; }
    public decimal Planned { get; private set; }
    public decimal Available => Entitled - Used - Planned;
    public DateTime CalculatedAt { get; private set; }

    // Navigation
    public virtual Employee Employee { get; private set; } = null!;
    public virtual LeaveType LeaveType { get; private set; } = null!;
}