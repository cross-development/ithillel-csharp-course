using MediatR;
using ECommerce.Application.Customers.Dtos;

namespace ECommerce.Application.Customers.Commands;

/// <summary>
/// Command to update a customer.
/// </summary>
public record UpdateCustomerCommand(int Id, string FullName, string Email, string? Phone) : IRequest<CustomerDto?>;