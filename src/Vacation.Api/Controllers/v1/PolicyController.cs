using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vacation.Core.Application.Dto.Requests;

namespace Vacation.Api.Controllers.v1;

[ApiController]
[AllowAnonymous]
[Route("api/v1/policy")]
public class PolicyController : BaseController<CreatePositionRequestDto>;