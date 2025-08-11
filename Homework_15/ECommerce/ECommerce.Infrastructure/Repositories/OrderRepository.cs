using Microsoft.EntityFrameworkCore;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using ECommerce.Infrastructure.Persistence;

namespace ECommerce.Infrastructure.Repositories;

/// <summary>
/// Repository implementation for managing <see cref="Order"/> entities.
/// </summary>
public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _dbContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="OrderRepository"/> class.
    /// </summary>
    /// <param name="dbContext">The application's database context.</param>
    public OrderRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc/>
    /// <summary>
    /// Retrieves all orders from the database, including their order items.
    /// </summary>
    /// <param name="cancellationToken">Token for canceling the operation.</param>
    /// <returns>A collection of <see cref="Order"/> entities.</returns>
    public async Task<IEnumerable<Order>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Orders
            .AsNoTracking()
            .Include(o => o.Items)
            .ToListAsync(cancellationToken);
    }

    /// <inheritdoc/>
    /// <summary>
    /// Retrieves an order by its identifier, including its items.
    /// </summary>
    /// <param name="id">The identifier of the order.</param>
    /// <param name="cancellationToken">Token for canceling the operation.</param>
    /// <returns>The matching <see cref="Order"/> entity, or null if not found.</returns>
    public async Task<Order?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _dbContext.Orders
            .AsNoTracking()
            .Include(o => o.Items)
            .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }

    /// <inheritdoc/>
    /// <summary>
    /// Creates a new order in the database.
    /// </summary>
    /// <param name="entity">The <see cref="Order"/> entity to create.</param>
    /// <param name="cancellationToken">Token for canceling the operation.</param>
    /// <returns>The created <see cref="Order"/> entity.</returns>
    public async Task<Order> CreateAsync(Order entity, CancellationToken cancellationToken)
    {
        var order = _dbContext.Orders.Add(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return order.Entity;
    }

    /// <inheritdoc/>
    /// <summary>
    /// Updates an existing order in the database.
    /// </summary>
    /// <param name="entity">The <see cref="Order"/> entity to update.</param>
    /// <param name="cancellationToken">Token for canceling the operation.</param>
    /// <returns>The updated <see cref="Order"/> entity.</returns>
    public async Task<Order> UpdateAsync(Order entity, CancellationToken cancellationToken)
    {
        var order = _dbContext.Update(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return order.Entity;
    }

    /// <inheritdoc/>
    /// <summary>
    /// Deletes an order from the database.
    /// </summary>
    /// <param name="entity">The <see cref="Order"/> entity to delete.</param>
    /// <param name="cancellationToken">Token for canceling the operation.</param>
    /// <returns>The deleted <see cref="Order"/> entity.</returns>
    public async Task<Order> DeleteAsync(Order entity, CancellationToken cancellationToken)
    {
        var order = _dbContext.Remove(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return order.Entity;
    }
}