using Microsoft.AspNetCore.Mvc;
using ECommerce.API.Controllers;
using ECommerce.Application.Products.Dtos;
using ECommerce.Application.Products.Queries;
using ECommerce.Application.Products.Commands;

namespace ECommerce.Api.Controllers;

/// <summary>
/// Controller for managing products.
/// </summary>
public class ProductsController : BaseController
{
    /// <summary>
    /// Gets all products.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
    {
        var result = await Mediator.Send(new GetAllProductsQuery());

        return Ok(result);
    }

    /// <summary>
    /// Gets a product by id.
    /// </summary>
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ProductDto>> GetById(int id)
    {
        var result = await Mediator.Send(new GetProductByIdQuery(id));

        return Ok(result);
    }

    /// <summary>
    /// Creates a new product.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ProductDto>> Create(CreateProductCommand cmd)
    {
        var created = await Mediator.Send(cmd);

        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    /// <summary>
    /// Updates a product.
    /// </summary>
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ProductDto>> Update(int id, UpdateProductCommand cmd)
    {
        var updated = await Mediator.Send(cmd with { Id = id });

        return Ok(updated);
    }

    /// <summary>
    /// Deletes a product.
    /// </summary>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteProductCommand(id));

        return NoContent();
    }
}
