using MediatR;

namespace ECommerce.Application.Products.Commands;

/// <summary>
/// Command to delete a product.
/// </summary>
public record DeleteProductCommand(int Id) : IRequest<int>;