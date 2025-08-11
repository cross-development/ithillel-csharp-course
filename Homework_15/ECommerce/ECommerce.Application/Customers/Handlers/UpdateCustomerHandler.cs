using MediatR;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Exceptions;
using ECommerce.Domain.Interfaces;
using ECommerce.Application.Customers.Dtos;
using ECommerce.Application.Customers.Commands;

namespace ECommerce.Application.Customers.Handlers;

/// <summary>
/// Handler to update a customer.
/// </summary>
public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, CustomerDto?>
{
    private readonly ICustomerRepository _customerRepository;

    /// <summary>
    /// Constructs handler.
    /// </summary>
    public UpdateCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    /// <inheritdoc/>
    public async Task<CustomerDto?> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var existingCustomer = await _customerRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingCustomer == null)
        {
            throw new NotFoundException(nameof(Customer), request.Id.ToString());
        }

        existingCustomer.FullName = request.FullName;
        existingCustomer.Email = request.Email;
        existingCustomer.Phone = request.Phone;

        var updatedCustomer = await _customerRepository.UpdateAsync(existingCustomer, cancellationToken);

        return new CustomerDto
        {
            Id = updatedCustomer.Id,
            FullName = updatedCustomer.FullName,
            Email = updatedCustomer.Email,
            Phone = updatedCustomer.Phone
        };
    }
}