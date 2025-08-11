using Microsoft.AspNetCore.Mvc;
using ECommerce.API.Controllers;
using ECommerce.Application.Customers.Dtos;
using ECommerce.Application.Customers.Queries;
using ECommerce.Application.Customers.Commands;

namespace ECommerce.Api.Controllers;

/// <summary>
/// Controller for customers.
/// </summary>
public class CustomersController : BaseController
{
    /// <summary>
    /// Get all customers.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAll()
    {
        var result = await Mediator.Send(new GetAllCustomersQuery());

        return Ok(result);
    }

    /// <summary>
    /// Get a customer by id.
    /// </summary>
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<CustomerDto>> GetById(int id)
    {
        var result = await Mediator.Send(new GetCustomerByIdQuery(id));

        return Ok(result);
    }

    /// <summary>
    /// Create a customer.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<CustomerDto>> Create(CreateCustomerCommand cmd)
    {
        var created = await Mediator.Send(cmd);

        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    /// <summary>
    /// Update a customer.
    /// </summary>
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<CustomerDto>> Update(int id, UpdateCustomerCommand cmd)
    {
        var updated = await Mediator.Send(cmd with { Id = id });

        return Ok(updated);
    }

    /// <summary>
    /// Delete a customer.
    /// </summary>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteCustomerCommand(id));

        return NoContent();
    }
}
