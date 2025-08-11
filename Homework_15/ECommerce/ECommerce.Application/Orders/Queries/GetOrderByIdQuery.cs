using MediatR;
using ECommerce.Application.Orders.Dtos;

namespace ECommerce.Application.Orders.Queries;

/// <summary>
/// Query to get order by id.
/// </summary>
public record GetOrderByIdQuery(int Id) : IRequest<OrderDto?>;