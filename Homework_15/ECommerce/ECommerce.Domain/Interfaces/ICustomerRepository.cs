using ECommerce.Domain.Entities;

namespace ECommerce.Domain.Interfaces;

public interface ICustomerRepository
{
    Task<IEnumerable<Customer>> GetAllAsync(CancellationToken cancellationToken);
    Task<Customer?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<Customer> CreateAsync(Customer entity, CancellationToken cancellationToken);
    Task<Customer> UpdateAsync(Customer entity, CancellationToken cancellationToken);
    Task<Customer> DeleteAsync(Customer entity, CancellationToken cancellationToken);
}