using MediatR;
using ECommerce.Application.Orders.Dtos;

namespace ECommerce.Application.Orders.Commands;

/// <summary>
/// Command to update an existing order.
/// </summary>
public record UpdateOrderCommand(int Id, List<OrderItemDto> Items) : IRequest<OrderDto?>;