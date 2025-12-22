using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vacation.Core.Application.Dto.Requests;

namespace Vacation.Api.Controllers.v1;

/// <summary>
/// Controller for managing policies.
/// </summary>
[ApiController]
[AllowAnonymous]
[Route("api/v1/policy")]
public class PolicyController : BaseController<CreatePositionRequestDto>;
