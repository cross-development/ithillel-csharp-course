using MediatR;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Exceptions;
using ECommerce.Domain.Interfaces;
using ECommerce.Application.Products.Dtos;
using ECommerce.Application.Products.Commands;

namespace ECommerce.Application.Products.Handlers;

/// <summary>
/// Handler to update a product.
/// </summary>
public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ProductDto?>
{
    private readonly IProductRepository _productRepository;

    /// <summary>
    /// Constructs handler.
    /// </summary>
    public UpdateProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    /// <inheritdoc/>
    public async Task<ProductDto?> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var existingProduct = await _productRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingProduct == null)
        {
            throw new NotFoundException(nameof(Product), request.Id.ToString());
        }

        existingProduct.Name = request.Name;
        existingProduct.Description = request.Description;
        existingProduct.Price = request.Price;
        existingProduct.CategoryId = request.CategoryId;

        var updatedAsync = await _productRepository.UpdateAsync(existingProduct, cancellationToken);

        return new ProductDto
        {
            Id = updatedAsync.Id,
            Name = updatedAsync.Name,
            Description = updatedAsync.Description,
            Price = updatedAsync.Price,
            CategoryId = updatedAsync.CategoryId
        };
    }
}
