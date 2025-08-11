using Microsoft.AspNetCore.Mvc;
using ECommerce.API.Controllers;
using ECommerce.Application.Orders.Dtos;
using ECommerce.Application.Orders.Queries;
using ECommerce.Application.Orders.Commands;

namespace ECommerce.Api.Controllers;

/// <summary>
/// Controller for orders.
/// </summary>
public class OrdersController : BaseController
{
    /// <summary>
    /// Get all orders.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetAll()
    {
        var result = await Mediator.Send(new GetAllOrdersQuery());

        return Ok(result);
    }

    /// <summary>
    /// Get an order by id.
    /// </summary>
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<OrderDto>> GetById(int id)
    {
        var result = await Mediator.Send(new GetOrderByIdQuery(id));

        return Ok(result);
    }

    /// <summary>
    /// Create an order.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<OrderDto>> Create(CreateOrderCommand cmd)
    {
        var created = await Mediator.Send(cmd);

        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    /// <summary>
    /// Update an order.
    /// </summary>
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<OrderDto>> Update(int id, UpdateOrderCommand cmd)
    {
        var updated = await Mediator.Send(cmd with { Id = id });

        return Ok(updated);
    }

    /// <summary>
    /// Delete an order.
    /// </summary>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteOrderCommand(id));

        return NoContent();
    }
}
