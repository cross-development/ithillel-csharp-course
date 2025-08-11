using Microsoft.EntityFrameworkCore;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using ECommerce.Infrastructure.Persistence;

namespace ECommerce.Infrastructure.Repositories;

/// <summary>
/// Repository for managing <see cref="Customer"/> entities.
/// </summary>
public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _dbContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomerRepository"/> class.
    /// </summary>
    /// <param name="dbContext">The database context.</param>
    public CustomerRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc/>
    /// <summary>
    /// Retrieves all customers from the database.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A collection of <see cref="Customer"/> entities.</returns>
    public async Task<IEnumerable<Customer>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Customers
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    /// <inheritdoc/>
    /// <summary>
    /// Retrieves a customer by its identifier.
    /// </summary>
    /// <param name="id">The customer identifier.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The <see cref="Customer"/> entity or null if not found.</returns>
    public async Task<Customer?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _dbContext.Customers
             .AsNoTracking()
             .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }

    /// <inheritdoc/>
    /// <summary>
    /// Creates a new customer in the database.
    /// </summary>
    /// <param name="entity">The <see cref="Customer"/> entity to create.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created <see cref="Customer"/> entity.</returns>
    public async Task<Customer> CreateAsync(Customer entity, CancellationToken cancellationToken)
    {
        var customer = _dbContext.Customers.Add(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return customer.Entity;
    }

    /// <inheritdoc/>
    /// <summary>
    /// Updates an existing customer in the database.
    /// </summary>
    /// <param name="entity">The <see cref="Customer"/> entity to update.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The updated <see cref="Customer"/> entity.</returns>
    public async Task<Customer> UpdateAsync(Customer entity, CancellationToken cancellationToken)
    {
        var customer = _dbContext.Update(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return customer.Entity;
    }

    /// <inheritdoc/>
    /// <summary>
    /// Deletes a customer from the database.
    /// </summary>
    /// <param name="entity">The <see cref="Customer"/> entity to delete.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The deleted <see cref="Customer"/> entity.</returns>
    public async Task<Customer> DeleteAsync(Customer entity, CancellationToken cancellationToken)
    {
        var customer = _dbContext.Remove(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return customer.Entity;
    }
}