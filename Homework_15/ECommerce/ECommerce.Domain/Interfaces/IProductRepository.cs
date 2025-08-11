using ECommerce.Domain.Entities;

namespace ECommerce.Domain.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken);
    Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<List<Product>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken);
    Task<Product> CreateAsync(Product entity, CancellationToken cancellationToken);
    Task<Product> UpdateAsync(Product entity, CancellationToken cancellationToken);
    Task<Product> DeleteAsync(Product entity, CancellationToken cancellationToken);
}