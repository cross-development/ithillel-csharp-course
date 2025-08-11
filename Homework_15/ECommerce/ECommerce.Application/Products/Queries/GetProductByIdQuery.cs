using MediatR;
using ECommerce.Application.Products.Dtos;

namespace ECommerce.Application.Products.Queries;

/// <summary>
/// Query to get a product by id.
/// </summary>
public record GetProductByIdQuery(int Id) : IRequest<ProductDto?>;
