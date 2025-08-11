using ECommerce.Domain.Entities;

namespace ECommerce.Domain.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken);
    Task<Category?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<Category> CreateAsync(Category entity, CancellationToken cancellationToken);
    Task<Category> UpdateAsync(Category entity, CancellationToken cancellationToken);
    Task<Category> DeleteAsync(Category entity, CancellationToken cancellationToken);
}