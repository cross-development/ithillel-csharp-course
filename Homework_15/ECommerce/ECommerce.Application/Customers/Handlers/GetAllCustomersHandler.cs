using MediatR;
using ECommerce.Domain.Interfaces;
using ECommerce.Application.Customers.Dtos;
using ECommerce.Application.Customers.Queries;

namespace ECommerce.Application.Customers.Handlers;

/// <summary>
/// Handler to get customers list.
/// </summary>
public class GetAllCustomersHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<CustomerDto>>
{
    private readonly ICustomerRepository _customerRepository;

    /// <summary>
    /// Constructs handler.
    /// </summary>
    public GetAllCustomersHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<CustomerDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        var list = await _customerRepository.GetAllAsync(cancellationToken);

        return list.Select(c => new CustomerDto
        {
            Id = c.Id,
            FullName = c.FullName,
            Email = c.Email,
            Phone = c.Phone
        }).ToList();
    }
}