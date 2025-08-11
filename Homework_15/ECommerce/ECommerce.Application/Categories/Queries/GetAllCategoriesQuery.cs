using MediatR;
using ECommerce.Application.Categories.Dtos;

namespace ECommerce.Application.Categories.Queries;

/// <summary>
/// Query to get all categories.
/// </summary>
public record GetAllCategoriesQuery() : IRequest<IEnumerable<CategoryDto>>;
