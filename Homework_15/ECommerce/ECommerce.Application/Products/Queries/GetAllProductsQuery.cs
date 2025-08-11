using MediatR;
using ECommerce.Application.Products.Dtos;

namespace ECommerce.Application.Products.Queries;

/// <summary>
/// Query to get all products.
/// </summary>
public record GetAllProductsQuery() : IRequest<IEnumerable<ProductDto>>;