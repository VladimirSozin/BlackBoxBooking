namespace Vacation.Core.Application.Dto.Requests;

public record CreateDepartmentRequestDto(
    string Title,
    int ParentId,
    string WorkFlowApprovingTitle
);