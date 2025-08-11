using MediatR;
using ECommerce.Domain.Interfaces;
using ECommerce.Application.Categories.Dtos;
using ECommerce.Application.Categories.Queries;

namespace ECommerce.Application.Categories.Handlers;

/// <summary>
/// Handler to get categories list.
/// </summary>
public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryDto>>
{
    private readonly ICategoryRepository _categoryRepository;

    /// <summary>
    /// Constructs handler.
    /// </summary>
    public GetAllCategoriesHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var list = await _categoryRepository.GetAllAsync(cancellationToken);

        return list.Select(c => new CategoryDto
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description
        }).ToList();
    }
}
