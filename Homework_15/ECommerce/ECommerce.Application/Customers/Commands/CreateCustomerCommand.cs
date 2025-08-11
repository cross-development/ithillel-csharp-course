using MediatR;
using ECommerce.Application.Customers.Dtos;

namespace ECommerce.Application.Customers.Commands;

/// <summary>
/// Command to create a customer.
/// </summary>
public record CreateCustomerCommand(string FullName, string Email, string? Phone) : IRequest<CustomerDto>;