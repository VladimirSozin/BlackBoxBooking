using Vacation.Core.Domain.ValueObjects;

namespace Vacation.Core.Application.Dto.Requests;


public record CreateVacationRequestDto(

    int EmployeeId,
    int DepartmentId,
    StatusOfRequest Status,
    TypeOfRequest Type,
    DateTime DateStart,
    DateTime DateStop,
    string? Comment
);