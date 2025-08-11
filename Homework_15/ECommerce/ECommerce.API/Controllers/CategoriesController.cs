using Microsoft.AspNetCore.Mvc;
using ECommerce.API.Controllers;
using ECommerce.Application.Categories.Dtos;
using ECommerce.Application.Categories.Queries;
using ECommerce.Application.Categories.Commands;

namespace ECommerce.Api.Controllers;

/// <summary>
/// Controller for categories.
/// </summary>
public class CategoriesController : BaseController
{
    /// <summary>
    /// Get all categories.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
    {
        var result = await Mediator.Send(new GetAllCategoriesQuery());

        return Ok(result);
    }

    /// <summary>
    /// Get a category by id.
    /// </summary>
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<CategoryDto>> GetById(int id)
    {
        var result = await Mediator.Send(new GetCategoryByIdQuery(id));

        return Ok(result);
    }

    /// <summary>
    /// Create a category.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<CategoryDto>> Create(CreateCategoryCommand cmd)
    {
        var created = await Mediator.Send(cmd);

        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    /// <summary>
    /// Update a category.
    /// </summary>
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<CategoryDto>> Update(int id, UpdateCategoryCommand cmd)
    {
        var updated = await Mediator.Send(cmd with { Id = id });

        return Ok(updated);
    }

    /// <summary>
    /// Delete a category.
    /// </summary>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteCategoryCommand(id));

        return NoContent();
    }
}
