using MediatR;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Exceptions;
using ECommerce.Domain.Interfaces;
using ECommerce.Application.Orders.Commands;

namespace ECommerce.Application.Orders.Handlers;

/// <summary>
/// Handler to delete an order.
/// </summary>
public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, int>
{
    private readonly IOrderRepository _orderRepository;

    /// <summary>
    /// Constructs handler.
    /// </summary>
    public DeleteOrderHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    /// <inheritdoc/>
    public async Task<int> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var existingOrder = await _orderRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingOrder == null)
        {
            throw new NotFoundException(nameof(Order), request.Id.ToString());
        }

        var removedOrder = await _orderRepository.DeleteAsync(existingOrder, cancellationToken);

        return removedOrder.Id;
    }
}