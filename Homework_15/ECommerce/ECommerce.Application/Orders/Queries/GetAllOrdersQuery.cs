using MediatR;
using ECommerce.Application.Orders.Dtos;

namespace ECommerce.Application.Orders.Queries;

/// <summary>
/// Query to get all orders.
/// </summary>
public record GetAllOrdersQuery() : IRequest<IEnumerable<OrderDto>>;