using MediatR;
using ECommerce.Application.Customers.Dtos;

namespace ECommerce.Application.Customers.Queries;

/// <summary>
/// Query to get customer by id.
/// </summary>
public record GetCustomerByIdQuery(int Id) : IRequest<CustomerDto?>;