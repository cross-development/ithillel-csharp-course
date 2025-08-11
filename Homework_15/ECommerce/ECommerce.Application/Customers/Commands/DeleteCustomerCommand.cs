using MediatR;

namespace ECommerce.Application.Customers.Commands;

/// <summary>
/// Command to delete a customer.
/// </summary>
public record DeleteCustomerCommand(int Id) : IRequest<int>;