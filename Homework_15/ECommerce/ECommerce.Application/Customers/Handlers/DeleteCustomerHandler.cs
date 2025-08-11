using MediatR;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Exceptions;
using ECommerce.Domain.Interfaces;
using ECommerce.Application.Customers.Commands;

namespace ECommerce.Application.Customers.Handlers;

/// <summary>
/// Handler to delete a customer.
/// </summary>
public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, int>
{
    private readonly ICustomerRepository _customerRepository;

    /// <summary>
    /// Constructs handler.
    /// </summary>
    public DeleteCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    /// <inheritdoc/>
    public async Task<int> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var existingCustomer = await _customerRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingCustomer == null)
        {
            throw new NotFoundException(nameof(Customer), request.Id.ToString());
        }

        var removedCustomer = await _customerRepository.DeleteAsync(existingCustomer, cancellationToken);

        return removedCustomer.Id;
    }
}