using BlackBoxBoard.Server.Domain.ValueObjects;
using BlackBoxBoard.Server.Modules.ApprovalWorkflow.Domain.Entities;
using BlackBoxBoard.Server.Modules.Employees.Domain.Entities;
using BlackBoxBoard.Server.Modules.References.Domain.Entities;
using BlackBoxBoard.Server.Modules.Shared.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace BlackBoxBoard.Server.Modules.LeaveManagement.Domain.Entities;

[Index(nameof(EmployeeId))]
[Index(nameof(LeaveTypeId))]
[Index(nameof(StatusId))]
[Index(nameof(RequestId))]
public class Leave : BaseEntity
{
    private Leave() { }
    public Leave(int requestId, int employeeId, int leaveTypeId,
        DateTime startDate, DateTime endDate, decimal durationDays, int createdBy) : base(createdBy)
    {
        RequestId = requestId;
        EmployeeId = employeeId;
        LeaveTypeId = leaveTypeId;
        StartDate = startDate;
        EndDate = endDate;
        DurationDays = durationDays;
    }

    public int RequestId { get; private set; }
    public int EmployeeId { get; private set; }
    public int LeaveTypeId { get; private set; }
    public int StatusId { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public decimal DurationDays { get; private set; }
    public int? PreviousLeaveId { get; private set; }
    public string? Comment { get; private set; }
    public virtual LeaveStatus Status { get; private set; } = null!;
    public virtual Leave? PreviousLeave { get; private set; }

    private readonly List<Leave> _childLeaves = new();
    public virtual IReadOnlyCollection<Leave> ChildLeaves => _childLeaves.AsReadOnly();
}