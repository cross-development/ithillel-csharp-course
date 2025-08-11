using MediatR;
using ECommerce.Application.Products.Dtos;

namespace ECommerce.Application.Products.Commands;

/// <summary>
/// Command to update a product.
/// </summary>
public record UpdateProductCommand(int Id, string Name, string? Description, decimal Price, int CategoryId) : IRequest<ProductDto?>;