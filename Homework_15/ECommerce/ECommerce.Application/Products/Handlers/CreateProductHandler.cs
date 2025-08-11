using MediatR;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using ECommerce.Application.Products.Dtos;
using ECommerce.Application.Products.Commands;

namespace ECommerce.Application.Products.Handlers;

/// <summary>
/// Handler to create a product.
/// </summary>
public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductDto>
{
    private readonly IProductRepository _productRepository;

    /// <summary>
    /// Constructs handler.
    /// </summary>
    public CreateProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    /// <inheritdoc/>
    public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = new Product
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            CategoryId = request.CategoryId
        };

        var product = await _productRepository.CreateAsync(entity, cancellationToken);

        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            CategoryId = product.CategoryId
        };
    }
}
