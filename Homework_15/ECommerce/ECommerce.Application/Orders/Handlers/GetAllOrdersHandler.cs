using MediatR;
using ECommerce.Domain.Interfaces;
using ECommerce.Application.Orders.Dtos;
using ECommerce.Application.Orders.Queries;

namespace ECommerce.Application.Orders.Handlers;

/// <summary>
/// Handler to get orders list.
/// </summary>
public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<OrderDto>>
{
    private readonly IOrderRepository _orderRepository;

    /// <summary>
    /// Constructs handler.
    /// </summary>
    public GetAllOrdersHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.GetAllAsync(cancellationToken);

        var dtos = orders.Select(order => new OrderDto
        {
            Id = order.Id,
            CustomerId = order.CustomerId,
            CreatedAt = order.CreatedAt,
            Total = order.Total,
            Items = order.Items.Select(item => new OrderItemDto
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice
            }).ToList()
        }).ToList();

        return dtos;
    }
}