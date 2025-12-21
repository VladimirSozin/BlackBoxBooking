using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vacation.Core.Application.Dto.Requests;
using Vacation.Core.Application.Dto.Responses;
using Vacation.Core.Domain.Entities;

namespace Vacation.Api.Controllers.v1;

/// <summary>
/// Controller for managing vacations.
/// </summary>
[ApiController]
[AllowAnonymous]
[Route("api/v1/vacation")]
public class VacationController : BaseController<CreateEmployeeRequestDto>
{
    /// <summary>
    /// Gets a list of vacations for a specific employee.
    /// </summary>
    /// <param name="employeeId">The ID of the employee.</param>
    [HttpGet("employee/{employeeId}")]
    public async Task<IActionResult> GetListByEmployee(int employeeId)
    {
        return Ok(new List<GetVacationResponseDto>());
    }

    /// <summary>
    /// Gets the history of a specific vacation.
    /// </summary>
    /// <param name="vacationId">The ID of the vacation.</param>
    [HttpGet("history/{vacationId}")]
    public async Task<IActionResult> GetVacationHistory(int vacationId)
    {
        return Ok(new GetVacationHistoryResponseDto());
    }
}
