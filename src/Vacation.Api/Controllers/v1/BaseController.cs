using Microsoft.AspNetCore.Mvc;

namespace Vacation.Api.Controllers.v1;

public class BaseController<T> : Controller where T : class
{
    [HttpPost]
    public async Task<IActionResult> Add(T dto)
    {
        return Ok(1);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok("success");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, T dto)
    {
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove(int id)
    {
        return Ok();
    }
}