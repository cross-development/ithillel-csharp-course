using MediatR;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Exceptions;
using ECommerce.Domain.Interfaces;
using ECommerce.Application.Categories.Commands;

namespace ECommerce.Application.Categories.Handlers;

/// <summary>
/// Handler to delete a category.
/// </summary>
public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, int>
{
    private readonly ICategoryRepository _categoryRepository;

    /// <summary>
    /// Constructs handler.
    /// </summary>
    public DeleteCategoryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    /// <inheritdoc/>
    public async Task<int> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var existingCategory = await _categoryRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingCategory == null)
        {
            throw new NotFoundException(nameof(Category), request.Id.ToString());
        }

        var removedCategory = await _categoryRepository.DeleteAsync(existingCategory, cancellationToken);

        return removedCategory.Id;
    }
}
