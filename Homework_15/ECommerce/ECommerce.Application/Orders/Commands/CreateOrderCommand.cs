using MediatR;
using ECommerce.Application.Orders.Dtos;

namespace ECommerce.Application.Orders.Commands;

/// <summary>
/// Command to create an order.
/// </summary>
public record CreateOrderCommand(int CustomerId, List<OrderItemDto> Items) : IRequest<OrderDto>;