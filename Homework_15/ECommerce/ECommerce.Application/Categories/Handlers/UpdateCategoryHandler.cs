using MediatR;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Exceptions;
using ECommerce.Domain.Interfaces;
using ECommerce.Application.Categories.Dtos;
using ECommerce.Application.Categories.Commands;

namespace ECommerce.Application.Categories.Handlers;

/// <summary>
/// Handler to update a category.
/// </summary>
public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, CategoryDto?>
{
    private readonly ICategoryRepository _categoryRepository;

    /// <summary>
    /// Constructs handler.
    /// </summary>
    public UpdateCategoryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    /// <inheritdoc/>
    public async Task<CategoryDto?> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var existingCategory = await _categoryRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingCategory == null)
        {
            throw new NotFoundException(nameof(Category), request.Id.ToString());
        }

        existingCategory.Name = request.Name;
        existingCategory.Description = request.Description;

        var updatedCategory = await _categoryRepository.UpdateAsync(existingCategory, cancellationToken);

        return new CategoryDto
        {
            Id = updatedCategory.Id,
            Name = updatedCategory.Name,
            Description = updatedCategory.Description
        };
    }
}
