using MediatR;

namespace ECommerce.Application.Orders.Commands;

/// <summary>
/// Command to delete an order.
/// </summary>
public record DeleteOrderCommand(int Id) : IRequest<int>;