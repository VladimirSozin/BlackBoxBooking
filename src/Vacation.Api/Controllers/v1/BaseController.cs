using Microsoft.AspNetCore.Mvc;

namespace Vacation.Api.Controllers.v1;

/// <summary>
/// Base controller providing CRUD operations for entities of type T.
/// </summary>
/// <typeparam name="T">The DTO type for the entity operations.</typeparam>
public class BaseController<T> : Controller where T : class
{
    /// <summary>
    /// Adds a new entity of type T.
    /// </summary>
    /// <param name="dto">The DTO containing the entity data.</param>
    [HttpPost]
    public async Task<IActionResult> Add(T dto)
    {
        return Ok(1);
    }

    /// <summary>
    /// Retrieves an entity by its ID.
    /// </summary>
    /// <param name="id">The ID of the entity to retrieve.</param>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok("success");
    }

    /// <summary>
    /// Updates an existing entity.
    /// </summary>
    /// <param name="id">The ID of the entity to update.</param>
    /// <param name="dto">The DTO containing the updated entity data.</param>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, T dto)
    {
        return Ok();
    }

    /// <summary>
    /// Removes an entity by its ID.
    /// </summary>
    /// <param name="id">The ID of the entity to remove.</param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove(int id)
    {
        return Ok();
    }
}
