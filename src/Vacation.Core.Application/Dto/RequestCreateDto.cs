using Vacation.Core.Domain.Entities;
using Vacation.Core.Domain.ValueObjects;

namespace Vacation.Core.Application.Dto;


public record RequestCreateDto(

    int EmployeeId,
    int DepartmentId,
    StatusOfRequest Status,
    TypeOfRequest Type,
    DateTime DateStart,
    DateTime DateStop,
    string? Comment
);