using MediatR;
using ECommerce.Application.Products.Dtos;

namespace ECommerce.Application.Products.Commands;

/// <summary>
/// Command to create a product.
/// </summary>
public record CreateProductCommand(string Name, string? Description, decimal Price, int CategoryId) : IRequest<ProductDto>;
