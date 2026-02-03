using Vacation.Core.Domain.ValueObjects;

namespace Vacation.Core.Application.Dto.Responses;

public record GetVacationResponseDto(
    int DepartmentId,
    StatusOfRequest Status,
    TypeOfRequest Type,
    DateTime DateStart,
    DateTime DateStop,
    string? Comment
);