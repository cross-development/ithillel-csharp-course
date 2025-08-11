using MediatR;
using ECommerce.Application.Categories.Dtos;

namespace ECommerce.Application.Categories.Queries;

/// <summary>
/// Query to get category by id.
/// </summary>
public record GetCategoryByIdQuery(int Id) : IRequest<CategoryDto?>;
