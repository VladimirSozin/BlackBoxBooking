using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vacation.Core.Application.Dto.Requests;
using Vacation.Core.Application.Dto.Responses;
using Vacation.Core.Domain.Entities;

namespace Vacation.Api.Controllers.v1;

[ApiController]
[AllowAnonymous]
[Route("api/v1/vacation")]
public class VacationController : BaseController<CreateEmployeeRequestDto>
{
    [HttpGet("employee/{employeeId}")]
    public async Task<IActionResult> GetListByEmployee(int employeeId)
    {
        return Ok(new List<GetVacationResponseDto>());
    }
    
    [HttpGet("history/{vacationId}")]
    public async Task<IActionResult> GetVacationHistory(int vacationId)
    {
        return Ok(new GetVacationHistoryResponseDto());
    }
}