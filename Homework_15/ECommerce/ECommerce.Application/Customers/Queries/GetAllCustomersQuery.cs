using MediatR;
using ECommerce.Application.Customers.Dtos;

namespace ECommerce.Application.Customers.Queries;

/// <summary>
/// Query to get all customers.
/// </summary>
public record GetAllCustomersQuery() : IRequest<IEnumerable<CustomerDto>>;