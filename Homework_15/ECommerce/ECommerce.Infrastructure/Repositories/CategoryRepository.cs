using Microsoft.EntityFrameworkCore;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using ECommerce.Infrastructure.Persistence;

namespace ECommerce.Infrastructure.Repositories;

/// <summary>
/// Repository for managing <see cref="Category"/> entities.
/// </summary>
public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _dbContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryRepository"/> class.
    /// </summary>
    /// <param name="dbContext">The database context.</param>
    public CategoryRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc/>
    /// <summary>
    /// Retrieves all categories from the database.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A collection of <see cref="Category"/> entities.</returns>
    public async Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Categories
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    /// <inheritdoc/>
    /// <summary>
    /// Retrieves a category by its identifier.
    /// </summary>
    /// <param name="id">The category identifier.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The <see cref="Category"/> entity or null if not found.</returns>
    public async Task<Category?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _dbContext.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    /// <inheritdoc/>
    /// <summary>
    /// Creates a new category in the database.
    /// </summary>
    /// <param name="entity">The <see cref="Category"/> entity to create.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created <see cref="Category"/> entity.</returns>
    public async Task<Category> CreateAsync(Category entity, CancellationToken cancellationToken)
    {
        var category = _dbContext.Categories.Add(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return category.Entity;
    }

    /// <inheritdoc/>
    /// <summary>
    /// Updates an existing category in the database.
    /// </summary>
    /// <param name="entity">The <see cref="Category"/> entity to update.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The updated <see cref="Category"/> entity.</returns>
    public async Task<Category> UpdateAsync(Category entity, CancellationToken cancellationToken)
    {
        var category = _dbContext.Update(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return category.Entity;
    }

    /// <inheritdoc/>
    /// <summary>
    /// Deletes a category from the database.
    /// </summary>
    /// <param name="entity">The <see cref="Category"/> entity to delete.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The deleted <see cref="Category"/> entity.</returns>
    public async Task<Category> DeleteAsync(Category entity, CancellationToken cancellationToken)
    {
        var category = _dbContext.Remove(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return category.Entity;
    }
}