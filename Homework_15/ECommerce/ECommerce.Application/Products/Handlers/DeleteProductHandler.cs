using MediatR;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Exceptions;
using ECommerce.Domain.Interfaces;
using ECommerce.Application.Products.Commands;

namespace ECommerce.Application.Products.Handlers;

/// <summary>
/// Handler to delete a product.
/// </summary>
public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, int>
{
    private readonly IProductRepository _productRepository;

    /// <summary>
    /// Constructs handler.
    /// </summary>
    public DeleteProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    /// <inheritdoc/>
    public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var existingProduct = await _productRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingProduct == null)
        {
            throw new NotFoundException(nameof(Product), request.Id.ToString());
        }

        var removedProduct = await _productRepository.DeleteAsync(existingProduct, cancellationToken);

        return removedProduct.Id;
    }
}
