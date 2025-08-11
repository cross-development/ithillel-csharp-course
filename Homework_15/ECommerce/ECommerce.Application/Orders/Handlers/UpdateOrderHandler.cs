using MediatR;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using ECommerce.Domain.Exceptions;
using ECommerce.Application.Orders.Dtos;
using ECommerce.Application.Orders.Commands;

namespace ECommerce.Application.Orders.Handlers;

/// <summary>
/// Handler to update an order.
/// </summary>
public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, OrderDto?>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;

    /// <summary>
    /// Constructs handler.
    /// </summary>
    public UpdateOrderHandler(IOrderRepository orderRepository, IProductRepository productRepository)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
    }

    /// <inheritdoc/>
    public async Task<OrderDto?> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var existingOrder = await _orderRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingOrder == null)
        {
            throw new NotFoundException(nameof(Order), request.Id.ToString());
        }

        var productIds = request.Items.Select(i => i.ProductId).Distinct().ToList();
        var products = await _productRepository.GetByIdsAsync(productIds, cancellationToken);
        var productDict = products.ToDictionary(p => p.Id, p => p);

        existingOrder.Items.Clear();

        decimal total = 0M;

        foreach (var item in request.Items)
        {
            var unitPrice = productDict.TryGetValue(item.ProductId, out var product)
                ? product.Price
                : item.UnitPrice;

            existingOrder.Items.Add(new OrderItem
            {
                OrderId = existingOrder.Id,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                UnitPrice = unitPrice
            });

            total += unitPrice * item.Quantity;
        }

        existingOrder.Total = total;

        var updatedOrder = await _orderRepository.UpdateAsync(existingOrder, cancellationToken);

        return new OrderDto
        {
            Id = updatedOrder.Id,
            CustomerId = updatedOrder.CustomerId,
            CreatedAt = updatedOrder.CreatedAt,
            Total = updatedOrder.Total,
            Items = updatedOrder.Items.Select(item => new OrderItemDto
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice
            }).ToList()
        };
    }
}