using MediatR;
using ECommerce.Domain.Interfaces;
using ECommerce.Application.Products.Dtos;
using ECommerce.Application.Products.Queries;

namespace ECommerce.Application.Products.Handlers;

/// <summary>
/// Handler to get products list.
/// </summary>
public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
{
    private readonly IProductRepository _productRepository;

    /// <summary>
    /// Constructs handler.
    /// </summary>
    public GetAllProductsHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var list = await _productRepository.GetAllAsync(cancellationToken);

        return list.Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            CategoryId = p.CategoryId
        }).ToList();
    }
}
