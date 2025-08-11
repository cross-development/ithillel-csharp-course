using MediatR;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using ECommerce.Application.Orders.Dtos;
using ECommerce.Application.Orders.Commands;

namespace ECommerce.Application.Orders.Handlers;

/// <summary>
/// Handler to create an order.
/// </summary>
public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, OrderDto>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;

    /// <summary>
    /// Constructs handler.
    /// </summary>
    public CreateOrderHandler(IOrderRepository orderRepository, IProductRepository productRepository)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
    }

    /// <inheritdoc/>
    public async Task<OrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        // compute total and create items
        var entity = new Order
        {
            CustomerId = request.CustomerId,
            CreatedAt = DateTime.UtcNow
        };

        var productIds = request.Items.Select(i => i.ProductId).Distinct().ToList();
        var products = await _productRepository.GetByIdsAsync(productIds, cancellationToken);
        var productDict = products.ToDictionary(p => p.Id, p => p);

        decimal total = 0M;

        foreach (var item in request.Items)
        {
            var unitPrice = productDict.TryGetValue(item.ProductId, out var product)
                ? product.Price
                : item.UnitPrice;

            entity.Items.Add(new OrderItem
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                UnitPrice = unitPrice
            });

            total += unitPrice * item.Quantity;
        }

        entity.Total = total;

        var order = await _orderRepository.CreateAsync(entity, cancellationToken);

        return new OrderDto
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
        };
    }
}
