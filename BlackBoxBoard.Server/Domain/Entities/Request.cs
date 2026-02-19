using BlackBoxBoard.Server.Domain.Common;
using BlackBoxBoard.Server.Domain.Events;
using BlackBoxBoard.Server.Domain.References;
using BlackBoxBoard.Server.Domain.ValueObjects;
using StackExchange.Redis;

namespace BlackBoxBoard.Server.Domain.Entities;

public class Request : BaseEntity, IAggregateRoot
{
    private Request() { }

    public Request(string requestNumber, int operationTypeId, int employeeId,
            int departmentId, int approvalTemplateId, int createdBy) : base(createdBy)
    {
        RequestNumber = requestNumber;
        OperationTypeId = operationTypeId;
        EmployeeId = employeeId;
        DepartmentId = departmentId;
        ApprovalTemplateId = approvalTemplateId;
        Leaves = new List<Leave>();
        ApprovalHistory = new List<ApprovalHistory>();
    }

    public string RequestNumber { get; private set; } = null!;
    public int OperationTypeId { get; private set; }
    public int StatusId { get; private set; }
    public int EmployeeId { get; private set; }
    public int DepartmentId { get; private set; }
    public int ApprovalTemplateId { get; private set; }
    public int? TargetLeaveId { get; private set; }
    public string? Comment { get; private set; }
    public int? CurrentStageNumber { get; private set; }
    public DateTime? SubmittedAt { get; private set; }
    public DateTime? CompletedAt { get; private set; }
    public virtual OperationType OperationType { get; private set; } = null!;
    public virtual RequestStatus Status { get; private set; } = null!;
    public virtual Employee Employee { get; private set; } = null!;
    public virtual Department Department { get; private set; } = null!;
    public virtual ApprovalTemplate ApprovalTemplate { get; private set; } = null!;
    public virtual Leave? TargetLeave { get; private set; }
    public virtual ICollection<Leave> Leaves { get; private set; }
    public virtual ICollection<ApprovalHistory> ApprovalHistory { get; private set; }
}