using MediatR;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using ECommerce.Application.Customers.Dtos;
using ECommerce.Application.Customers.Commands;

namespace ECommerce.Application.Customers.Handlers;

/// <summary>
/// Handler to create a customer.
/// </summary>
public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
{
    private readonly ICustomerRepository _customerRepository;

    /// <summary>
    /// Constructs handler.
    /// </summary>
    public CreateCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    /// <inheritdoc/>
    public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var entity = new Customer
        {
            FullName = request.FullName,
            Email = request.Email,
            Phone = request.Phone
        };

        var customer = await _customerRepository.CreateAsync(entity, cancellationToken);

        return new CustomerDto
        {
            Id = customer.Id,
            FullName = customer.FullName,
            Email = customer.Email,
            Phone = customer.Phone
        };
    }
}