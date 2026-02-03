namespace Vacation.Core.Application.Dto.Requests;

public record CreatePolicyRequestDto(
    int DepartmentId,
    string Code,
    short Sort
);