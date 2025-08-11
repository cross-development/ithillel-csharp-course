using MediatR;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using ECommerce.Application.Categories.Dtos;
using ECommerce.Application.Categories.Commands;

namespace ECommerce.Application.Categories.Handlers;

/// <summary>
/// Handler to create a category.
/// </summary>
public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
{
    private readonly ICategoryRepository _categoryRepository;

    /// <summary>
    /// Constructs handler.
    /// </summary>
    public CreateCategoryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    /// <inheritdoc/>
    public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = new Category
        {
            Name = request.Name,
            Description = request.Description
        };

        var category = await _categoryRepository.CreateAsync(entity, cancellationToken);

        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description
        };
    }
}
