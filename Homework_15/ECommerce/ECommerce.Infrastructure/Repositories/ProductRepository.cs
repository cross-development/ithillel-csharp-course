using Microsoft.EntityFrameworkCore;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using ECommerce.Infrastructure.Persistence;

namespace ECommerce.Infrastructure.Repositories;

/// <summary>
/// Repository implementation for managing <see cref="Product"/> entities in the database.
/// </summary>
public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _dbContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductRepository"/> class.
    /// </summary>
    /// <param name="dbContext">The database context to use for data access.</param>
    public ProductRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // <summary>
    /// Retrieves all products from the database.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>A collection of all products.</returns>
    public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Products
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Retrieves a product by its unique identifier.
    /// </summary>
    /// <param name="id">The ID of the product to retrieve.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>The product if found; otherwise, <c>null</c>.</returns>
    public async Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _dbContext.Products.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    /// <summary>
    /// Retrieves products by a collection of IDs.
    /// </summary>
    /// <param name="ids">The collection of product IDs to retrieve.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>A list of matching products.</returns>
    public async Task<List<Product>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken)
    {
        return await _dbContext.Products
            .Where(p => ids.Contains(p.Id))
            .ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Creates a new product in the database.
    /// </summary>
    /// <param name="entity">The product entity to create.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>The created product entity with updated ID.</returns>
    public async Task<Product> CreateAsync(Product entity, CancellationToken cancellationToken)
    {
        var product = _dbContext.Products.Add(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return product.Entity;
    }

    /// <summary>
    /// Updates an existing product in the database.
    /// </summary>
    /// <param name="entity">The product entity with updated values.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>The updated product entity.</returns>
    public async Task<Product> UpdateAsync(Product entity, CancellationToken cancellationToken)
    {
        var product = _dbContext.Update(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return product.Entity;
    }

    /// <summary>
    /// Deletes a product from the database.
    /// </summary>
    /// <param name="entity">The product entity to delete.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>The deleted product entity.</returns>
    public async Task<Product> DeleteAsync(Product entity, CancellationToken cancellationToken)
    {
        var product = _dbContext.Remove(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return product.Entity;
    }
}