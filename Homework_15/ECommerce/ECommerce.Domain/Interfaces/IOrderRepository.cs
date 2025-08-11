using ECommerce.Domain.Entities;

namespace ECommerce.Domain.Interfaces;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetAllAsync(CancellationToken cancellationToken);
    Task<Order?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<Order> CreateAsync(Order entity, CancellationToken cancellationToken);
    Task<Order> UpdateAsync(Order entity, CancellationToken cancellationToken);
    Task<Order> DeleteAsync(Order entity, CancellationToken cancellationToken);
}