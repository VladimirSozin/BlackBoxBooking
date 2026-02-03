namespace Vacation.Core.Application.Dto.Requests;

public record CreateEmployeeRequestDto(
    string FirstName,
    string LastName,
    DateTime DateBirthday
);